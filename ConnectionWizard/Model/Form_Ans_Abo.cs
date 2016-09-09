using SQLite;

namespace ConnectionWizard.Model
{
    class Form_Ans_Abo
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int Id_Ans_Abo { get; set; }
        [NotNull]
        public int Id_Query { get; set; }
        [NotNull]
        public int Id_Ans { get; set; }
        public string Answer { get; set; }
        [NotNull]
        public int Id_Visit { get; set; }
        [NotNull]
        public int Priority { get; set; }
    }
}
