using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthOrDrink.MVVM.Models
{
    public class Meme
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int BoxCount { get; set; }
        public int Captions { get; set; }
    }
}
