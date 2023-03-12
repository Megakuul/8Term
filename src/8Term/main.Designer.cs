using ConEmu.WinForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace _8Term
{
    partial class main
    {
        /// <summary>
        /// Height of AppBar
        /// </summary>
        private int _AppBarHeigt { get; set; }

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

        /// <summary>
        /// Gets Triggered on Resize of Window
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            resizeMainTabControlr();
            if (this.WindowState == FormWindowState.Maximized)
                resizeTerminals();
        }

        /// <summary>
        /// Gets Triggered on ResizeEnd of Window
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            resizeTerminals();
        }

        /// <summary>
        /// This Resizes the ConEmu Consoles
        /// Note that it is not resizing until you stop resizing.
        /// This is done, because it uses a lot of GPU power if it dynamically resizes
        /// </summary>
        private void resizeTerminals()
        {
            if (ConsoleList != null)
            {
                foreach (ConEmuControl control in ConsoleList)
                {
                    control.Size = new Size(control.Parent.Width, control.Parent.Height);
                }
            }
        }

        /// <summary>
        /// Resizes the Tab Controlr
        /// </summary>
        private void resizeMainTabControlr()
        {
            mainTabControlr.Size = new Size(this.Size.Width, this.Size.Height - _AppBarHeigt);
        }

        /// <summary>
        /// Design Initialization from custom Components
        /// </summary>
        private void InitializeCustomComponent()
        {
            _AppBarHeigt = connectionBx.Height + 50;
            hostnameBx.Text = "Hostname";
            hostnameBx.ForeColor = Color.Gray;
            hostnameBx.Enter += HostnameBx_Enter;

            foreach (Control obj in connectionInfoBx.Controls)
            {
                if (obj is TextBox || obj is NumericUpDown)
                {
                    obj.Leave += Obj_Leave;
                }
            }

            connectionTree.AfterSelect += ConnectionTree_AfterSelect;
        }

        /// <summary>
        /// After selection of a Node, write it to the Buffer and updateInformation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectionTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LastSelectedNode = e.Node;
            updateInformation(e.Node);
        }

        /// <summary>
        /// On Leave of a Information Element, changeConnection and updateInformation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Obj_Leave(object sender, EventArgs e)
        {
            Control control = sender as Control;

            if (LastSelectedNode != null)
            {
                if (control != commandBx) {
                    changeConnection(LastSelectedNode, hostnameBx.Text, usernameBx.Text, passwordBx.Text, pemKeyBx.Text, (int)portBx.Value);
                } else {
                    changeConnection(LastSelectedNode, hostnameBx.Text, usernameBx.Text, passwordBx.Text, pemKeyBx.Text, (int)portBx.Value, commandBx.Text);
                }
            }
            updateInformation(LastSelectedNode);
        }
        /// <summary>
        /// Display a hintText
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HostnameBx_Enter(object sender, EventArgs e)
        {
            if (hostnameBx.Text == "Hostname")
            {
                hostnameBx.Text = "";
                hostnameBx.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Opens the FileBrowser 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectBtn_Click(object sender, EventArgs e)
        {
            selectBrowser.ShowDialog();
            pemKeyBx.Text = selectBrowser.FileName;
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainTabControlr = new TabControl();
            connectionTree = new TreeView();
            connectionBx = new GroupBox();
            connectionInfoBx = new GroupBox();
            commandBx = new TextBox();
            selectBtn = new Button();
            pemKeyBx = new TextBox();
            label2 = new Label();
            label1 = new Label();
            portBx = new NumericUpDown();
            label3 = new Label();
            portBxLbl = new Label();
            passwordBx = new TextBox();
            usernameBx = new TextBox();
            hostnameBx = new TextBox();
            selectBrowser = new OpenFileDialog();
            connectionBx.SuspendLayout();
            connectionInfoBx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)portBx).BeginInit();
            SuspendLayout();
            // 
            // mainTabControlr
            // 
            mainTabControlr.Dock = DockStyle.Top;
            mainTabControlr.Location = new Point(0, 0);
            mainTabControlr.Name = "mainTabControlr";
            mainTabControlr.SelectedIndex = 0;
            mainTabControlr.Size = new Size(1216, 357);
            mainTabControlr.TabIndex = 0;
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
            connectionBx.Controls.Add(connectionInfoBx);
            connectionBx.Controls.Add(connectionTree);
            connectionBx.Dock = DockStyle.Bottom;
            connectionBx.Location = new Point(0, 451);
            connectionBx.Name = "connectionBx";
            connectionBx.Size = new Size(1216, 200);
            connectionBx.TabIndex = 3;
            connectionBx.TabStop = false;
            connectionBx.Text = "Connections";
            // 
            // connectionInfoBx
            // 
            connectionInfoBx.Controls.Add(commandBx);
            connectionInfoBx.Controls.Add(selectBtn);
            connectionInfoBx.Controls.Add(pemKeyBx);
            connectionInfoBx.Controls.Add(label2);
            connectionInfoBx.Controls.Add(label1);
            connectionInfoBx.Controls.Add(portBx);
            connectionInfoBx.Controls.Add(label3);
            connectionInfoBx.Controls.Add(portBxLbl);
            connectionInfoBx.Controls.Add(passwordBx);
            connectionInfoBx.Controls.Add(usernameBx);
            connectionInfoBx.Controls.Add(hostnameBx);
            connectionInfoBx.Location = new Point(265, 12);
            connectionInfoBx.Name = "connectionInfoBx";
            connectionInfoBx.Size = new Size(263, 182);
            connectionInfoBx.TabIndex = 3;
            connectionInfoBx.TabStop = false;
            connectionInfoBx.Text = "Information";
            // 
            // commandBx
            // 
            commandBx.Location = new Point(23, 153);
            commandBx.MaxLength = 200;
            commandBx.Name = "commandBx";
            commandBx.Size = new Size(224, 23);
            commandBx.TabIndex = 12;
            // 
            // selectBtn
            // 
            selectBtn.Location = new Point(221, 115);
            selectBtn.Name = "selectBtn";
            selectBtn.Size = new Size(26, 23);
            selectBtn.TabIndex = 11;
            selectBtn.Text = "...";
            selectBtn.UseVisualStyleBackColor = true;
            selectBtn.Click += selectBtn_Click;
            // 
            // pemKeyBx
            // 
            pemKeyBx.Location = new Point(103, 115);
            pemKeyBx.MaxLength = 200;
            pemKeyBx.Name = "pemKeyBx";
            pemKeyBx.Size = new Size(112, 23);
            pemKeyBx.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 89);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 9;
            label2.Text = "password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 60);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 8;
            label1.Text = "username";
            // 
            // portBx
            // 
            portBx.Location = new Point(209, 22);
            portBx.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            portBx.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            portBx.Name = "portBx";
            portBx.Size = new Size(38, 23);
            portBx.TabIndex = 7;
            portBx.Value = new decimal(new int[] { 22, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 118);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 5;
            label3.Text = "PEM Key";
            // 
            // portBxLbl
            // 
            portBxLbl.AutoSize = true;
            portBxLbl.Location = new Point(174, 25);
            portBxLbl.Name = "portBxLbl";
            portBxLbl.Size = new Size(29, 15);
            portBxLbl.TabIndex = 4;
            portBxLbl.Text = "Port";
            // 
            // passwordBx
            // 
            passwordBx.Location = new Point(103, 86);
            passwordBx.MaxLength = 100;
            passwordBx.Name = "passwordBx";
            passwordBx.PasswordChar = '*';
            passwordBx.Size = new Size(144, 23);
            passwordBx.TabIndex = 2;
            // 
            // usernameBx
            // 
            usernameBx.Location = new Point(103, 57);
            usernameBx.MaxLength = 100;
            usernameBx.Name = "usernameBx";
            usernameBx.Size = new Size(144, 23);
            usernameBx.TabIndex = 1;
            // 
            // hostnameBx
            // 
            hostnameBx.ForeColor = Color.Gray;
            hostnameBx.Location = new Point(23, 22);
            hostnameBx.MaxLength = 100;
            hostnameBx.Name = "hostnameBx";
            hostnameBx.Size = new Size(145, 23);
            hostnameBx.TabIndex = 0;
            hostnameBx.Text = "Hostname";
            // 
            // selectBrowser
            // 
            selectBrowser.Filter = "PEM-Dateien|*.pem";
            // 
            // main
            // 
            ClientSize = new Size(1216, 651);
            Controls.Add(connectionBx);
            Controls.Add(mainTabControlr);
            Name = "main";
            Load += main_Load;
            connectionBx.ResumeLayout(false);
            connectionInfoBx.ResumeLayout(false);
            connectionInfoBx.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)portBx).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl mainTabControlr;
        private ToolStrip toolStipMain;
        private TreeView connectionTree;
        private GroupBox connectionBx;
        private GroupBox connectionInfoBx;
        private RichTextBox richTextBox1;
        private Label label3;
        private Label portBxLbl;
        private Label label1;
        private TextBox textBox3;
        private TextBox usernameBx;
        private TextBox hostnameBx;
        private TextBox passwordBx;
        private NumericUpDown portBx;
        private TextBox commandBx;
        private Button selectBtn;
        private TextBox pemKeyBx;
        private Label label2;
        private OpenFileDialog selectBrowser;
    }
}