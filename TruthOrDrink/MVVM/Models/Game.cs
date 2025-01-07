using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TruthOrDrink.Abstractions;


namespace TruthOrDrink.MVVM.Models
{
    [Table("Game")]
    public class Game : TableData
    {
        [Ignore]
        public List<User>? Players { get; set; }
        [Ignore]
        public Category? Category { get; set; }
    }
}
