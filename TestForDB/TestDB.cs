using System;
using System.Collections.Generic;
using CheckConnection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckConnection.Methods;
using CheckConnection.Model;
using Common;
using SQLite;

namespace TestForDB
{
    [TestClass]
    public class TestDb
    {
        [TestMethod]
        public void TestMethodForDb()
        {
            
                DbMethods dbMethods = new DbMethods();
                //var dbConnection = new SQLiteConnection(db.conn_string, true);
                List<Connection> connections = dbMethods.ReadConnectionHistory();
                List<Gateway> gateways = dbMethods.ReadGatewayHistory(0);
                List<DNS> dns = dbMethods.ReadDNSHistory(0);
                //db.isTableExists("example", dbConnection);
                //db.SaveConnectionTable(connections,dns,gateways);
                //db.SaveDNSTable(dns,dbConnection,0);
                //db.SaveGatewayTable(gateways,dbConnection,0);
                string table_name = "Connection";
            try
            {
                using (var db = new SQLiteConnection(dbMethods.conn_string, /*SQLiteOpenFlags.Create,*/ true))
                {
                    if (!dbMethods.isTableExists(table_name, db))
                    {
                        db.CreateTable<Connection>();
                    }

                    foreach (Connection conn in connections)
                    {

                        db.RunInTransaction(() =>
                        {
                            db.Insert(conn);
                            conn.Id = db.ExecuteScalar<int>("SELECT last_insert_rowid()");
                            dbMethods.SaveDNSTable(dns, db, conn.Id);
                            dbMethods.SaveGatewayTable(gateways, db, conn.Id);
                        });

                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
