using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tec
{
    internal class TupleProcess
    {
        public void F()
        {
            static (int, string) local()
            {
                return (1, "a");
            }
            var (v1, v2) = local();
            v1 += 1;
            v2 += 2;

            var v = f();
            var v3 = v.Item1;
            var v4 = v.Item2;
        }

        private static Tuple<int, string> f()
        {
            return Tuple.Create(1, "a");
        }
    }
}
