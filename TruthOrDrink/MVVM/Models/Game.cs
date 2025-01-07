using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


namespace TruthOrDrink.MVVM.Models
{
    [Table("Game")]
    public class Game
    {
        public int Id { get; set; }
        public List<User>? Players { get; set; }
        public Category? Category { get; set; }
    }
}
