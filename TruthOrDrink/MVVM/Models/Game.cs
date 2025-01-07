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
      
        public List<User>? Players { get; set; }
        public Category? Category { get; set; }
    }
}
