using System;
using SQLite;

namespace ConnectionWizard.Model
{
    class Form_Visit
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int Id_Visit { get; set; }
        [NotNull, Indexed]
        public int Id_Form { get; set; }
        [NotNull]
        public DateTime Date_Beg { get; set; }
    }
}
