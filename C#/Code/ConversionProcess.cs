using System.Numerics;

namespace C_.Code
{
    internal class ConversionProcess
    {
        public BigInteger Value;

        public ConversionProcess(int value = 0)
        {
            Value = value;
        }

        //size: BinInterger > int, ConversionProcess -> int must explicit
        //int -> ConversionProcess is data overflow, ConversionProcess must implicit
        public static explicit operator int(ConversionProcess a) => (int)a.Value; //ConversionProcess -> int
        public static implicit operator ConversionProcess(int b) => new ConversionProcess(b); //int -> ConversionProcess

        public void F()
        {
            ConversionProcess c = 1;
            int i = (int)c; //int i = c; //error
        }
    }
}
