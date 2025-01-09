using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthOrDrink.MVVM.View;

namespace TruthOrDrink.Logic
{
    public class MemeResponse
    {
        public bool Success { get; set; }
        public MemeData Data { get; set; }
    }
}
