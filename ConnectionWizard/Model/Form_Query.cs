using SQLite;

namespace ConnectionWizard.Model
{
    class Form_Query
    {
        [PrimaryKey, /*AutoIncrement,*/ Unique]
        public int Id_Query { get; set; }
        [NotNull]
        public int Id_Form { get; set; }
        [NotNull]
        public string Query { get; set; }
        [NotNull]
        public int Num_Query { get; set; }
        public string Hint_User { get; set; }
    }
}
