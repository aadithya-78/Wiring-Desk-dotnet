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
        public static int targetCount { get; set; }

        public static string deskName { get; set; }

        public static string lineName { get; set; }

        public static string subName { get; set; }

        public static string operatorName { get; set; }

        public static string switchTwo { get; set; }

        public static bool pauseFlag { get; set; } = false;

    }
}
