using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class DiskInfo
    {
        private static DriveInfoReader driveInfoReader = new DriveInfoReader();

        public static DiskSystemInformation GetDiskInfo()
        {
            return driveInfoReader.GetSysInfo();
        }
        public static string GetDiskInfoJSON()
        {
            return driveInfoReader.GetJSON();
        }
        public static void ParseDiskTypeResult(string jsonMessage)
        {
            driveInfoReader.ParseDiskTypeResult(jsonMessage);
            return;
        }
    }
}
