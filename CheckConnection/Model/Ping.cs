using System;
using SQLite;

namespace CheckConnection.Model
{
    public class Ping
    {

            [PrimaryKey, AutoIncrement, Unique]
            public int Id { get; set; }
            [NotNull, Indexed]
            public DateTime Date { get; set; }
            [NotNull]
            public int Connection_Id { get; set; }
            [NotNull]
            public string Name { get; set; }
            [NotNull]
            public string Ip_Address { get; set; }
            [NotNull]
            public string StatusCode { get; set; }
            [NotNull]
            public string ResponseTime { get; set; }

    }
}