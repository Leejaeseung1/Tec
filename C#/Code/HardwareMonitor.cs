using LibreHardwareMonitor.Hardware;
using System.Runtime.Versioning;
using System.Text;

namespace C_.Code
{
    /// <summary>
    /// need administrator
    /// need LibreHardwareMonitorLib nuget (this is 0.9.3)
    /// </summary>
    [SupportedOSPlatform(BuiltInRoleProcess.WINDOWS)]
    internal class HardwareMonitor
    {
        private Computer _com;
        private BuiltInRoleProcess _builtInRole;

        internal HardwareMonitor()
        {
            _com = new Computer
            {
                //get info hardware
                IsCpuEnabled = true,
                IsGpuEnabled = true,
                IsMotherboardEnabled = true,
                IsStorageEnabled = true,
                IsBatteryEnabled = true,
                IsControllerEnabled = true,
                IsMemoryEnabled = true,
                IsNetworkEnabled = true,
                IsPsuEnabled = true,
            };

            var v = _com.Hardware;

            _builtInRole = new BuiltInRoleProcess();
        }

        public void Open()
        {
            _builtInRole.GetAdministrator();
            _com.Open();
        }

        public string GetInfoAfterUpdate()
        {
            const string FAIL_VALUE = "-1"; //if no administrator, value is "-1"

            var sb = new StringBuilder();

            foreach (var hard in _com.Hardware)
            {
                hard.Update();
                foreach (var sub in hard.SubHardware)
                {
                    sub.Update();
                }

                foreach (var sensor in hard.Sensors)
                {
                    string value = sensor.Value.HasValue ? sensor.Value.Value.ToString() : FAIL_VALUE;
                    string text = $"{sensor.Name} {sensor.SensorType} = {value}";
                    sb.AppendLine(text);
                }
            }
            return sb.ToString();
        }
    }
}
