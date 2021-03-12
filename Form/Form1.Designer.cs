namespace RAM_to_PKX_Rip
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
            this.genSelect = new System.Windows.Forms.GroupBox();
            this.Gen2SW97 = new System.Windows.Forms.RadioButton();
            this.Gen3 = new System.Windows.Forms.RadioButton();
            this.Gen6 = new System.Windows.Forms.RadioButton();
            this.Gen5 = new System.Windows.Forms.RadioButton();
            this.Gen4 = new System.Windows.Forms.RadioButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.OpenFileBTN = new System.Windows.Forms.Button();
            this.OpenFileTXB = new System.Windows.Forms.TextBox();
            this.Note = new System.Windows.Forms.Label();
            this.Rip = new System.Windows.Forms.Button();
            this.Info = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Build = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Save_Button = new System.Windows.Forms.Button();
            this.Summary = new System.Windows.Forms.Label();
            this.PName = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.Label();
            this.SID = new System.Windows.Forms.Label();
            this.Move1 = new System.Windows.Forms.Label();
            this.Move2 = new System.Windows.Forms.Label();
            this.Move3 = new System.Windows.Forms.Label();
            this.Move4 = new System.Windows.Forms.Label();
            this.RipProgressBar = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Icon = new System.Windows.Forms.PictureBox();
            this.genSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Icon)).BeginInit();
            this.SuspendLayout();
            // 
            // genSelect
            // 
            this.genSelect.Controls.Add(this.Gen2SW97);
            this.genSelect.Controls.Add(this.Gen3);
            this.genSelect.Controls.Add(this.Gen6);
            this.genSelect.Controls.Add(this.Gen5);
            this.genSelect.Controls.Add(this.Gen4);
            this.genSelect.Location = new System.Drawing.Point(0, 0);
            this.genSelect.Name = "genSelect";
            this.genSelect.Size = new System.Drawing.Size(123, 141);
            this.genSelect.TabIndex = 0;
            this.genSelect.TabStop = false;
            this.genSelect.Text = "Select Generation";
            // 
            // Gen2SW97
            // 
            this.Gen2SW97.AutoSize = true;
            this.Gen2SW97.Location = new System.Drawing.Point(6, 107);
            this.Gen2SW97.Name = "Gen2SW97";
            this.Gen2SW97.Size = new System.Drawing.Size(96, 17);
            this.Gen2SW97.TabIndex = 4;
            this.Gen2SW97.TabStop = true;
            this.Gen2SW97.Text = "Gen 2 Beta \'97";
            this.Gen2SW97.UseVisualStyleBackColor = true;
            this.Gen2SW97.CheckedChanged += new System.EventHandler(this.Gen2SW97_CheckedChanged);
            // 
            // Gen3
            // 
            this.Gen3.AutoSize = true;
            this.Gen3.Location = new System.Drawing.Point(6, 15);
            this.Gen3.Name = "Gen3";
            this.Gen3.Size = new System.Drawing.Size(54, 17);
            this.Gen3.TabIndex = 0;
            this.Gen3.TabStop = true;
            this.Gen3.Text = "Gen 3";
            this.Gen3.UseVisualStyleBackColor = true;
            this.Gen3.CheckedChanged += new System.EventHandler(this.Gen3_CheckedChanged);
            // 
            // Gen6
            // 
            this.Gen6.AutoSize = true;
            this.Gen6.Location = new System.Drawing.Point(6, 84);
            this.Gen6.Name = "Gen6";
            this.Gen6.Size = new System.Drawing.Size(54, 17);
            this.Gen6.TabIndex = 3;
            this.Gen6.TabStop = true;
            this.Gen6.Text = "Gen 6";
            this.Gen6.UseVisualStyleBackColor = true;
            this.Gen6.CheckedChanged += new System.EventHandler(this.Gen6_CheckedChanged);
            // 
            // Gen5
            // 
            this.Gen5.AutoSize = true;
            this.Gen5.Location = new System.Drawing.Point(6, 61);
            this.Gen5.Name = "Gen5";
            this.Gen5.Size = new System.Drawing.Size(54, 17);
            this.Gen5.TabIndex = 2;
            this.Gen5.TabStop = true;
            this.Gen5.Text = "Gen 5";
            this.Gen5.UseVisualStyleBackColor = true;
            this.Gen5.CheckedChanged += new System.EventHandler(this.Gen5_CheckedChanged);
            // 
            // Gen4
            // 
            this.Gen4.AutoSize = true;
            this.Gen4.Location = new System.Drawing.Point(6, 38);
            this.Gen4.Name = "Gen4";
            this.Gen4.Size = new System.Drawing.Size(54, 17);
            this.Gen4.TabIndex = 1;
            this.Gen4.TabStop = true;
            this.Gen4.Text = "Gen 4";
            this.Gen4.UseVisualStyleBackColor = true;
            this.Gen4.CheckedChanged += new System.EventHandler(this.Gen4_CheckedChanged);
            // 
            // OpenFileBTN
            // 
            this.OpenFileBTN.Location = new System.Drawing.Point(129, 20);
            this.OpenFileBTN.Name = "OpenFileBTN";
            this.OpenFileBTN.Size = new System.Drawing.Size(75, 23);
            this.OpenFileBTN.TabIndex = 1;
            this.OpenFileBTN.Text = "Open File";
            this.OpenFileBTN.UseVisualStyleBackColor = true;
            this.OpenFileBTN.Click += new System.EventHandler(this.OpenFileBTN_Click);
            // 
            // OpenFileTXB
            // 
            this.OpenFileTXB.Location = new System.Drawing.Point(210, 23);
            this.OpenFileTXB.Name = "OpenFileTXB";
            this.OpenFileTXB.Size = new System.Drawing.Size(142, 20);
            this.OpenFileTXB.TabIndex = 2;
            // 
            // Note
            // 
            this.Note.AutoSize = true;
            this.Note.Location = new System.Drawing.Point(126, 104);
            this.Note.Name = "Note";
            this.Note.Size = new System.Drawing.Size(33, 13);
            this.Note.TabIndex = 3;
            this.Note.Text = "Note:";
            // 
            // Rip
            // 
            this.Rip.Location = new System.Drawing.Point(129, 49);
            this.Rip.Name = "Rip";
            this.Rip.Size = new System.Drawing.Size(75, 23);
            this.Rip.TabIndex = 4;
            this.Rip.Text = "Rip";
            this.Rip.UseVisualStyleBackColor = true;
            this.Rip.Click += new System.EventHandler(this.Rip_Click);
            // 
            // Info
            // 
            this.Info.AutoSize = true;
            this.Info.Location = new System.Drawing.Point(126, 117);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(10, 13);
            this.Info.TabIndex = 5;
            this.Info.Text = " ";
            // 
            // Build
            // 
            this.Build.AutoSize = true;
            this.Build.Location = new System.Drawing.Point(278, 267);
            this.Build.Name = "Build";
            this.Build.Size = new System.Drawing.Size(84, 13);
            this.Build.TabIndex = 32;
            this.Build.Text = "Build: 20210312";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(210, 78);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(142, 21);
            this.comboBox1.TabIndex = 59;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Save_Button
            // 
            this.Save_Button.Enabled = false;
            this.Save_Button.Location = new System.Drawing.Point(129, 78);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(75, 23);
            this.Save_Button.TabIndex = 60;
            this.Save_Button.Text = "Save PKMN";
            this.Save_Button.UseVisualStyleBackColor = true;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // Summary
            // 
            this.Summary.AutoSize = true;
            this.Summary.Location = new System.Drawing.Point(3, 206);
            this.Summary.Name = "Summary";
            this.Summary.Size = new System.Drawing.Size(76, 13);
            this.Summary.TabIndex = 61;
            this.Summary.Text = "Pokemon Info:";
            // 
            // PName
            // 
            this.PName.AutoSize = true;
            this.PName.Location = new System.Drawing.Point(3, 219);
            this.PName.Name = "PName";
            this.PName.Size = new System.Drawing.Size(25, 13);
            this.PName.TabIndex = 62;
            this.PName.Text = "???";
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.Location = new System.Drawing.Point(3, 232);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(30, 13);
            this.ID.TabIndex = 63;
            this.ID.Text = "ID: 0";
            // 
            // SID
            // 
            this.SID.AutoSize = true;
            this.SID.Location = new System.Drawing.Point(3, 245);
            this.SID.Name = "SID";
            this.SID.Size = new System.Drawing.Size(37, 13);
            this.SID.TabIndex = 64;
            this.SID.Text = "SID: 0";
            // 
            // Move1
            // 
            this.Move1.AutoSize = true;
            this.Move1.Location = new System.Drawing.Point(3, 258);
            this.Move1.Name = "Move1";
            this.Move1.Size = new System.Drawing.Size(81, 13);
            this.Move1.TabIndex = 65;
            this.Move1.Text = "Move 1: (None)";
            // 
            // Move2
            // 
            this.Move2.AutoSize = true;
            this.Move2.Location = new System.Drawing.Point(126, 258);
            this.Move2.Name = "Move2";
            this.Move2.Size = new System.Drawing.Size(81, 13);
            this.Move2.TabIndex = 66;
            this.Move2.Text = "Move 2: (None)";
            // 
            // Move3
            // 
            this.Move3.AutoSize = true;
            this.Move3.Location = new System.Drawing.Point(3, 271);
            this.Move3.Name = "Move3";
            this.Move3.Size = new System.Drawing.Size(81, 13);
            this.Move3.TabIndex = 67;
            this.Move3.Text = "Move 3: (None)";
            // 
            // Move4
            // 
            this.Move4.AutoSize = true;
            this.Move4.Location = new System.Drawing.Point(126, 271);
            this.Move4.Name = "Move4";
            this.Move4.Size = new System.Drawing.Size(81, 13);
            this.Move4.TabIndex = 68;
            this.Move4.Text = "Move 4: (None)";
            // 
            // RipProgressBar
            // 
            this.RipProgressBar.Location = new System.Drawing.Point(210, 49);
            this.RipProgressBar.Name = "RipProgressBar";
            this.RipProgressBar.Size = new System.Drawing.Size(142, 23);
            this.RipProgressBar.TabIndex = 70;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Icon
            // 
            this.Icon.Image = ((System.Drawing.Image)(resources.GetObject("Icon.Image")));
            this.Icon.Location = new System.Drawing.Point(6, 147);
            this.Icon.Name = "Icon";
            this.Icon.Size = new System.Drawing.Size(68, 56);
            this.Icon.TabIndex = 69;
            this.Icon.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 289);
            this.Controls.Add(this.RipProgressBar);
            this.Controls.Add(this.Icon);
            this.Controls.Add(this.Move4);
            this.Controls.Add(this.Move3);
            this.Controls.Add(this.Move2);
            this.Controls.Add(this.Move1);
            this.Controls.Add(this.SID);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.PName);
            this.Controls.Add(this.Summary);
            this.Controls.Add(this.Save_Button);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Build);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.Rip);
            this.Controls.Add(this.Note);
            this.Controls.Add(this.OpenFileTXB);
            this.Controls.Add(this.OpenFileBTN);
            this.Controls.Add(this.genSelect);
            this.Name = "Form1";
            this.Text = "RAM to PKX Ripper";
            this.genSelect.ResumeLayout(false);
            this.genSelect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox genSelect;
        private System.Windows.Forms.RadioButton Gen5;
        private System.Windows.Forms.RadioButton Gen4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button OpenFileBTN;
        private System.Windows.Forms.TextBox OpenFileTXB;
        private System.Windows.Forms.Label Note;
        private System.Windows.Forms.Button Rip;
        private System.Windows.Forms.Label Info;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label Build;
        private System.Windows.Forms.RadioButton Gen6;
        private System.Windows.Forms.RadioButton Gen3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button Save_Button;
        private System.Windows.Forms.Label Summary;
        private System.Windows.Forms.Label PName;
        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.Label SID;
        private System.Windows.Forms.Label Move1;
        private System.Windows.Forms.Label Move2;
        private System.Windows.Forms.Label Move3;
        private System.Windows.Forms.Label Move4;
        private System.Windows.Forms.PictureBox Icon;
        private System.Windows.Forms.RadioButton Gen2SW97;
        private System.Windows.Forms.ProgressBar RipProgressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

