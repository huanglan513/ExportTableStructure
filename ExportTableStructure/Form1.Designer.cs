namespace ExportTableStructure
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
            this.btnExport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxUserName = new System.Windows.Forms.TextBox();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.lblDBName = new System.Windows.Forms.Label();
            this.cboDBName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxServerName = new System.Windows.Forms.TextBox();
            this.btnConnectTest = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSelectedFolder = new System.Windows.Forms.Button();
            this.tbxSelectedFolder = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(16, 324);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(116, 23);
            this.btnExport.TabIndex = 8;
            this.btnExport.Text = "导出表结构";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Visible = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(282, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(11, 9);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(77, 12);
            this.lblLogin.TabIndex = 5;
            this.lblLogin.Text = "登陆到服务器";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "用户名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "密码";
            // 
            // tbxUserName
            // 
            this.tbxUserName.Location = new System.Drawing.Point(77, 66);
            this.tbxUserName.Name = "tbxUserName";
            this.tbxUserName.Size = new System.Drawing.Size(161, 21);
            this.tbxUserName.TabIndex = 2;
            this.tbxUserName.Text = "NJCCAIUser";
            // 
            // tbxPassword
            // 
            this.tbxPassword.Location = new System.Drawing.Point(77, 93);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(161, 21);
            this.tbxPassword.TabIndex = 3;
            this.tbxPassword.Text = "njccaidbuser";
            this.tbxPassword.UseSystemPasswordChar = true;
            // 
            // lblDBName
            // 
            this.lblDBName.AutoSize = true;
            this.lblDBName.Location = new System.Drawing.Point(14, 164);
            this.lblDBName.Name = "lblDBName";
            this.lblDBName.Size = new System.Drawing.Size(101, 12);
            this.lblDBName.TabIndex = 10;
            this.lblDBName.Text = "选择一个数据库名";
            // 
            // cboDBName
            // 
            this.cboDBName.FormattingEnabled = true;
            this.cboDBName.Location = new System.Drawing.Point(12, 190);
            this.cboDBName.Name = "cboDBName";
            this.cboDBName.Size = new System.Drawing.Size(258, 20);
            this.cboDBName.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "服务器名称";
            // 
            // tbxServerName
            // 
            this.tbxServerName.Location = new System.Drawing.Point(77, 38);
            this.tbxServerName.Name = "tbxServerName";
            this.tbxServerName.Size = new System.Drawing.Size(161, 21);
            this.tbxServerName.TabIndex = 1;
            this.tbxServerName.Text = "10.9.0.26";
            // 
            // btnConnectTest
            // 
            this.btnConnectTest.Location = new System.Drawing.Point(16, 120);
            this.btnConnectTest.Name = "btnConnectTest";
            this.btnConnectTest.Size = new System.Drawing.Size(75, 23);
            this.btnConnectTest.TabIndex = 4;
            this.btnConnectTest.Text = "测试服务器";
            this.btnConnectTest.UseVisualStyleBackColor = true;
            this.btnConnectTest.Click += new System.EventHandler(this.btnConnectTest_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "请选择导出至文件夹";
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog1.SelectedPath = "D:";
            // 
            // btnSelectedFolder
            // 
            this.btnSelectedFolder.Location = new System.Drawing.Point(12, 232);
            this.btnSelectedFolder.Name = "btnSelectedFolder";
            this.btnSelectedFolder.Size = new System.Drawing.Size(111, 23);
            this.btnSelectedFolder.TabIndex = 6;
            this.btnSelectedFolder.Text = "选择导出至文件夹";
            this.btnSelectedFolder.UseVisualStyleBackColor = true;
            this.btnSelectedFolder.Click += new System.EventHandler(this.btnSelectedFolder_Click);
            // 
            // tbxSelectedFolder
            // 
            this.tbxSelectedFolder.Location = new System.Drawing.Point(12, 261);
            this.tbxSelectedFolder.Name = "tbxSelectedFolder";
            this.tbxSelectedFolder.Size = new System.Drawing.Size(256, 21);
            this.tbxSelectedFolder.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 390);
            this.Controls.Add(this.tbxSelectedFolder);
            this.Controls.Add(this.btnSelectedFolder);
            this.Controls.Add(this.btnConnectTest);
            this.Controls.Add(this.tbxServerName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboDBName);
            this.Controls.Add(this.lblDBName);
            this.Controls.Add(this.tbxPassword);
            this.Controls.Add(this.tbxUserName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExport);
            this.Name = "Form1";
            this.Text = "导出表结构到文件夹";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxUserName;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.Label lblDBName;
        private System.Windows.Forms.ComboBox cboDBName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxServerName;
        private System.Windows.Forms.Button btnConnectTest;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnSelectedFolder;
        private System.Windows.Forms.TextBox tbxSelectedFolder;
    }
}

