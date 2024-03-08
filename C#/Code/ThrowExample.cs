using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tec
{
    internal class ThrowExample
    {
        public void F()
        {
            try
            {
                int.Parse("s");
            }
            catch (Exception ex)
            {
                throw new Exception("parse error: ", ex); //message + except stack
            }
        }
    }
}
