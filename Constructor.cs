﻿
namespace Tec
{
    internal class Constructor
    {
        struct Constructor2
        {
            public int A;
            public int B;

        }

        public int A;
        public int B;

        void Temp()
        {
            Constructor c = new Constructor()
            {
                A = 1,
                B = 2
            };

            Constructor2 c2 = new Constructor2()
            {
                A = 1,
                B = 2
            };
        }
    }
}
