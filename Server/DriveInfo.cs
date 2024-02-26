using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class DiskSystemInformation
    {
        public string SystemName { get; set; }
        public List<PhysicalDiskInformation> PhysicalDisk { get; set; }

        public DiskSystemInformation()
        {
            PhysicalDisk = new List<PhysicalDiskInformation>();
        }
    }
    public class PhysicalDiskInformation
    {
        public string KernelPath { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
        public string SerialNumber { get; set; }
        public string FirmwareVersion { get; set; }
        public string Interface { get; set; }
        public string PNPDeviceID { get; set; }
        public string Status { get; set; }
        public int BytesPerSector { get; set; }
        public int SectorPerTrack { get; set; }
        public string DiskHardwareType { get; set; }

        public List<LogicalDiskInformation> Logical { get; set; }

        public PhysicalDiskInformation()
        {
            Logical = new List<LogicalDiskInformation>();
        }
    }
    public class LogicalDiskInformation
    {
        public string DriveLetter { get; set; }
        public string VolumeName { get; set; }
        public long Size { get; set; }
        public long FreeSize { get; set; }
        public uint SerialNumber { get; set; }
        public string Format { get; set; }
    }
    public class DiskDriveType
    {
        public string SerialNumber { get; set; }
        public string Type { get; set; }
    }
}
