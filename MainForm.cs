using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MenuLauncher
{
    public partial class MainForm : Form
    {
        public MainForm(Parameters parameters)
        {
            InitializeComponent();
            this.Parameters = parameters;
        }

        private Parameters Parameters;

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Hide();
            this.contextMenuStrip_menu.ShowImageMargin = this.Parameters.ShowIcons;

            foreach (FileInfo item in new DirectoryInfo(this.Parameters.DirectoryPath).GetFiles())
            {
                if (!item.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    ToolStripMenuItem menuItem = new ToolStripMenuItem();
                    menuItem.Text = Path.GetFileNameWithoutExtension(item.FullName);
                    menuItem.Tag = item.FullName;
                    menuItem.Click += this.MenuItem_Click;

                    if (this.Parameters.ShowIcons)
                        menuItem.Image = Icon.ExtractAssociatedIcon(item.FullName).ToBitmap();

                    this.contextMenuStrip_menu.Items.Add(menuItem);
                }
            }

            if (this.Parameters.InfoPartsBefore.Count > 0)
            {
                this.contextMenuStrip_menu.Items.Insert(0, new ToolStripSeparator());

                foreach (string item in this.Parameters.InfoPartsBefore)
                {
                    ToolStripMenuItem menuItem = new ToolStripMenuItem();
                    menuItem.Text = item;
                    menuItem.Enabled = false;
                    this.contextMenuStrip_menu.Items.Insert(0, menuItem);
                }
            }

            if (this.Parameters.InfoPartsBelow.Count > 0)
            {
                this.contextMenuStrip_menu.Items.Add(new ToolStripSeparator());

                foreach (string item in this.Parameters.InfoPartsBelow)
                {
                    ToolStripMenuItem menuItem = new ToolStripMenuItem();
                    menuItem.Text = item;
                    menuItem.Enabled = false;
                    this.contextMenuStrip_menu.Items.Add(menuItem);
                }
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.contextMenuStrip_menu.Show(Cursor.Position);
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = sender as ToolStripMenuItem;

            if (clickedItem != null)
            {
                Process.Start(clickedItem.Tag.ToString());
                Application.Exit();
            }
        }

        private void timer_exit_Tick(object sender, EventArgs e)
        {
            //If no context menu entry was clicked, the application would stay open forever...
            //This can not be done in ContextMenuStrip_Closed, because Closed is fired before Click...
            Application.Exit();
        }
    }
}
