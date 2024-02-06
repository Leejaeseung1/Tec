using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tec
{
    internal class ArrayProcess
    {
        public void Array_Select()
        {
            var v = new int[] { 100, 200, 300 };

            var v2 = v.Select((x) => { return x + 15; });// {115, 215, 315}

            //var v3 = v2.ToArray(); 

            v2 = v.Select((x, i) => { return i * 10 + x; });//{100, 210, 320}

            //v3 = v2.ToArray();
        }

        public void Declarate()
        {
            var v1 = new int[] { 1, 2 };
            var v2 = new int[1, 2];
            int[] v3 = [1, 2];
        }
    }
}
