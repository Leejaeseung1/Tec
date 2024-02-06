using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tec
{
    internal class Lambda
    {
        public void F()
        {
            //local func is better than delegate func<T>
            int x3() => 3;
            var x4 = () => 4;
            var x5 = () => { return 5; };

            var x1 = (int x) => x + 1;
            int x2(int x) => x + 1;

            int x6(int x, int y) => x + y;

            var x7 = (int x, int y) =>
            {
                return x + y;
            };

            int x8(int x, int y)
            {
                return x + y;
            };

            int a = x1(1);
            int b = x2(1);
            int c = x3();
            int d = x6(1, 2);
            int e = x7(1, 2);
            int f = x8(1, 2);
        }

        public void F2()
        {
            bool isZeroPoint(Point a) => a is { X: 0, Y: 0 };
            var v = isZeroPoint(new Point(0, 0)); //true
        }
    }
}
