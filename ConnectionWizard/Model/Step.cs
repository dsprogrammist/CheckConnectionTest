using System;
using SQLite;

namespace ConnectionWizard.Model
{
    class Step
    {
            [PrimaryKey, AutoIncrement, Unique]
            public int Id { get; set; }
            [NotNull, Indexed]
            public int OrderId { get; set; }
            [NotNull]
            public string Name { get; set; }
            [NotNull]
            public string Text { get; set; }
            [NotNull]
            public int Type { get; set; }
    }
}
