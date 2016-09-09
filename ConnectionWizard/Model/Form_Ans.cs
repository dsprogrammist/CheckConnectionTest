using SQLite;

namespace ConnectionWizard.Model
{
    class Form_Ans
    {
        [NotNull]
        public int Id_Query { get; set; }
        [NotNull]
        public int Id_Ans { get; set; }
        public string Answer { get; set; }
        //[NotNull]
        public int IsUsed { get; set; }
    }
}
