using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;
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

        [ForeignKey(typeof(Category))]
        public int CategoryId { get; set; }

        [ManyToOne, Ignore]
        public Category? Category { get; set; }

        [ManyToOne(CascadeOperations =CascadeOperation.All),Ignore]
        public User? User { get; set; }

        [ForeignKey(typeof(User))]
        public int UserId { get; set; }

    }
}
