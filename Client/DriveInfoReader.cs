using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.Management;
using System.Text.Json;
using System.Runtime.Versioning;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Client
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
    public class DriveInfoReader
    {

        const int IOCTL_STORAGE_QUERY_PROPERTY = 0x2D1400;
        const int IOCTL_STORAGE_PREDICT_FAILURE = 0x2d1100;

        const uint GENERIC_READ = 0x80000000;
        const uint FILE_SHARE_READ = 0x1;
        const uint FILE_SHARE_WRITE = 0x2;
        const uint OPEN_EXISTING = 3;

        [StructLayout(LayoutKind.Sequential)]
        struct STORAGE_PROPERTY_QUERY
        {
            public int PropertyId;
            public int QueryType;
            public int AdditionalParameters;
        }
        [StructLayout(LayoutKind.Sequential)]
        struct STORAGE_PREDICT_FAILURE
        {
            public uint PredictFailure;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
            public byte[] VendorSpecific;
        }
        [StructLayout(LayoutKind.Sequential)]
        struct STORAGE_DEVICE_DESCRIPTOR
        {
            public int Version;
            public int Size;
            public byte DeviceType;
            public byte DeviceTypeModifier;
            public byte RemovableMedia;
            public byte CommandQueueing;
            public int VendorIdOffset;
            public int ProductIdOffset;
            public int ProductRevisionOffset;
            public int SerialNumberOffset;
            public byte BusType;
            public byte RawPropertiesLength;
            public byte[] RawDeviceProperties;
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern SafeFileHandle CreateFile(
                            string lpFileName,
                            uint dwDesiredAccess,
                            uint dwShareMode,
                            IntPtr lpSecurityAttributes,
                            uint dwCreationDisposition,
                            uint dwFlagsAndAttributes,
                            IntPtr hTemplateFile);


        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool DeviceIoControl(
            SafeFileHandle hDevice,
            int dwIoControlCode,
            ref STORAGE_PROPERTY_QUERY lpInBuffer,
            int nInBufferSize,
            [Out] byte[] lpOutBuffer,
            int nOutBufferSize,
            out int lpBytesReturned,
            IntPtr lpOverlapped);

        [DllImport("kernel32.dll")]

        private static extern long GetVolumeInformation(
               string PathName,
               StringBuilder VolumeNameBuffer,
               UInt32 VolumeNameSize,
               ref UInt32 VolumeSerialNumber,
               ref UInt32 MaximumComponentLength,
               ref UInt32 FileSystemFlags,
               StringBuilder FileSystemNameBuffer,
               UInt32 FileSystemNameSize);

        [SupportedOSPlatform("windows")]
        private string GetPhysicalDiskSerialNumber(string PhysicalAddress)
        {
            SafeFileHandle hDevice = CreateFile(
                 PhysicalAddress,
                 GENERIC_READ,
                 FILE_SHARE_READ | FILE_SHARE_WRITE,
                 IntPtr.Zero,
                 OPEN_EXISTING,
                 0,
                 IntPtr.Zero);

            if (hDevice.IsInvalid)
            {
                Console.WriteLine(Marshal.GetLastWin32Error());
                return "";
            }

            STORAGE_PROPERTY_QUERY spq = new STORAGE_PROPERTY_QUERY();
            byte[] outputBuffer = new byte[10240]; // Buffer size can be adjusted accordingly
            int bytesReturned;

            bool result = DeviceIoControl(
                hDevice,
                IOCTL_STORAGE_QUERY_PROPERTY,
                ref spq,
                Marshal.SizeOf(spq),
                outputBuffer,
                outputBuffer.Length,
                out bytesReturned,
                IntPtr.Zero);

            if (!result)
            {
                Console.WriteLine(Marshal.GetLastWin32Error());
                return "";
            }

            GCHandle handle = GCHandle.Alloc(outputBuffer, GCHandleType.Pinned);
            STORAGE_DEVICE_DESCRIPTOR sdd = (STORAGE_DEVICE_DESCRIPTOR)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(STORAGE_DEVICE_DESCRIPTOR));
            handle.Free();

            string serialNumber = Encoding.ASCII.GetString(outputBuffer, sdd.SerialNumberOffset, outputBuffer.Length - sdd.SerialNumberOffset).TrimEnd((Char)0);

            return serialNumber;
        }
        [SupportedOSPlatform("windows")]
        private uint GetLogicalDiskSerialNumber(string DriveName)
        {
            string drive_letter = DriveName;
            drive_letter = drive_letter.Substring(0, 1) + ":\\";

            uint serial_number = 0;
            uint max_component_length = 0;
            StringBuilder sb_volume_name = new StringBuilder(256);
            UInt32 file_system_flags = new UInt32();
            StringBuilder sb_file_system_name = new StringBuilder(256);

            if (GetVolumeInformation(drive_letter, sb_volume_name,
                (UInt32)sb_volume_name.Capacity, ref serial_number,
                ref max_component_length, ref file_system_flags,
                sb_file_system_name,
                (UInt32)sb_file_system_name.Capacity) == 0)
            {
                return 0xFFFFFFFF;
            }
            else
            {
                return serial_number;
            }
        }

       // public List<PhysicalDiskInformation> ListDisk { get; set; }
        public DiskSystemInformation SysInfo { get; set; }

        [SupportedOSPlatform("windows")]
        private void QueryDiskInfo()
        {
            SysInfo = new DiskSystemInformation();

            List<PhysicalDiskInformation> ListDisk = SysInfo.PhysicalDisk;
            // Select Drive Information
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                PhysicalDiskInformation PhysicalDisk = new PhysicalDiskInformation();

                PhysicalDisk.KernelPath = wmi_HD["DeviceID"].ToString();
                PhysicalDisk.Name = wmi_HD["Model"].ToString();
                PhysicalDisk.Status = wmi_HD["Status"].ToString();
                PhysicalDisk.SerialNumber = GetPhysicalDiskSerialNumber(wmi_HD["DeviceID"].ToString()).ToString();
                PhysicalDisk.Size = Convert.ToInt64(wmi_HD["Size"]);
                PhysicalDisk.BytesPerSector = Convert.ToInt32(wmi_HD["BytesPerSector"]);
                PhysicalDisk.SectorPerTrack = Convert.ToInt32(wmi_HD["SectorsPerTrack"]);
                PhysicalDisk.FirmwareVersion = wmi_HD["FirmwareRevision"].ToString();
                PhysicalDisk.Interface = wmi_HD["InterfaceType"].ToString();
                PhysicalDisk.PNPDeviceID = wmi_HD["PNPDeviceID"].ToString();

                QueryLogicalDiskInfoOnPhysical(wmi_HD.Properties["DeviceID"].Value, ref PhysicalDisk);

                ListDisk.Add(PhysicalDisk);
            }
        }
        [SupportedOSPlatform("windows")]
        private void QueryLogicalDiskInfoOnPhysical(object DeviceID, ref PhysicalDiskInformation PhysicalDisk)
        {
            ManagementObjectSearcher partitionSearch = new ManagementObjectSearcher("Associators of {Win32_DiskDrive.DeviceID='" + DeviceID + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition");
            foreach (ManagementObject partition in partitionSearch.Get())
            {
                ManagementObjectSearcher logicalSearch = new ManagementObjectSearcher("Associators of {Win32_DiskPartition.DeviceID='" + partition["DeviceID"] + "'} WHERE AssocClass = Win32_LogicalDiskToPartition");

                foreach (ManagementObject logical in logicalSearch.Get())
                {
                    LogicalDiskInformation logicalDiskInformation = new LogicalDiskInformation();
                    PhysicalDisk.Logical.Add(logicalDiskInformation);


                    // Get Volume Information
                    ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"" + logical["Name"] + "\"");
                    disk.Get();

                    if (logical["SystemName"] != null)
                    {
                        if (SysInfo.SystemName == null)
                        {
                            SysInfo.SystemName = logical["SystemName"].ToString();
                        }
                    }
                    logicalDiskInformation.DriveLetter = logical["Name"].ToString();
                    if (logical["VolumeName"] != null)
                    logicalDiskInformation.VolumeName = logical["VolumeName"].ToString();
                    logicalDiskInformation.SerialNumber = GetLogicalDiskSerialNumber(logical["Name"].ToString());

                    if (disk["FileSystem"] != null)
                        logicalDiskInformation.Format = disk["FileSystem"].ToString();

                    logicalDiskInformation.Size = Convert.ToInt64(disk["Size"]);
                    logicalDiskInformation.FreeSize = Convert.ToInt64(disk["FreeSpace"]);
                }
            }
        }
        public DriveInfoReader()
        {
            QueryDiskInfo();
        }

        public string GetJSON()
        {
            return JsonSerializer.Serialize(SysInfo);
        }
        public DiskSystemInformation GetSysInfo()
        {
            return SysInfo;
        }
        public void ParseDiskTypeResult(string JsonMessage)
        {
            List<DiskDriveType> diskDriveTypes = JsonSerializer.Deserialize<List<DiskDriveType>>(JsonMessage);
            foreach (DiskDriveType drive_result in diskDriveTypes)
            {
                foreach (PhysicalDiskInformation phys in SysInfo.PhysicalDisk)
                {
                    if (phys.SerialNumber.Equals(drive_result.SerialNumber))
                    {
                        phys.DiskHardwareType = drive_result.Type;
                        break;
                    }
                }
            }
        }
    }
}
