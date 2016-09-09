using SQLite;

namespace ConnectionWizard.Model
{
    class Link
    {
        [NotNull, Indexed]
        public int FromId { get; set; }
        [NotNull, Indexed]
        public int ToId { get; set; }
    }
}
