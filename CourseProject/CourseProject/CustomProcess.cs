using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject
{
    class CustomProcess
    {
        public enum EPriority { Idle = 0, Low = 4, Normal = 8, High = 13, RealTime = 24 };

        public string Task { get; private set; }
        public int PID { get; private set; }
        public string UID { get; private set; }
        public string Size { get; private set; }
        public EPriority Priority { get; private set; }

        public CustomProcess(string name, int id, string uid, long size, int priority)
        {
            Task = name;
            PID = id;
            UID = uid;
            Size = ConvertToReadable(size);
            switch (priority)
            {
                case 4:
                    Priority = EPriority.Low;
                    break;
                case 8:
                    Priority = EPriority.Normal;
                    break;
                case 13:
                    Priority = EPriority.High;
                    break;
                case 24:
                    Priority = EPriority.RealTime;
                    break;
            }
        }

        private double SizeConverter(long size) { return (size / 1024); }
        private double SizeConverter(double size) { return (size / 1024); }

        private string ConvertToReadable(long size)
        {
            double kb = SizeConverter(size);
            if (kb.CompareTo(1024f) >= 0)
            {
                return String.Format("{0:0.#}Mb", SizeConverter(kb));
            }
            else return String.Format("{0:0.#}Kb", kb);
        }
    }
}
