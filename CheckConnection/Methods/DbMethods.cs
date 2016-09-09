using System;
using System.Collections.Generic;
using SQLite;
using CheckConnection.Model;
using Common;

namespace CheckConnection.Methods
{
    public class DbMethods : DBConnection
    {

        public DbMethods()
        {
            conn_string = Properties.Settings.Default.DBConnectionString;
        }
        public void SaveConnectionTable( List<Connection> Connection_list, 
                                         List<DNS> DNS_list,
                                         List<Gateway> Gateway_list
                                            )
        {
            string table_name = "Connection";
            using (var db = new SQLiteConnection(conn_string, /*SQLiteOpenFlags.Create,*/ true))
            {
                if (!isTableExists(table_name, db))
                {
                    db.CreateTable<Connection>();
                }

                foreach ( Connection conn in Connection_list )
                {

                    db.RunInTransaction(() =>
                    {
                        db.Insert(conn);
                        conn.Id = db.ExecuteScalar<int>("SELECT last_insert_rowid()");
                        SaveDNSTable(DNS_list, db, conn.Id);
                        SaveGatewayTable(Gateway_list, db, conn.Id);
                    });

                }
            }
        }

        public void SaveDNSTable(List<DNS> DNS_list, SQLiteConnection db, int connId)
        {
            string table_name = "DNS";
            if (!isTableExists(table_name, db))
            {
                db.CreateTable<DNS>();
            }
            foreach (DNS dns in DNS_list)
            {
              dns.Connection_Id = connId; 
              db.Insert(dns);
            }            
        }

        public void SaveGatewayTable(List<Gateway> Gateway_list, SQLiteConnection db, int connId)
        {
            string table_name = "Gateway";
            if (!isTableExists(table_name, db))
            {
                db.CreateTable<Gateway>();
            }
            foreach (Gateway gtw in Gateway_list)
            {
               gtw.Connection_Id = connId;
               db.Insert(gtw);
            }
        }

        public List<Connection> ReadConnectionHistory()
        {
            string table_name = "Connection";
            List<Connection> Connection_list = new List<Connection>();

            using (var db = new SQLiteConnection(conn_string, /*SQLiteOpenFlags.ReadOnly,*/ true))
            {
                if (isTableExists(table_name, db))
                {
                    var connections = db.Query<Connection>(String.Format("SELECT * FROM {0} order by Date desc", table_name));
                    foreach (var conn in connections)
                    {
                        Connection_list.Add(conn);
                    }
                }
            }
            return Connection_list;
        }
        //public List<Connection> ReadFullConnectionHistory()
        //{
        //    string[] table_name = new string[] { "Connection", "DNS", "Gateway" };
        //    List<Connection> Connection_list = new List<Connection>();

        //    using (var db = new SQLiteConnection(conn_string, /*SQLiteOpenFlags.ReadOnly,*/ true))
        //    {
        //        if (isTableExists(table_name, db))
        //        {
        //            var connections = db.Query<Connection>(String.Format("SELECT * FROM {0} order by Date desc", table_name));
        //            foreach (var conn in connections)
        //            {
        //                Connection_list.Add(conn);
        //            }
        //        }
        //    }
        //    return Connection_list;
        //}
        public List<DNS> ReadDNSHistory(int Connection_Id)
        {
            string table_name = "DNS";
            List<DNS> DNS_list = new List<DNS>();

            using (var db = new SQLiteConnection(conn_string, /*SQLiteOpenFlags.ReadOnly,*/ true))
            {
                if (isTableExists(table_name, db))
                {
                    var dns_array = db.Query<DNS>(String.Format("SELECT * FROM {0} where connection_id = {1} order by Order_Id asc", table_name, Connection_Id));
                    foreach (var dns in dns_array)
                    {
                        DNS_list.Add(dns);
                    }
                }
            }
            return DNS_list;
        }

        public List<Gateway> ReadGatewayHistory(int Connection_Id)
        {
            string table_name = "Gateway";
            List<Gateway> Gateway_list = new List<Gateway>();

            using (var db = new SQLiteConnection(conn_string, /*SQLiteOpenFlags.ReadOnly,*/ true))
            {
                if (isTableExists(table_name, db))
                {
                    var gateway_array = db.Query<Gateway>(String.Format("SELECT * FROM {0} where connection_id = {1} order by Id asc", table_name, Connection_Id));
                    foreach (var gtw in gateway_array)
                    {
                        Gateway_list.Add(gtw);
                    }
                }
            }
            return Gateway_list;
        }

        public void SavePingTable(ref List<Ping> Ping_list)
        {

            using (var db = new SQLiteConnection(conn_string, /*SQLiteOpenFlags.Create,*/ true))
            {
                db.CreateTable<Ping>();

                foreach (Ping png in Ping_list)
                {
                    db.Insert(png);
                }

            }
        }

        public void SaveTracertTable(ref List<Tracert> Tracert_list)
        {

            using (var db = new SQLiteConnection(conn_string, /*SQLiteOpenFlags.Create,*/ true))
            {
                db.CreateTable<Tracert>();

                foreach (Tracert trc in Tracert_list)
                {
                    db.Insert(trc);
                }

            }
        }

        public void SaveHopTable(ref List<Hop> Hop_list)
        {

            using (var db = new SQLiteConnection(conn_string, /*SQLiteOpenFlags.Create,*/ true))
            {
                db.CreateTable<Hop>();

                foreach (Hop hop in Hop_list)
                {
                    db.Insert(hop);
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
