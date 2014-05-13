using System.Windows.Forms;
namespace CourseProject
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.procLabel = new System.Windows.Forms.Label();
            this.taskObjListView = new BrightIdeasSoftware.ObjectListView();
            this.Task = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.PID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.UID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.RSS = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Priority = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.termBtn = new System.Windows.Forms.Button();
            this.cpuLabel = new System.Windows.Forms.Label();
            this.mryLabel = new System.Windows.Forms.Label();
            this.appFinder = new System.Windows.Forms.TextBox();
            this.appFinderBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fileBrowseBtn = new System.Windows.Forms.Button();
            this.pauseResumeBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.taskObjListView)).BeginInit();
            this.SuspendLayout();
            // 
            // procLabel
            // 
            this.procLabel.AutoSize = true;
            this.procLabel.Location = new System.Drawing.Point(215, 346);
            this.procLabel.Name = "procLabel";
            this.procLabel.Size = new System.Drawing.Size(0, 13);
            this.procLabel.TabIndex = 2;
            // 
            // taskObjListView
            // 
            this.taskObjListView.AllColumns.Add(this.Task);
            this.taskObjListView.AllColumns.Add(this.PID);
            this.taskObjListView.AllColumns.Add(this.UID);
            this.taskObjListView.AllColumns.Add(this.RSS);
            this.taskObjListView.AllColumns.Add(this.Priority);
            this.taskObjListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Task,
            this.PID,
            this.UID,
            this.RSS,
            this.Priority});
            this.taskObjListView.Location = new System.Drawing.Point(0, 26);
            this.taskObjListView.Name = "taskObjListView";
            this.taskObjListView.Size = new System.Drawing.Size(724, 309);
            this.taskObjListView.TabIndex = 6;
            this.taskObjListView.UseCompatibleStateImageBehavior = false;
            this.taskObjListView.View = System.Windows.Forms.View.Details;
            // 
            // Task
            // 
            this.Task.AspectName = "Task";
            this.Task.CellPadding = null;
            this.Task.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Task.Text = "Task";
            this.Task.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Task.Width = 416;
            // 
            // PID
            // 
            this.PID.AspectName = "PID";
            this.PID.CellPadding = null;
            this.PID.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PID.Text = "PID";
            this.PID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UID
            // 
            this.UID.AspectName = "UID";
            this.UID.CellPadding = null;
            this.UID.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UID.Text = "UID";
            this.UID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RSS
            // 
            this.RSS.AspectName = "Size";
            this.RSS.CellPadding = null;
            this.RSS.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RSS.Text = "RSS";
            this.RSS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Priority
            // 
            this.Priority.AspectName = "Priority";
            this.Priority.CellPadding = null;
            this.Priority.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Priority.Text = "Prior.";
            this.Priority.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Priority.Width = 68;
            // 
            // termBtn
            // 
            this.termBtn.Location = new System.Drawing.Point(649, 336);
            this.termBtn.Name = "termBtn";
            this.termBtn.Size = new System.Drawing.Size(75, 23);
            this.termBtn.TabIndex = 7;
            this.termBtn.Text = "Terminate Process";
            this.termBtn.UseVisualStyleBackColor = true;
            this.termBtn.Click += new System.EventHandler(this.termBtn_Click);
            // 
            // cpuLabel
            // 
            this.cpuLabel.AutoSize = true;
            this.cpuLabel.Location = new System.Drawing.Point(317, 346);
            this.cpuLabel.Name = "cpuLabel";
            this.cpuLabel.Size = new System.Drawing.Size(0, 13);
            this.cpuLabel.TabIndex = 8;
            // 
            // mryLabel
            // 
            this.mryLabel.AutoSize = true;
            this.mryLabel.Location = new System.Drawing.Point(428, 346);
            this.mryLabel.Name = "mryLabel";
            this.mryLabel.Size = new System.Drawing.Size(0, 13);
            this.mryLabel.TabIndex = 9;
            // 
            // appFinder
            // 
            this.appFinder.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.appFinder.Location = new System.Drawing.Point(172, 3);
            this.appFinder.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.appFinder.Name = "appFinder";
            this.appFinder.Size = new System.Drawing.Size(216, 20);
            this.appFinder.TabIndex = 10;
            this.appFinder.Text = "Enter application name";
            this.appFinder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.appFinder.TextChanged += new System.EventHandler(this.appFinder_TextChanged);
            // 
            // appFinderBtn
            // 
            this.appFinderBtn.Location = new System.Drawing.Point(384, 3);
            this.appFinderBtn.Name = "appFinderBtn";
            this.appFinderBtn.Size = new System.Drawing.Size(75, 23);
            this.appFinderBtn.TabIndex = 11;
            this.appFinderBtn.Text = "Start";
            this.appFinderBtn.UseVisualStyleBackColor = true;
            this.appFinderBtn.Click += new System.EventHandler(this.appFinderBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // fileBrowseBtn
            // 
            this.fileBrowseBtn.Image = ((System.Drawing.Image)(resources.GetObject("fileBrowseBtn.Image")));
            this.fileBrowseBtn.Location = new System.Drawing.Point(152, 3);
            this.fileBrowseBtn.Name = "fileBrowseBtn";
            this.fileBrowseBtn.Size = new System.Drawing.Size(23, 23);
            this.fileBrowseBtn.TabIndex = 12;
            this.fileBrowseBtn.UseVisualStyleBackColor = true;
            this.fileBrowseBtn.Click += new System.EventHandler(this.fileBrowseBtn_Click);
            // 
            // pauseResumeBtn
            // 
            this.pauseResumeBtn.Location = new System.Drawing.Point(550, 336);
            this.pauseResumeBtn.Name = "pauseResumeBtn";
            this.pauseResumeBtn.Size = new System.Drawing.Size(93, 23);
            this.pauseResumeBtn.TabIndex = 13;
            this.pauseResumeBtn.Text = "Pause/Resume";
            this.pauseResumeBtn.UseVisualStyleBackColor = true;
            this.pauseResumeBtn.Click += new System.EventHandler(this.pauseResumeBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 361);
            this.Controls.Add(this.pauseResumeBtn);
            this.Controls.Add(this.fileBrowseBtn);
            this.Controls.Add(this.appFinderBtn);
            this.Controls.Add(this.appFinder);
            this.Controls.Add(this.mryLabel);
            this.Controls.Add(this.cpuLabel);
            this.Controls.Add(this.termBtn);
            this.Controls.Add(this.taskObjListView);
            this.Controls.Add(this.procLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.taskObjListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label procLabel;
        private BrightIdeasSoftware.ObjectListView taskObjListView;
        private BrightIdeasSoftware.OLVColumn Task;
        private BrightIdeasSoftware.OLVColumn PID;
        private BrightIdeasSoftware.OLVColumn UID;
        private System.Windows.Forms.Button termBtn;
        private BrightIdeasSoftware.OLVColumn RSS;
        private System.Windows.Forms.Label cpuLabel;
        private System.Windows.Forms.Label mryLabel;
        private BrightIdeasSoftware.OLVColumn Priority;
        private System.Windows.Forms.TextBox appFinder;
        private System.Windows.Forms.Button appFinderBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button fileBrowseBtn;
        private System.Windows.Forms.Button pauseResumeBtn;
    }
}

