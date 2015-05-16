namespace WindowsFormsApplication2
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.windowinfoText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileText = new System.Windows.Forms.TextBox();
            this.fileread = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.STARTButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.prefixStrText = new System.Windows.Forms.TextBox();
            this.suffixStrText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.windowGet = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.nowTitleText = new System.Windows.Forms.Label();
            this.mainproc = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // windowinfoText
            // 
            this.windowinfoText.Location = new System.Drawing.Point(93, 22);
            this.windowinfoText.Name = "windowinfoText";
            this.windowinfoText.Size = new System.Drawing.Size(172, 21);
            this.windowinfoText.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "获取窗口：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "目标文件：";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // saveFileText
            // 
            this.saveFileText.Location = new System.Drawing.Point(93, 123);
            this.saveFileText.Name = "saveFileText";
            this.saveFileText.Size = new System.Drawing.Size(172, 21);
            this.saveFileText.TabIndex = 3;
            // 
            // fileread
            // 
            this.fileread.Location = new System.Drawing.Point(283, 121);
            this.fileread.Name = "fileread";
            this.fileread.Size = new System.Drawing.Size(75, 23);
            this.fileread.TabIndex = 4;
            this.fileread.Text = "浏览...";
            this.fileread.UseVisualStyleBackColor = true;
            this.fileread.Click += new System.EventHandler(this.fileread_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(283, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "获取...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // STARTButton
            // 
            this.STARTButton.Location = new System.Drawing.Point(24, 263);
            this.STARTButton.Name = "STARTButton";
            this.STARTButton.Size = new System.Drawing.Size(334, 53);
            this.STARTButton.TabIndex = 6;
            this.STARTButton.Text = "START";
            this.STARTButton.UseVisualStyleBackColor = true;
            this.STARTButton.Click += new System.EventHandler(this.STARTButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "前导字符：";
            // 
            // prefixStrText
            // 
            this.prefixStrText.Location = new System.Drawing.Point(93, 171);
            this.prefixStrText.Name = "prefixStrText";
            this.prefixStrText.Size = new System.Drawing.Size(265, 21);
            this.prefixStrText.TabIndex = 8;
            this.prefixStrText.Text = "Now Playing:   ";
            // 
            // suffixStrText
            // 
            this.suffixStrText.Location = new System.Drawing.Point(93, 218);
            this.suffixStrText.Name = "suffixStrText";
            this.suffixStrText.Size = new System.Drawing.Size(265, 21);
            this.suffixStrText.TabIndex = 9;
            this.suffixStrText.Text = "                         ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "后缀字符：";
            // 
            // windowGet
            // 
            this.windowGet.Location = new System.Drawing.Point(283, 46);
            this.windowGet.Name = "windowGet";
            this.windowGet.Size = new System.Drawing.Size(75, 23);
            this.windowGet.TabIndex = 13;
            this.windowGet.Text = "update";
            this.windowGet.UseVisualStyleBackColor = true;
            this.windowGet.Click += new System.EventHandler(this.windowGet_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "当前标题栏:";
            // 
            // nowTitleText
            // 
            this.nowTitleText.AutoSize = true;
            this.nowTitleText.Location = new System.Drawing.Point(99, 70);
            this.nowTitleText.Name = "nowTitleText";
            this.nowTitleText.Size = new System.Drawing.Size(53, 12);
            this.nowTitleText.TabIndex = 16;
            this.nowTitleText.Text = "未获取到";
            // 
            // mainproc
            // 
            this.mainproc.Interval = 1200;
            this.mainproc.Tick += new System.EventHandler(this.mainproc_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 328);
            this.Controls.Add(this.nowTitleText);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.windowGet);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.suffixStrText);
            this.Controls.Add(this.prefixStrText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.STARTButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.fileread);
            this.Controls.Add(this.saveFileText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.windowinfoText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "捕获标题栏到文件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox windowinfoText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox saveFileText;
        private System.Windows.Forms.Button fileread;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button STARTButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox prefixStrText;
        private System.Windows.Forms.TextBox suffixStrText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button windowGet;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label nowTitleText;
        private System.Windows.Forms.Timer mainproc;
    }
}

