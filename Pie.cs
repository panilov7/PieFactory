using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieFactory
{
    class Pie
    {
        public bool isDone { get; set; }
        public int num { get; set; }

        public Pie(int num)
        {
            this.num = num;
        }
    }
}
