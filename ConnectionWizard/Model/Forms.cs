using SQLite;

namespace ConnectionWizard.Model
{
    class Forms
    {
        [PrimaryKey, /*AutoIncrement,*/ Unique]
        public int Id_Form { get; set; }
        [NotNull]
        public string Name { get; set; }
        [NotNull]
        public int Id_Query_First { get; set; }
        public int Status { get; set; }
        public string Instruction { get; set; }
    }
}
