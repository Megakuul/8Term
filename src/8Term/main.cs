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
        private int _AppBarHeigt { get; set; }
        public main()
        {
            InitializeComponent();
        }

        List<ConEmuControl> ConsoleList = new List<ConEmuControl>();

        private void main_Load(object sender, EventArgs e)
        {
            _AppBarHeigt = connectionBx.Height + 50;
            loadConnections(JsonInterface.deserializeJsonConfig("conf.eterm"));
            initConsole(mainTabControlr, "Hallo2", null);
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
            mainTabControlr.Size = new Size(this.Size.Width, this.Size.Height - _AppBarHeigt);
        }
        private void loadConnections(JObject config)
        {
            connectionTree.Nodes.Clear();
            JObject Object = (JObject)config["Connections"];

            foreach (JProperty folder in Object.Properties())
            {
                var curNod = connectionTree.Nodes.Add((folder).Name);

                foreach (JToken connection in folder.Values())
                {
                    curNod.Nodes.Add(((JProperty)connection).Name);
                    //Attach Connection information to the Node with Node.Tag
                }
            }
            
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
