using SQLite;

namespace CheckConnection.Model
{
    public class Gateway
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }
        [NotNull]
        public int Connection_Id { get; set; }
        [NotNull]
        public string IPGateway { get; set; }
    }
}
