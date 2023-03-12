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
            mainTabControlr = new TabControl();
            tabPage1 = new TabPage();
            conEmuControl1 = new ConEmu.WinForms.ConEmuControl();
            tabPage2 = new TabPage();
            connectionTree = new TreeView();
            connectionBx = new GroupBox();
            mainTabControlr.SuspendLayout();
            tabPage1.SuspendLayout();
            connectionBx.SuspendLayout();
            SuspendLayout();
            // 
            // mainTabControlr
            // 
            mainTabControlr.Controls.Add(tabPage1);
            mainTabControlr.Controls.Add(tabPage2);
            mainTabControlr.Dock = DockStyle.Top;
            mainTabControlr.Location = new Point(0, 0);
            mainTabControlr.Name = "mainTabControlr";
            mainTabControlr.SelectedIndex = 0;
            mainTabControlr.Size = new Size(1216, 357);
            mainTabControlr.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(conEmuControl1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1208, 329);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // conEmuControl1
            // 
            conEmuControl1.AutoStartInfo = null;
            conEmuControl1.IsStatusbarVisible = false;
            conEmuControl1.Location = new Point(19, 6);
            conEmuControl1.MinimumSize = new Size(1, 1);
            conEmuControl1.Name = "conEmuControl1";
            conEmuControl1.Size = new Size(763, 283);
            conEmuControl1.TabIndex = 0;
            conEmuControl1.Text = "conEmuControl1";
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1208, 329);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // connectionTree
            // 
            connectionTree.Location = new Point(12, 22);
            connectionTree.Name = "connectionTree";
            connectionTree.Size = new Size(247, 172);
            connectionTree.TabIndex = 2;
            // 
            // connectionBx
            // 
            connectionBx.Controls.Add(connectionTree);
            connectionBx.Dock = DockStyle.Bottom;
            connectionBx.Location = new Point(0, 451);
            connectionBx.Name = "connectionBx";
            connectionBx.Size = new Size(1216, 200);
            connectionBx.TabIndex = 3;
            connectionBx.TabStop = false;
            connectionBx.Text = "Connections";
            // 
            // main
            // 
            ClientSize = new Size(1216, 651);
            Controls.Add(connectionBx);
            Controls.Add(mainTabControlr);
            Name = "main";
            Load += main_Load;
            mainTabControlr.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            connectionBx.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl mainTabControlr;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ConEmu.WinForms.ConEmuControl conEmuControl1;
        private ToolStrip toolStipMain;
        private TreeView connectionTree;
        private GroupBox connectionBx;
    }
}