using System;
using SQLite;
using ConnectionWizard.Model;
using System.Collections.Generic;
using Common;

namespace ConnectionWizard.Methods
{
    class DBMethods : DBConnection
    {
        public DBMethods()
        {
            conn_string = Properties.Settings.Default.DBConnectionString;
        }
       
        public Forms GetFormsById(int idform)
        {
            Forms form; ;
            using (var db = new SQLiteConnection(conn_string, true))
            {
                var form_query = db.Get<Forms>(idform);
                form = (Forms)form_query;
            }
            return form;
        }

        public Form_Query GetQuery(int idquery)
        {
            Form_Query form; ;
            using (var db = new SQLiteConnection(conn_string, true))
            {
                var form_query = db.Get<Form_Query>(idquery);
                form = (Form_Query)form_query;
            }
            return form;
        }

        public List<Form_Query> GetQueryTable()
        {
            string table_name = "Form_Query";
            List<Form_Query> form_query_list = new List<Form_Query>();

            using (var db = new SQLiteConnection(conn_string, true))
            {
                var form_query_array = db.Query<Form_Query>(String.Format("SELECT * FROM {0} order by Id_Query asc", table_name));
                form_query_list.AddRange(form_query_array);
            }
            return form_query_list;
        }

        public List<Form_Ans> GetQueryAnswer( int idquery)
        {
            string table_name = "Form_Ans";
            List<Form_Ans> form_ans_list = new List<Form_Ans>();

            using (var db = new SQLiteConnection(conn_string, true))
            {
               var form_ans_array = db.Query<Form_Ans>(String.Format("SELECT * FROM {0} where Id_Query = {1}", table_name, idquery));
               form_ans_list.AddRange(form_ans_array);
            }
            return form_ans_list;
        }

        public int GetQueryByAnswerId(int answerId)
        {
            string table_name = "Form_Ans";
            int queryId = 0;

            using (var db = new SQLiteConnection(conn_string, true))
            {
                if (isTableExists(table_name, db))
                {
                    queryId = db.ExecuteScalar<int>(String.Format("SELECT Id_Query FROM {0} where Id_Ans = {1}", table_name, answerId));
                }
            }
            return queryId;
        }

        public Form_Ans GetQueryAnswerByText(string answer)
        {
            string table_name = "Form_Ans";
            Form_Ans form_answer = new Form_Ans();

            using (var db = new SQLiteConnection(conn_string, true))
            {
               var result = from s in db.Table<Form_Ans>()
                            where s.Answer.Equals(answer)
                            select s;
               form_answer = result.FirstOrDefault();
            }
            return form_answer;
        }

        public int GetNextQueryId(int idvisit, int idquery)
        {
            int v_next=0;             

            using (var db = new SQLiteConnection(conn_string, true))
            {
                int v_count = db.ExecuteScalar<int>(String.Format(@"select count(*) from form_ans_abo
                                                                    where id_visit = {0}
                                                                    and id_query = {1};",
                                                                    idvisit,
                                                                    idquery));

                //int v_count1 = db.ExecuteScalar<int>(String.Format(@"select count(*) into v_count_1 from komkoradm.form_query_curs
                //                                                     where id_query = {0}
                //                                                     and count_ans = {1};",
                //                                                    idquery,
                //                                                    v_count));

                var form_query_curs_array = db.Query<Form_Query_Curs>(String.Format(@"select * from form_query_curs
                                                                     where id_query = {0}
                                                                     and count_ans = {1};",
                                                                     idquery,
                                                                     v_count));
                foreach (var fqc in form_query_curs_array)
                {
                    //form_query_curs_list.Add(fqc);
                    v_next = fqc.Id_Next_Query;
                    if (v_count > 0) { 
                      var form_ans_array = db.Query<Form_Ans_Abo>(String.Format(@"select * from form_ans_abo
                                                                     where id_visit = {0}
                                                                     and id_query = {1};",
                                                                     idvisit,
                                                                     idquery));
                        foreach (var fa in form_ans_array)
                        {
                            if (!String.Equals(fqc.Var_Ans, String.Format("+{0}+", fa.Id_Ans.ToString())) )
                            {
                                v_next= -3;
                                break;
                            }
                        }
                    }
                    if (v_next > 0)
                        return v_next;

                }

                Form_Query fq = GetQuery(idquery);
                v_next = fq.Num_Query;

                if (v_next > 0) 
                 return v_next;
                else                
                 v_next = -2;

            }
            return v_next;
        }

        public Form_Query GetNextQuery(int idvisit, int idquery)
        {
            Form_Query formquery = new Form_Query();
            int nextquery = GetNextQueryId(idvisit, idquery);
            if (nextquery > 0) { 
             formquery = GetQuery(nextquery);
            }
            return formquery;
        }

        public List<Form_Ans_Abo> GetNextFormAnsAbo(int idvisit,int idquery)
        {
            string[] table_name = new string[]{ "Form_Ans", "Form_Ans_Abo" };
            List<Form_Ans_Abo> form_ans_abo_list = new List<Form_Ans_Abo>();

            using (var db = new SQLiteConnection(conn_string, true))
            {
                if ( isTableExists(table_name[0], db) && isTableExists(table_name[1], db) )
                {

                    var form_ans_abo_array = 
                    db.Query<Form_Ans_Abo>(String.Format(@"select a.id_query,
                                                                   a.id_ans,
                                                                   a.answer,
                                                                   a.fl_str,
                                                                   nvl(b.id_ans_abo, (-1)) ex,
                                                                   b.str_ans,
                                                                   b.priority
                                                            from form_ans a,
                                                                (select * from form_ans_abo
                                                                    where id_visit = {0}) b
                                                             where a.id_query = {1}
                                                              and a.id_ans = b.id_ans(+)
                                                            and nvl(a.IsUsed, 1) = 1
                                                            order by a.id_ans",
                                                            table_name[0],table_name[1],
                                                            idvisit, idquery));
                    foreach (var faa in form_ans_abo_array)
                    {
                        form_ans_abo_list.Add(faa);
                    }

                }
            }
            return form_ans_abo_list;
        }

        public int SetFormAnsAbo(Form_Ans_Abo form_ans_abo)
        {
            string table_name = "Form_Ans_Abo";

            using (var db = new SQLiteConnection(conn_string, true))
            {
                if (!isTableExists(table_name, db))
                {
                    db.CreateTable<Forms>();
                }

                    db.RunInTransaction(() =>
                    {
                        db.Insert(form_ans_abo);
                        form_ans_abo.Id_Ans_Abo = db.ExecuteScalar<int>("SELECT last_insert_rowid()");
                    });

            }
            return 0; 
        }

        public int Form_Next_Query(int idvisit,int idquery)
        {
            string table_name = "Form_Ans_Abo";

            using (var db = new SQLiteConnection(conn_string, true))
            {
                if (!isTableExists(table_name, db))
                {
                   
                }
            }
            return 0;
        }

        public int SetFormVisit(int pId_Form)
        {
            string table_name = "Form_Visit";
            Form_Visit form_visit = new Form_Visit {
                 Id_Form = pId_Form, Date_Beg = DateTime.Today
            };

            using (var db = new SQLiteConnection(conn_string, true))
            {
                if (!isTableExists(table_name, db))
                {
                    db.CreateTable<Form_Visit>();
                }

                db.RunInTransaction(() =>
                 {
                    db.Insert(form_visit);
                    form_visit.Id_Visit = db.ExecuteScalar<int>("SELECT last_insert_rowid()");
                 });

            }

            return form_visit.Id_Visit;
        }

        public void InitWizardDB()
        {
            InitForms();
            InitFormQuery();
            InitFormAns();
            InitFormAnsAbo();
            InitFormCursTemp();
            InitFormQueryCurs();
        }

        public void InitForms()
        {
            string table_name = "Forms";
            //List<Forms> form_list = new List<Forms>  {
            //new Forms(){ Id_Form = 271, Name = "Диагностика", Id_Query_First = 2360, Status = 1}
            //};

            using (var db = new SQLiteConnection(conn_string, true))
            {
                if (!isTableExists(table_name, db))
                {
                    db.CreateTable<Forms>();
                }

                //foreach (Form form in form_list)
                //{

                //    db.RunInTransaction(() =>
                //    {
                //        db.Insert(form);
                //        form.Id_Form = db.ExecuteScalar<int>("SELECT last_insert_rowid()");
                //    });

                //}
            }
        }

        public void InitFormQuery()
        {
            string table_name = "Form_Query";
            //List<Form_Query> fquery_list = new List<Form_Query>  {
            //    new Form_Query(){ Id_Form = 271, Id_Query = 2360, Query = "Выберите конфигурацию", Num_Query = 2361},
            //    new Form_Query(){ Id_Form = 271, Id_Query = 2361, Query = "Проверить состояние сетевого подключения ?", Num_Query = 2362},
            //    new Form_Query(){ Id_Form = 271, Id_Query = 2362, Query = "Есть IP-адрес ?", Num_Query = 2363},
            //    new Form_Query(){ Id_Form = 271, Id_Query = 2363, Query = "Ip-адресов больше одного ?", Num_Query = 0},
            //    new Form_Query(){ Id_Form = 271, Id_Query = 2364, Query = "Есть включенные адаптеры ?", Num_Query = 0}
            //};

            using (var db = new SQLiteConnection(conn_string, true))
            {
                if (!isTableExists(table_name, db))
                {
                    db.CreateTable<Form_Query>();
                }

                //foreach (Form_Query fquery in fquery_list)
                //{

                //    db.RunInTransaction(() =>
                //    {
                //        db.Insert(fquery);                        
                //    });

                //}
            }
        }

        public void InitFormAns()
        {
            string table_name = "Form_Ans";

            using (var db = new SQLiteConnection(conn_string, true))
            {
                if (!isTableExists(table_name, db))
                {
                    db.CreateTable<Form_Ans>();
                }

                //foreach (Form_Query fquery in fquery_list)
                //{

                //    db.RunInTransaction(() =>
                //    {
                //        db.Insert(fquery);
                //    });

                //}
            }
        }

        public void InitFormAnsAbo()
        {
            string table_name = "Form_Ans_Abo";

            using (var db = new SQLiteConnection(conn_string, true))
            {
                if (!isTableExists(table_name, db))
                {
                    db.CreateTable<Form_Ans_Abo>();
                }
            }
        }

        public void InitFormCursTemp()
        {
            string table_name = "Form_Curs_Temp";

            using (var db = new SQLiteConnection(conn_string, true))
            {
                if (!isTableExists(table_name, db))
                {
                    db.CreateTable<Form_Curs_Temp>();
                }
            }
        }

        public void InitFormQueryCurs()
        {
            string table_name = "Form_Query_Curs";

            using (var db = new SQLiteConnection(conn_string, true))
            {
                if (!isTableExists(table_name, db))
                {
                    db.CreateTable<Form_Query_Curs>();
                }
            }
        }

        public bool isTableExists(String tableName, SQLiteConnection db)
        {
            if (db != null && !String.IsNullOrWhiteSpace(tableName))
            {
                int count = db.ExecuteScalar<int>("SELECT count(tbl_name) from sqlite_master where tbl_name = '" + tableName + "'");
                if (count > 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
