using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _8Term.Properties;
using _8Term.Config;
using ConEmu.WinForms;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Reflection.Metadata.Ecma335;

namespace _8Term
{
    public partial class main : Form
    {
        private int _AppBarHeigt { get; } = 100;
        public main()
        {
            InitializeComponent();
        }

        List<ConEmuControl> ConsoleList = new List<ConEmuControl>();

        private void main_Load(object sender, EventArgs e)
        {
            
            //loadTabs(JsonInterface.deserializeJsonConfig("asdf"));
            initConsole(mainTabControlr, "Hallo", "explorer.exe");
            initConsole(mainTabControlr, "Hallo2", null); 
            initConsole(mainTabControlr, "Hallo3", "cmd");
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            resizeMainTabControlr();
            if (this.WindowState == FormWindowState.Maximized)
                resizeTerminals();
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            resizeTerminals();
        }

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
        private void resizeMainTabControlr()
        {
            mainTabControlr.Size = new Size(this.Size.Width, this.Size.Height-_AppBarHeigt);
        }

        private void loadTabs(JObject config)
        {
            foreach (ConEmuControl control in ConsoleList)
            {
                control.RunningSession.CloseConsoleEmulator();
            }
            ConsoleList.Clear();

            JObject Object = (JObject)config["Tabs"];

            MessageBox.Show(Object.HasValues.ToString());
        }

        private bool initConsole(TabControl tabControl, string tabTitle, string? startupCommand)
        {
            TabPage tabPage = new TabPage(tabTitle);

            ConEmuControl term = new ConEmuControl()
            {
                AutoStartInfo = null,
                Size = new Size(tabControl.Width, tabControl.Height)
            };

            term.IsStatusbarVisible = false;

            ConsoleList.Add(term);

            tabPage.Controls.Add(term);
            tabControl.TabPages.Add(tabPage);

            string tempStartupCommand = startupCommand != null ? startupCommand : "powershell";

            term.Start(new ConEmuStartInfo()
            {
                ConsoleProcessCommandLine = $"{tempStartupCommand}",
                StartupDirectory = Application.StartupPath,
            });

            return true;
        }
    }
}
