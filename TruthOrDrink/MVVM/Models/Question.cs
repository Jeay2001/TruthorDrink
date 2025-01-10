using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TruthOrDrink.Abstractions;
using TruthOrDrink.Enum;

namespace TruthOrDrink.MVVM.Models
{
    [Table("Question")]
    public class Question : TableData
    {
        [Column("QuestionText"), NotNull]
        public string QuestionText { get; set; }

        [Column("Type"), NotNull]
        public string Type { get; set; } // "Truth" or "Dare"

        [Column("Difficulty"), NotNull]
        public DifficultyEnum Difficulty { get; set; }

        [Ignore]
        public Category Category { get; set; }
    }
}
