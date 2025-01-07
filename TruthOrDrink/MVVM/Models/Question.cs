using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TruthOrDrink.Abstractions;

namespace TruthOrDrink.MVVM.Models
{
    [Table("Question")]
    public class Question : TableData
    {
      
        public string QuestionText { get; set; }
        public Category category { get; set; }
    }
}
