using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WindowsForms.Properties;

namespace WindowsForms
{
	public partial class Form1 : Form
	{
		bool showDate;
		bool showControls;
		ChooseFont chooseFont;
		public Form1()
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.Manual;
			int startX = Screen.PrimaryScreen.Bounds.Width - this.Width - 25;
			int startY = 25;
			this.SetDesktopLocation(startX, startY);
			ControlsVisibility(false);
			showDate = false;
			showControls = false;
			Directory.SetCurrentDirectory("..\\..\\Fonts");
			chooseFont = new ChooseFont();
			label1.BackColor = Color.Black;
            label1.ForeColor = Settings.Default.Form1Color.IsEmpty ? Settings.Default.Form1Color : Color.Red;
            label1.Font = Settings.Default.Form1Font;
        }

        void ControlsVisibility(bool visible)
		{
			cbShowDate.Visible = visible;
			btnExit.Visible = visible;
			btnHideControls.Visible = visible;
			btnChooseFont.Visible = visible;
			this.ShowInTaskbar = visible;
			this.TransparencyKey = !visible ? SystemColors.Control : Color.White;
			this.FormBorderStyle = !visible ? FormBorderStyle.None : FormBorderStyle.Sizable;
			showControlsToolStripMenuItem.Checked = visible;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			label1.Text = DateTime.Now.ToString("hh:mm:ss tt");
			//label2.Text = DateTime.Now.ToString("yyyy.MM.dd ddd");
			//label2.Visible = cbShowDate.Checked;
			if (cbShowDate.Checked)
			{
				string date = DateTime.Now.ToString("yyyy.MM.dd ddd");
				label1.Text = $"{label1.Text}\n{date}";
			}
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
            Settings.Default.Form1Color = label1.ForeColor;
            Settings.Default.Form1Font = label1.Font;
            Settings.Default.Save();
            this.Close();
		}

		private void btnHideControls_Click(object sender, EventArgs e)
		{
			showControls = false;
			ControlsVisibility(showControls);
		}

		private void label1_MouseHover(object sender, EventArgs e)
		{
			ControlsVisibility(true);
		}

		private void showDateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			showDate = showDateToolStripMenuItem.Checked;
			cbShowDate.Checked = showDate;
		}

		private void showControlsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			showControls = showControlsToolStripMenuItem.Checked;
			ControlsVisibility(showControls);
		}

		private void btnChooseFont_Click(object sender, EventArgs e)
		{
			//chooseFont.NewFont = label1.Font;
			DialogResult result = chooseFont.ShowDialog(this);
			if (result == DialogResult.OK)
			{
				label1.Font = chooseFont.NewFont;
                label1.ForeColor = chooseFont.GetLabel1FontColor();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.Form1Color = label1.ForeColor;
			Settings.Default.Form1Font = label1.Font;
            Settings.Default.Save();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
			label1.ForeColor = Settings.Default.Form1Color;
			label1.Font = Settings.Default.Form1Font;
        }

        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                label1.ForeColor = colorDialog1.Color;
            }
        }

        private void backColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
			if (colorDialog1.ShowDialog(this) == DialogResult.OK) {
				label1.BackColor = colorDialog1.Color;
			}
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
