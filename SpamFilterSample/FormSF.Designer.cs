namespace SpamFilterSample
{
	partial class FormSF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSF));
            this.txtOut = new System.Windows.Forms.RichTextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnTest1 = new System.Windows.Forms.Button();
            this.btnTest2 = new System.Windows.Forms.Button();
            this.btnTest3 = new System.Windows.Forms.Button();
            this.btnToFile = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msg1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msg2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msg3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOut
            // 
            this.txtOut.Location = new System.Drawing.Point(13, 42);
            this.txtOut.Name = "txtOut";
            this.txtOut.Size = new System.Drawing.Size(501, 352);
            this.txtOut.TabIndex = 0;
            this.txtOut.Text = "";
            this.txtOut.TextChanged += new System.EventHandler(this.txtOut_TextChanged);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(519, 40);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(93, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load Data";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnTest1
            // 
            this.btnTest1.Location = new System.Drawing.Point(519, 91);
            this.btnTest1.Name = "btnTest1";
            this.btnTest1.Size = new System.Drawing.Size(93, 23);
            this.btnTest1.TabIndex = 2;
            this.btnTest1.Text = "Message1";
            this.btnTest1.UseVisualStyleBackColor = true;
            this.btnTest1.Click += new System.EventHandler(this.btnTest1_Click);
            // 
            // btnTest2
            // 
            this.btnTest2.Location = new System.Drawing.Point(519, 120);
            this.btnTest2.Name = "btnTest2";
            this.btnTest2.Size = new System.Drawing.Size(93, 23);
            this.btnTest2.TabIndex = 3;
            this.btnTest2.Text = "Message2";
            this.btnTest2.UseVisualStyleBackColor = true;
            this.btnTest2.Click += new System.EventHandler(this.btnTest2_Click);
            // 
            // btnTest3
            // 
            this.btnTest3.Location = new System.Drawing.Point(519, 149);
            this.btnTest3.Name = "btnTest3";
            this.btnTest3.Size = new System.Drawing.Size(93, 23);
            this.btnTest3.TabIndex = 4;
            this.btnTest3.Text = "Message3";
            this.btnTest3.UseVisualStyleBackColor = true;
            this.btnTest3.Click += new System.EventHandler(this.btnTest3_Click);
            // 
            // btnToFile
            // 
            this.btnToFile.Location = new System.Drawing.Point(519, 197);
            this.btnToFile.Name = "btnToFile";
            this.btnToFile.Size = new System.Drawing.Size(93, 23);
            this.btnToFile.TabIndex = 6;
            this.btnToFile.Text = "ToFile";
            this.btnToFile.UseVisualStyleBackColor = true;
            this.btnToFile.Click += new System.EventHandler(this.btnToFile_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(624, 24);
            this.menuStrip1.TabIndex = 7;
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDataToolStripMenuItem,
            this.msg1ToolStripMenuItem,
            this.msg2ToolStripMenuItem,
            this.msg3ToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.menuToolStripMenuItem.Text = "&Menu";
            // 
            // loadDataToolStripMenuItem
            // 
            this.loadDataToolStripMenuItem.Name = "loadDataToolStripMenuItem";
            this.loadDataToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.loadDataToolStripMenuItem.Text = "&Load Data";
            this.loadDataToolStripMenuItem.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // msg1ToolStripMenuItem
            // 
            this.msg1ToolStripMenuItem.Name = "msg1ToolStripMenuItem";
            this.msg1ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.msg1ToolStripMenuItem.Text = "Message&1";
            this.msg1ToolStripMenuItem.Click += new System.EventHandler(this.btnTest1_Click);
            // 
            // msg2ToolStripMenuItem
            // 
            this.msg2ToolStripMenuItem.Name = "msg2ToolStripMenuItem";
            this.msg2ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.msg2ToolStripMenuItem.Text = "Message&2";
            this.msg2ToolStripMenuItem.Click += new System.EventHandler(this.btnTest2_Click);
            // 
            // msg3ToolStripMenuItem
            // 
            this.msg3ToolStripMenuItem.Name = "msg3ToolStripMenuItem";
            this.msg3ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.msg3ToolStripMenuItem.Text = "Message&3";
            this.msg3ToolStripMenuItem.Click += new System.EventHandler(this.btnTest3_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.aboutToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(114, 22);
            this.aboutToolStripMenuItem1.Text = "&About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 408);
            this.Controls.Add(this.btnToFile);
            this.Controls.Add(this.btnTest3);
            this.Controls.Add(this.btnTest2);
            this.Controls.Add(this.btnTest1);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtOut);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "BayesianSpamFilter";
           // this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RichTextBox txtOut;
		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.Button btnTest1;
		private System.Windows.Forms.Button btnTest2;
        private System.Windows.Forms.Button btnTest3;
        private System.Windows.Forms.Button btnToFile;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem msg1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem msg2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem msg3ToolStripMenuItem;
	}
}

