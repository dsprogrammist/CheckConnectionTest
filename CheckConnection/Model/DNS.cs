using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;

namespace CheckConnection.Model
{
    public class DNS
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }
        [NotNull]
        public int Connection_Id { get; set; }
        [NotNull]
        public string DNSServer { get; set; }
        [NotNull]
        public int Order_Id { get; set; }
       
    }
}
