namespace NPCGenToXml
{
    partial class FormMain
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
            this.Button_FileRead = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listBox_aAreas = new System.Windows.Forms.ListBox();
            this.propertyGrid_aAreas = new System.Windows.Forms.PropertyGrid();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listBox_aResAreas = new System.Windows.Forms.ListBox();
            this.propertyGrid_aResAreas = new System.Windows.Forms.PropertyGrid();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listBox_aDynObjs = new System.Windows.Forms.ListBox();
            this.propertyGrid_aDynObjs = new System.Windows.Forms.PropertyGrid();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.listBox_aControllers = new System.Windows.Forms.ListBox();
            this.propertyGrid_aControllers = new System.Windows.Forms.PropertyGrid();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.listBox_aFlyAreas = new System.Windows.Forms.ListBox();
            this.propertyGrid_aFlyAreas = new System.Windows.Forms.PropertyGrid();
            this.Btn_FileSave = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button_FileRead
            // 
            this.Button_FileRead.Location = new System.Drawing.Point(12, 12);
            this.Button_FileRead.Name = "Button_FileRead";
            this.Button_FileRead.Size = new System.Drawing.Size(1151, 23);
            this.Button_FileRead.TabIndex = 0;
            this.Button_FileRead.Text = "Read File";
            this.Button_FileRead.UseVisualStyleBackColor = true;
            this.Button_FileRead.Click += new System.EventHandler(this.Button_FileRead_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(12, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1151, 562);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listBox_aAreas);
            this.tabPage1.Controls.Add(this.propertyGrid_aAreas);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1143, 536);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "m_aAreas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listBox_aAreas
            // 
            this.listBox_aAreas.FormattingEnabled = true;
            this.listBox_aAreas.Location = new System.Drawing.Point(6, 6);
            this.listBox_aAreas.Name = "listBox_aAreas";
            this.listBox_aAreas.Size = new System.Drawing.Size(245, 524);
            this.listBox_aAreas.TabIndex = 1;
            this.listBox_aAreas.SelectedIndexChanged += new System.EventHandler(this.listBox_aAreas_SelectedIndexChanged);
            // 
            // propertyGrid_aAreas
            // 
            this.propertyGrid_aAreas.Location = new System.Drawing.Point(257, 6);
            this.propertyGrid_aAreas.Name = "propertyGrid_aAreas";
            this.propertyGrid_aAreas.Size = new System.Drawing.Size(880, 524);
            this.propertyGrid_aAreas.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listBox_aResAreas);
            this.tabPage2.Controls.Add(this.propertyGrid_aResAreas);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1143, 536);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "m_aResAreas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listBox_aResAreas
            // 
            this.listBox_aResAreas.FormattingEnabled = true;
            this.listBox_aResAreas.Location = new System.Drawing.Point(6, 6);
            this.listBox_aResAreas.Name = "listBox_aResAreas";
            this.listBox_aResAreas.Size = new System.Drawing.Size(245, 524);
            this.listBox_aResAreas.TabIndex = 2;
            this.listBox_aResAreas.SelectedIndexChanged += new System.EventHandler(this.listBox_aResAreas_SelectedIndexChanged);
            // 
            // propertyGrid_aResAreas
            // 
            this.propertyGrid_aResAreas.Location = new System.Drawing.Point(257, 6);
            this.propertyGrid_aResAreas.Name = "propertyGrid_aResAreas";
            this.propertyGrid_aResAreas.Size = new System.Drawing.Size(880, 524);
            this.propertyGrid_aResAreas.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listBox_aDynObjs);
            this.tabPage3.Controls.Add(this.propertyGrid_aDynObjs);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1143, 536);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "m_aDynObjs";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listBox_aDynObjs
            // 
            this.listBox_aDynObjs.FormattingEnabled = true;
            this.listBox_aDynObjs.Location = new System.Drawing.Point(6, 6);
            this.listBox_aDynObjs.Name = "listBox_aDynObjs";
            this.listBox_aDynObjs.Size = new System.Drawing.Size(245, 524);
            this.listBox_aDynObjs.TabIndex = 2;
            this.listBox_aDynObjs.SelectedIndexChanged += new System.EventHandler(this.listBox_aDynObjs_SelectedIndexChanged);
            // 
            // propertyGrid_aDynObjs
            // 
            this.propertyGrid_aDynObjs.Location = new System.Drawing.Point(257, 6);
            this.propertyGrid_aDynObjs.Name = "propertyGrid_aDynObjs";
            this.propertyGrid_aDynObjs.Size = new System.Drawing.Size(880, 524);
            this.propertyGrid_aDynObjs.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.listBox_aControllers);
            this.tabPage4.Controls.Add(this.propertyGrid_aControllers);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1143, 536);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "m_aControllers";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // listBox_aControllers
            // 
            this.listBox_aControllers.FormattingEnabled = true;
            this.listBox_aControllers.Location = new System.Drawing.Point(6, 6);
            this.listBox_aControllers.Name = "listBox_aControllers";
            this.listBox_aControllers.Size = new System.Drawing.Size(245, 524);
            this.listBox_aControllers.TabIndex = 2;
            this.listBox_aControllers.SelectedIndexChanged += new System.EventHandler(this.listBox_aControllers_SelectedIndexChanged);
            // 
            // propertyGrid_aControllers
            // 
            this.propertyGrid_aControllers.Location = new System.Drawing.Point(257, 6);
            this.propertyGrid_aControllers.Name = "propertyGrid_aControllers";
            this.propertyGrid_aControllers.Size = new System.Drawing.Size(880, 524);
            this.propertyGrid_aControllers.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.listBox_aFlyAreas);
            this.tabPage5.Controls.Add(this.propertyGrid_aFlyAreas);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1143, 536);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "m_aFlyAreas";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // listBox_aFlyAreas
            // 
            this.listBox_aFlyAreas.FormattingEnabled = true;
            this.listBox_aFlyAreas.Location = new System.Drawing.Point(6, 6);
            this.listBox_aFlyAreas.Name = "listBox_aFlyAreas";
            this.listBox_aFlyAreas.Size = new System.Drawing.Size(245, 524);
            this.listBox_aFlyAreas.TabIndex = 2;
            this.listBox_aFlyAreas.SelectedIndexChanged += new System.EventHandler(this.listBox_aFlyAreas_SelectedIndexChanged);
            // 
            // propertyGrid_aFlyAreas
            // 
            this.propertyGrid_aFlyAreas.Location = new System.Drawing.Point(257, 6);
            this.propertyGrid_aFlyAreas.Name = "propertyGrid_aFlyAreas";
            this.propertyGrid_aFlyAreas.Size = new System.Drawing.Size(880, 524);
            this.propertyGrid_aFlyAreas.TabIndex = 0;
            // 
            // Btn_FileSave
            // 
            this.Btn_FileSave.Location = new System.Drawing.Point(12, 605);
            this.Btn_FileSave.Name = "Btn_FileSave";
            this.Btn_FileSave.Size = new System.Drawing.Size(1151, 23);
            this.Btn_FileSave.TabIndex = 2;
            this.Btn_FileSave.Text = "Save File";
            this.Btn_FileSave.UseVisualStyleBackColor = true;
            this.Btn_FileSave.Click += new System.EventHandler(this.Btn_FileSave_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 637);
            this.Controls.Add(this.Btn_FileSave);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Button_FileRead);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NPCGen Editor PW";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button_FileRead;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PropertyGrid propertyGrid_aAreas;
        private System.Windows.Forms.PropertyGrid propertyGrid_aResAreas;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.PropertyGrid propertyGrid_aDynObjs;
        private System.Windows.Forms.PropertyGrid propertyGrid_aControllers;
        private System.Windows.Forms.PropertyGrid propertyGrid_aFlyAreas;
        private System.Windows.Forms.ListBox listBox_aAreas;
        private System.Windows.Forms.ListBox listBox_aResAreas;
        private System.Windows.Forms.ListBox listBox_aDynObjs;
        private System.Windows.Forms.ListBox listBox_aControllers;
        private System.Windows.Forms.ListBox listBox_aFlyAreas;
        private System.Windows.Forms.Button Btn_FileSave;
    }
}

