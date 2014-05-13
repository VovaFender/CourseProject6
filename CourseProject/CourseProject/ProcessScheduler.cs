using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject
{
    [Flags]
    public enum ThreadAccess : int
    {
        TERMINATE = (0x0001),
        SUSPEND_RESUME = (0x0002),
        GET_CONTEXT = (0x0008),
        SET_CONTEXT = (0x0010),
        SET_INFORMATION = (0x0020),
        QUERY_INFORMATION = (0x0040),
        SET_THREAD_TOKEN = (0x0080),
        IMPERSONATE = (0x0100),
        DIRECT_IMPERSONATION = (0x0200)
    }

    class ProcessScheduler
    {        
        public Process[] ProcList { get; private set; }     //list of all processes
        private static ProcessScheduler instance;

        public ProcessScheduler(){}
        public static ProcessScheduler getInstance(){
            if (instance == null)
            {
                instance = new ProcessScheduler();
            }

            return instance;
        }

        public List<CustomProcess> GetTasksState()
        {
            ProcList = Process.GetProcesses();
            List<CustomProcess> unpackedProcList = new List<CustomProcess>();

            foreach (Process p in ProcList)
            {
                string processOwner = "System";

                ObjectQuery objQuery = new ObjectQuery("Select * From Win32_Process Where ProcessId='" + p.Id.ToString() + "'");
                ManagementObjectSearcher mos = new ManagementObjectSearcher(objQuery);

                foreach (ManagementObject mo in mos.Get())
                {
                    string[] s = new string[2];

                    mo.InvokeMethod("GetOwner", (object[])s);
                    if (!(String.IsNullOrEmpty(s[0])))
                    {
                        processOwner = s[0];
                        break;
                    }
                }
                
                CustomProcess cp = new CustomProcess(p.ProcessName, p.Id, processOwner,
                                                     p.PrivateMemorySize64, p.BasePriority);
                unpackedProcList.Add(cp);
            }

            return unpackedProcList;
        }

        public string GetCPUUsage()
        {
            ManagementObject processor = new ManagementObject("Win32_PerfFormattedData_PerfOS_Processor.Name='_Total'");
            processor.Get();
            return (processor.Properties["PercentProcessorTime"].Value.ToString());
        }

        public int GetMemoryUsage()
        {
            double memAvailable, memPhysical;

            PerformanceCounter pc = new PerformanceCounter("Memory", "Available MBytes");
            memAvailable = Convert.ToDouble(pc.NextValue());
            memPhysical = GetPhysicalMemory();          
            return Convert.ToInt32( (memPhysical - memAvailable) * 100 / memPhysical);
        }

        private double GetPhysicalMemory()
        {
            string query = "SELECT TotalPhysicalMemory FROM Win32_ComputerSystem";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            UInt32 SizeInKB = 0;

            //!!!!!
            foreach (ManagementObject wmiPART in searcher.Get())
            {
                UInt32 SizeInB = Convert.ToUInt32(wmiPART.Properties["TotalPhysicalMemory"].Value);
                SizeInKB = SizeInB / 1024;
            }
            
            return Convert.ToDouble(SizeInKB / 1024);
        }

        [DllImport("kernel32.dll")]
        static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);
        [DllImport("kernel32.dll")]
        static extern uint SuspendThread(IntPtr hThread);
        [DllImport("kernel32.dll")]
        static extern int ResumeThread(IntPtr hThread);

        public void SuspendProcess(string procName)
        {
            foreach (Process p in Process.GetProcessesByName(procName))
            {                
                foreach (ProcessThread pT in p.Threads)
                {
                    IntPtr pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)pT.Id);

                    if (pOpenThread == IntPtr.Zero)
                    {
                        break;
                    }                    
                    SuspendThread(pOpenThread);
                }
            }
        }        

        public void ResumeProcess(string procName)
        {
            foreach (Process p in Process.GetProcessesByName(procName))
            {

                foreach (ProcessThread pT in p.Threads)
                {
                    IntPtr pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)pT.Id);

                    if (pOpenThread == IntPtr.Zero)
                    {
                        break;
                    }

                    ResumeThread(pOpenThread);
                }
            }
        }
    }
}
