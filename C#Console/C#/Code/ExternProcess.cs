using System.Runtime.InteropServices;

namespace Tec.C_
{
    internal class ExternProcess
    {
        [DllImport("User32.dll")] //win32
        static extern int MessageBox(IntPtr h, string message, string title, int type);

        public void F1()
        {
            var v = MessageBox(0, "content", "title", 0); //show popup message window
            Console.WriteLine(v);
        }
    }
}
