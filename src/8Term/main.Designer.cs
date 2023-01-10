namespace _8Term
{
    partial class main
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
            this.mainTabControlr = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.conEmuControl1 = new ConEmu.WinForms.ConEmuControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.mainTabControlr.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTabControlr
            // 
            this.mainTabControlr.Controls.Add(this.tabPage1);
            this.mainTabControlr.Controls.Add(this.tabPage2);
            this.mainTabControlr.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainTabControlr.Location = new System.Drawing.Point(0, 0);
            this.mainTabControlr.Name = "mainTabControlr";
            this.mainTabControlr.SelectedIndex = 0;
            this.mainTabControlr.Size = new System.Drawing.Size(857, 357);
            this.mainTabControlr.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.conEmuControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(849, 329);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // conEmuControl1
            // 
            this.conEmuControl1.AutoStartInfo = null;
            this.conEmuControl1.IsStatusbarVisible = false;
            this.conEmuControl1.Location = new System.Drawing.Point(19, 6);
            this.conEmuControl1.MinimumSize = new System.Drawing.Size(1, 1);
            this.conEmuControl1.Name = "conEmuControl1";
            this.conEmuControl1.Size = new System.Drawing.Size(763, 283);
            this.conEmuControl1.TabIndex = 0;
            this.conEmuControl1.Text = "conEmuControl1";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(849, 329);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // main
            // 
            this.ClientSize = new System.Drawing.Size(857, 381);
            this.Controls.Add(this.mainTabControlr);
            this.Name = "main";
            this.Load += new System.EventHandler(this.main_Load);
            this.mainTabControlr.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl mainTabControlr;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ConEmu.WinForms.ConEmuControl conEmuControl1;
    }
}