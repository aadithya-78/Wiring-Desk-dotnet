using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiring_Desk
{
    public class processState
    {
        public static int actualCount { get; set; } = 0;

        public static string userControl { get; set; }
        public int targetCount { get; set; }

    }
}
