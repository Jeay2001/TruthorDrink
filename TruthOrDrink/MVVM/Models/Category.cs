using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthOrDrink.Abstractions;
using TruthOrDrink.Enum;

namespace TruthOrDrink.MVVM.Models
{
    [Table("Category")]
    public class Category : TableData
    {
        [Column("Name"), Indexed, NotNull]
        public CategoryEnum Name { get; set; }

        [Column("Difficulty")]
        public DifficultyEnum Difficulty { get; set; }

        [Ignore]
        public List<Question>? Questions { get; set; }
    }
}
