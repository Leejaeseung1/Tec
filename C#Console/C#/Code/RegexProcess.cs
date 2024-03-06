using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tec
{
    internal partial class RegexProcess
    {
        public void F()
        {
            var str = Console.ReadLine();
            var r = new Regex(@"\s");

            if (r.IsMatch(str))
            {
                Console.WriteLine("no space");
            }
            else
            {
                //Console.WriteLine("good");
            }

            r = new Regex(@"[a-z|A-Z|0-9|_]+@[a-z|A-Z|0-9]+\.com");
            if (r.IsMatch(str))
            {
                Console.WriteLine("good");
            }
            else
            {
                Console.WriteLine("no email");
            }
        }
    }
}
