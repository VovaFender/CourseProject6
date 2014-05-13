using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Management;
using System.Text.RegularExpressions;
using System.Threading;
using System.Runtime.InteropServices;

namespace CourseProject
{
    public partial class Form1 : Form
    {
        ProcessScheduler ps;
        string procLabelDefault = "Processes: ";
        string mryLabelDefault = "Memory Usage: ";
        string cpuLabelDefault = "CPU Usage: ";
        Point currentScrollPos;
        int currentSelectPos;
        Thread taskWatcher;

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            
        }

        private void Watcher()
        {
            while (true)
            {
                List<CustomProcess> unpackedProcList = ps.GetTasksState();
                
                string cpuUsage = ps.GetCPUUsage().ToString();
                string mryUsage = ps.GetMemoryUsage().ToString();
                if (InvokeRequired)
                {
                    //this.Invoke((MethodInvoker)delegate { Show(unpackedProcList); });
                    this.Invoke( new Action( () => Show(unpackedProcList, cpuUsage, mryUsage )));
                }
                Thread.Sleep(250);
            }
        }

        private void Show(List<CustomProcess> unpackedProcList, string cpuUsage, string mryUsage )
        {
            currentScrollPos = taskObjListView.LowLevelScrollPosition;
            currentSelectPos = taskObjListView.SelectedIndex;

            taskObjListView.ClearObjects();
            taskObjListView.SetObjects(unpackedProcList);            
            
            taskObjListView.LowLevelScroll(currentScrollPos.X, currentScrollPos.Y);
            
            if (currentSelectPos != -1)
                taskObjListView.Items[currentSelectPos].Selected = true;

            procLabel.Text = procLabelDefault + unpackedProcList.Count.ToString();
            cpuLabel.Text = cpuLabelDefault + cpuUsage + "%";
            mryLabel.Text = mryLabelDefault + mryUsage + "%";
            
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            taskObjListView.ShowCommandMenuOnRightClick = true;

            Control c = (Control)taskObjListView.GetContainerControl();
            ps = new ProcessScheduler();
            taskWatcher = new Thread(() => Watcher());
            taskWatcher.Start();
            taskWatcher.Join(3000);         
        }

        private string GetListViewProcessName(string listViewName)
        {
            Regex regEx = new Regex("\\w\\:\\s?\\{([A-Za-z\\.]*)\\}");
            Match result = regEx.Match(listViewName);
            return result.Groups[1].ToString();
        }

        private void termBtn_Click(object sender, EventArgs e)
        {
            
            if (taskObjListView.SelectedItem != null)
            {
                string procName = GetListViewProcessName(taskObjListView.SelectedItem.ToString());

                foreach (Process p in Process.GetProcessesByName(procName))
                {
                    DialogResult dr = MessageBox.Show("Are you sure?", "Decision",
                        MessageBoxButtons.YesNo , MessageBoxIcon.Question);

                    if (dr == DialogResult.Yes)
                    {
                        p.Kill();
                        
                        int index = taskObjListView.SelectedIndex;
                        //taskObjListView.Items.IndexOfKey(procName);
                        taskObjListView.Items.RemoveAt(index);
                    }
                    else return;
                }
            }
            else
                MessageBox.Show("No process selected or more than 1 processes selected");
        }

        private void process1_Exited(object sender, EventArgs e)
        {

        }

        private void appFinderBtn_Click(object sender, EventArgs e)
        {
            string processName = appFinder.Text;
            if (!String.IsNullOrEmpty(processName))
            {
                Process newPr = new Process();
                newPr.StartInfo.FileName = processName;
                try
                {
                    newPr.Start();
                }
                catch (Win32Exception ex)
                {
                    MessageBox.Show("Cannot find process with specified name");
                }
            }            
        }

        private void appFinder_TextChanged(object sender, EventArgs e)
        {
            if (appFinder.Text.Equals("Enter application nam"))
            {
                appFinder.Text = String.Empty;
            }            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            Process.Start(openFileDialog1.FileName);
        }

        private void fileBrowseBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void pauseResumeBtn_Click(object sender, EventArgs e)
        {            
            if (taskObjListView.SelectedItem != null)
            {
                string procName = GetListViewProcessName(taskObjListView.SelectedItem.ToString());
                ps.SuspendProcess(procName);                
            }
            else
                MessageBox.Show("No process selected or more than 1 processes selected");        
        }
                      
    }
}
