using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TruthOrDrink.MVVM.Models
{
    [Table("Question")]
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public Category category { get; set; }
    }
}
