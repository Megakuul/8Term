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

namespace _8Term
{
    public partial class main : Form
    {
        /// <summary>
        /// Configuration variable
        /// </summary>
        private JObject _ConfigObj;

        /// <summary>
        /// Buffer for last selected Node
        /// </summary>
        public TreeNode LastSelectedNode;

        /// <summary>
        /// List of current active Consoles
        /// </summary>
        List<ConEmuControl> ConsoleList = new List<ConEmuControl>();

        public main()
        {
            InitializeComponent();
            InitializeCustomComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            _ConfigObj = JsonInterface.deserializeJsonConfig("conf.eterm");
            loadConnections(_ConfigObj);
            initConsole(mainTabControlr, "Taa", null);
        }

        /// <summary>
        /// Initializes a new Console (Tab)
        /// </summary>
        /// <param name="tabControl">Tabcontroller</param>
        /// <param name="tabTitle">Tab Title</param>
        /// <param name="startupCommand">Startup Command</param>
        /// <returns></returns>
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

        /// <summary>
        /// Loads connection configuration to the connectionTree
        /// </summary>
        /// <param name="config">Configuration Variable</param>
        private void loadConnections(JObject config)
        {
            connectionTree.Nodes.Clear();
            JObject Object = (JObject)config["Connections"];

            foreach (JProperty folder in Object.Properties())
            {
                var curFoldNod = connectionTree.Nodes.Add(folder.Name);

                foreach (JToken connection in folder.Values())
                {
                    var curConNod = curFoldNod.Nodes.Add(((JProperty)connection).Name);
                    JToken subCon = ((JProperty)connection).Value;
                    curConNod.Tag = new {
                        constr = subCon.SelectToken("constr") ?? "",
                        hostname = subCon.SelectToken("hostname") ?? "",
                        username = subCon.SelectToken("username") ?? "",
                        password = subCon.SelectToken("password") ?? "",
                        keyfile = subCon.SelectToken("keyfile") ?? "",
                        port = subCon.SelectToken("port") ?? 22
                    };
                }
            }
        }

        /// <summary>
        /// The opposite of loadConnections, loads the configuration from the connectionTree
        /// </summary>
        /// <param name="config">Reference to Configuration Variable</param>
        private void saveConnections(ref JObject config)
        {
            JObject tempFolders = new JObject();

            foreach (TreeNode folderNod in connectionTree.Nodes)
            {
                JObject tempConnections = new JObject();
                foreach (TreeNode conNod in folderNod.Nodes)
                {
                    JObject tempInformation = new JObject();

                    dynamic tag = conNod.Tag;

                    tempInformation.Add("constr", tag.constr);
                    tempInformation.Add("hostname", tag.hostname);
                    tempInformation.Add("username", tag.username);
                    tempInformation.Add("keyfile", tag.keyfile);
                    tempInformation.Add("port", tag.port);

                    tempConnections.Add(conNod.Text, tempInformation);
                }
                tempFolders.Add(folderNod.Text, tempConnections);
            }

            config["Connections"] = tempFolders;
        }

        /// <summary>
        /// Changes the connectionTree Tags of the passed Node.
        /// This will also trigger saveConnections() and save the connectionTree to the Configuration Variable
        /// </summary>
        /// <param name="node"></param>
        /// <param name="hostname"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="keyfile"></param>
        /// <param name="port"></param>
        /// <param name="command"></param>
        private void changeConnection(TreeNode node, string hostname, string username, string password, string keyfile, int port, string command=null)
        {
            string hostname_pref = hostname == "" || hostname == "Hostname" ? "" : $"-h {hostname} ";
            string username_pref = username == "" ? "" : $"-u {username} ";
            string password_pref = password == "" ? "" : $"-x {password} ";
            string keyfile_pref = keyfile == "" ? "" : $"-k {keyfile} ";

            string commandStr;
            if (command == null)
            {
                commandStr = $"MSKConnect {hostname_pref}{username_pref}{password_pref}{keyfile_pref}-p {port}";
            } else
            {
                commandStr = command;
            }
            node.Tag = new {
                constr = commandStr,
                hostname = hostname,
                username = username,
                password = password,
                keyfile = keyfile,
                port = port
            };
            saveConnections(ref _ConfigObj);
        }

        /// <summary>
        /// Updates the Textboxes from the Information Panel
        /// It takes the values from the Tag of the Node
        /// </summary>
        /// <param name="Node"></param>
        private void updateInformation(TreeNode Node)
        {
            hostnameBx.Text = ((dynamic)Node?.Tag)?.hostname ?? "";

            if (string.IsNullOrEmpty(hostnameBx.Text) || hostnameBx.Text == "Hostname")
            {
                hostnameBx.Text = "Hostname";
                hostnameBx.ForeColor = Color.Gray;
            } else {
                hostnameBx.ForeColor = Color.Black;
            }

            usernameBx.Text = ((dynamic)Node?.Tag)?.username ?? "";
            passwordBx.Text = ((dynamic)Node?.Tag)?.password ?? "";
            pemKeyBx.Text = ((dynamic)Node?.Tag)?.keyfile ?? "";
            commandBx.Text = ((dynamic)Node?.Tag)?.constr ?? "";
            portBx.Value = Convert.ToDecimal(((dynamic)Node?.Tag)?.port ?? 22);
        }
    }
}
