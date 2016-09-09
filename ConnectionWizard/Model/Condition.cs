using SQLite;

namespace ConnectionWizard.Model
{
    class Condition
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }
        [NotNull, Indexed]
        public int StepId { get; set; }
        [NotNull]
        public string Text { get; set; }
        [NotNull, Indexed]
        public int TrueStepId { get; set; }
        [NotNull, Indexed]
        public int FalseStepId { get; set; }
    }
}
