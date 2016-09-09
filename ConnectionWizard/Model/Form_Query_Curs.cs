using SQLite;

namespace ConnectionWizard.Model
{
    class Form_Query_Curs
    {
        [NotNull]
        public int Id_Curs { get; set; }
        [NotNull]
        public int Id_Query { get; set; }
        [NotNull]
        public string Var_Ans { get; set; }
        [NotNull]
        public int Count_Ans { get; set; }
        [NotNull]
        public int Id_Next_Query { get; set; }
        [NotNull]
        public string Var_Ans_Text { get; set; }
    }
}
