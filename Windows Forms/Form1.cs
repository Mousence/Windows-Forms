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

namespace Windows_Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Width = this.Width - 10;
            label2.Width = this.Width - 10;
        }
        void ControlsVisibility(bool visible) {
            cbShowDate.Checked = visible;
            btnExit.Visible = visible;
            btnHideControls.Visible = visible;
            this.ShowInTaskbar = visible;
            this.TransparencyKey = !visible ? SystemColors.Control : Color.White;
            this.FormBorderStyle = !visible ? FormBorderStyle.None : FormBorderStyle.Sizable;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("hh:mm:ss tt"); //tt - 24 hour format
            label2.Text = DateTime.Now.ToString("yyyy.MM.dd ddd"); //ddd - Day of the week
            label2.Visible = cbShowDate.Checked;
        }
        private void label1_MouseHover(object sender, EventArgs e)
        {
            ControlsVisibility(true);
        }

        private void btnHideControls_Click_1(object sender, EventArgs e)
        {
            ControlsVisibility(false);
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
