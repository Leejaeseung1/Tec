using System.Diagnostics;
using System.Reflection;
using System.Runtime.Versioning;
using System.Security.Principal;

namespace C_.Code
{
    [SupportedOSPlatform(WINDOWS)] //use windows os
    internal class BuiltInRoleProcess
    {
        public const string WINDOWS = "windows";

        public async Task GetAdministrator()
        {
            if (!isAdministrator())
            {
                var exeFilePath = Assembly.GetExecutingAssembly().Location; //path is dll
                exeFilePath = exeFilePath.Replace(".dll", ".exe");
                var procInfo = new ProcessStartInfo
                {
                    UseShellExecute = true,
                    FileName = exeFilePath,
                    WorkingDirectory = Environment.CurrentDirectory,
                    Verb = "runas",
                };

                try
                {
                    await Task.Run(() =>
                    {
                        Process.Start(procInfo);
                    });
                }
                catch (Exception ex)
                {
                    throw new Exception("manage fail", ex);
                }
                //success
                Environment.Exit(0); //before exe exit
            }
            //admin exe
        }

        private bool isAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();

            if (identity != null)
            {
                var principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }

            return false;
        }
    }
}
