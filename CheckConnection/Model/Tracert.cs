using System;
using SQLite;

namespace CheckConnection.Model
{
    public class Tracert
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
    }

    public class Hop
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }
        [NotNull]
        public int Tracert_Id { get; set; }
        [NotNull]
        public string Host{ get; set; }
        [NotNull]
        public int Time { get; set; }
    }
}
