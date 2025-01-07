using SQLite;
using System;
using System.Collections.Generic;
using
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthOrDrink.MVVM.Models
{
    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }

        [Column("Name"), Indexed, NotNull]
        public string Name { get; set; }

        [Column("Difficulty")]
        public int Difficulty { get; set; }

        public List<Question>? Questions { get; set; }
    }
}
