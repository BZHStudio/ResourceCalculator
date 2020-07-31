using Microsoft.Win32;
using ResourceCalculator.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResourceCalculator
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();

            label1.Text += Form1.versionProg.ToString();

            label2.Text += Application.ProductName;


            /*using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\ResourceCalculator"))*/
               /*labelReg.Text += key?.GetValue("DarkMode")?.ToString() == "true" ? true : false;*/

            var key = Registry.CurrentUser.CreateSubKey(@"Software\ResourceCalculator");

            if (key?.GetValue("DarkMode")?.ToString() == "true")
            {
                BackColor = Color.FromArgb(255, 29, 29, 29);
                label1.ForeColor = Color.FromArgb(255, 255, 255, 255);
                label2.ForeColor = Color.FromArgb(255, 255, 255, 255);

                pictureBox1.Image = Resources.github_white;

            }
            else if (key?.GetValue("DarkMode")?.ToString() == "false")
            {
                BackColor = Color.FromArgb(255, 255, 255, 255);
                label1.ForeColor = SystemColors.ControlText;
                label2.ForeColor = SystemColors.ControlText;

                pictureBox1.Image = Resources.github_dark;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы хотите перейти на сайт?", "Перейти на гитхаб", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Process.Start("https://github.com/BZHStudio/ResourceCalculator");
            }
        }

    }
}
