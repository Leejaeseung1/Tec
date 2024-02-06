using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tec
{
    internal class StringProcess
    {
        public void Interpolation()
        {
            int two = 2;
            int three = 0xAB;

            var str = $"two: {two:00}"; //2 number
            str += $"three: {three:X04}"; //16 4 number

            str = "two: " + two.ToString("00");
            str += "three: " + three.ToString("X04");
        }

        public void F()
        {
            var v2 = string.Join(",", new int[] { 1, 2, 3 }); //1,2,3
            v2 = string.Join(", ", new string[] { "ab", "cd", "ef" }); //ab, cd, ef
        }
    } 
}
