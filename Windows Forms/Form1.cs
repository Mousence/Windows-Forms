using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows_Forms.Properties;

namespace Windows_Forms
{
    public partial class Form1 : Form
    {
        private NotifyIcon trayIcon;

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            int startX = Screen.PrimaryScreen.Bounds.Width - this.Width ;
            int startY = 25;
            this.SetDesktopLocation(startX, startY);
            ControlsVisibility(false);

            trayIcon = new NotifyIcon()
            {
                Icon = new Icon("C:\\Users\\79141\\source\\repos\\WindowsForms\\Windows Forms\\Clock.ico"),
                ContextMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("Show controls", label1_MouseDoubleClick),
                new MenuItem("Show date", cbShowDate_Click),
                new MenuItem("Exit", btnExit_Click)
            }),
                Visible = true
            };

        }
        void ControlsVisibility(bool visible) {
            cbShowDate.Visible = visible;
            btnExit.Visible = visible;
            btnHideControls.Visible = visible;
            this.ShowInTaskbar = visible;
            this.TransparencyKey = !visible ? SystemColors.Control : Color.White;
            this.FormBorderStyle = !visible ? FormBorderStyle.None : FormBorderStyle.Sizable;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("hh:mm:ss tt"); //tt - 24 hour format
            //label2.Text = DateTime.Now.ToString("yyyy.MM.dd ddd"); //ddd - Day of the week
            if (cbShowDate.Checked) {
                string date = DateTime.Now.ToString("yyyy.MM.dd ddd");
                label1.Text = $"{label1.Text}\n{date}";
            }
        }
        private void label1_MouseDoubleClick(object sender, EventArgs e)
        {
            ControlsVisibility(true);
        }
        private void btnHideControls_Click_1(object sender, EventArgs e)
        {
            ControlsVisibility(false);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// 
        private void cbShowDate_Click(object sender, EventArgs e)
        {
            ControlsVisibility(!cbShowDate.Checked);
        }
    }
}
