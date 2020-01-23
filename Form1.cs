using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ResourceCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\ResourceCalculator"))
                checkBoxDarkMode.Checked = key?.GetValue("DarkMode")?.ToString() == "true" ? true : false;

            if (checkBoxDarkMode.Checked == true)
            {
                BackColor = Color.FromArgb(255, 29, 29, 29);

                Label1.ForeColor = Color.FromArgb(255, 245, 245, 245);
                label2.ForeColor = Color.FromArgb(255, 245, 245, 245);
                label3.ForeColor = Color.FromArgb(255, 245, 245, 245);
                label4.ForeColor = Color.FromArgb(255, 245, 245, 245);
                label5.ForeColor = Color.FromArgb(255, 245, 245, 245);
                label6.ForeColor = Color.FromArgb(255, 245, 245, 245);
                LabelMode.ForeColor = Color.FromArgb(255, 245, 245, 245);
                LabelPaluch5.ForeColor = Color.FromArgb(255, 245, 245, 245);
                LabelPaluch4.ForeColor = Color.FromArgb(255, 245, 245, 245);
                LabelPaluch3.ForeColor = Color.FromArgb(255, 245, 245, 245);
                LabelPaluch2.ForeColor = Color.FromArgb(255, 245, 245, 245);
                LabelResult5.ForeColor = Color.FromArgb(255, 245, 245, 245);
                LabelResult4.ForeColor = Color.FromArgb(255, 245, 245, 245);
                LabelResult3.ForeColor = Color.FromArgb(255, 245, 245, 245);
                LabelResult2.ForeColor = Color.FromArgb(255, 245, 245, 245);

                Button1.BackColor = Color.FromArgb(255, 29, 29, 29);
                Button1.ForeColor = Color.FromArgb(255, 255, 255, 255);
                ButtonClean.BackColor = Color.FromArgb(255, 29, 29, 29);
                ButtonClean.ForeColor = Color.FromArgb(255, 255, 255, 255);

                ComboBox1.BackColor = Color.FromArgb(255, 29, 29, 29);
                ComboBox1.ForeColor = Color.FromArgb(255, 245, 245, 245);

                menuStrip1.BackColor = Color.FromArgb(255, 29, 29, 29);
                настройкиToolStripMenuItem.ForeColor = Color.FromArgb(255, 245, 245, 245);
             // настройкиToolStripMenuItem.BackColor = Color.FromArgb(255, 29, 29, 29);
                ОпрограммеToolStripMenuItem.ForeColor = Color.FromArgb(255, 245, 245, 245);
            }
            else
            {
                BackColor = SystemColors.Control;

                Label1.ForeColor = Color.FromArgb(255, 0, 0, 0);
                label2.ForeColor = Color.FromArgb(255, 0, 0, 0);
                label3.ForeColor = Color.FromArgb(255, 0, 0, 0);
                label4.ForeColor = Color.FromArgb(255, 0, 0, 0);
                label5.ForeColor = Color.FromArgb(255, 0, 0, 0);
                label6.ForeColor = Color.FromArgb(255, 0, 0, 0);
                LabelMode.ForeColor = Color.FromArgb(255, 0, 0, 0);
                LabelPaluch5.ForeColor = Color.FromArgb(255, 0, 0, 0);
                LabelPaluch4.ForeColor = Color.FromArgb(255, 0, 0, 0);
                LabelPaluch3.ForeColor = Color.FromArgb(255, 0, 0, 0);
                LabelPaluch2.ForeColor = Color.FromArgb(255, 0, 0, 0);

                Button1.BackColor = SystemColors.Control;
                Button1.ForeColor = SystemColors.ControlText;

                menuStrip1.BackColor = SystemColors.Control;
                настройкиToolStripMenuItem.ForeColor = SystemColors.ControlText;
                ОпрограммеToolStripMenuItem.ForeColor = SystemColors.ControlText;
            }

            if (File.Exists("ResourceCalculatorOldVersion.exe"))
            {
               // MessageBox.Show("Файл найден!");
                File.Delete("ResourceCalculatorOldVersion.exe");
            }
            else
            {
               // MessageBox.Show("Файл не найден!");
            }
        }

        //public static string versionProg = "1.0.0.1";
        public static string versionProg = Application.ProductVersion;

        private void ОпрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();

            aboutForm.ShowDialog();
        }

        private void темнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registry.CurrentUser.CreateSubKey(@"Software\ResourceCalculator").SetValue("DarkMode", "true");
            checkBoxDarkMode.Checked = true;
        }

        private void светлаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registry.CurrentUser.CreateSubKey(@"Software\ResourceCalculator").SetValue("DarkMode", "false");
            checkBoxDarkMode.Checked = false;
        }
        
        private void проверитьОбновленияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();

            var Ui = wc.DownloadString("http://atas.kl.com.ua/updater/ver.txt");
            if (Ui.Contains(versionProg))
            {
                MessageBox.Show("У вас установлена последняя версия программы!", "Обновления не найдены", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
               if (MessageBox.Show("Новое обновление доступно " + Ui + " хотите обновить?", "Найдено новое обновление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Updater upd = new Updater();

                    upd.ShowDialog();
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           // if (TextBox1.Text = null && TextBox2.Text = null && TextBox3.Text = null && TextBox4.Text = null && TextBox5.Text = null)

            if (TextBox1.Text.Length >= 1)
            {
                LabelResult2.Text = (Convert.ToInt32(TextBox1.Text) / 50).ToString();
            }
            else
            {

            }

            if (TextBox2.Text.Length >= 1)
            {
                LabelResult3.Text = (Convert.ToInt32(TextBox2.Text) / 50).ToString();
            }
            else
            {

            }

            if (TextBox3.Text.Length >= 1)
            {
                LabelResult4.Text = (Convert.ToInt32(TextBox3.Text) / 35).ToString();
            }
            else
            {

            }

            if (TextBox4.Text.Length >= 1)
            {
                LabelResult5.Text = (Convert.ToInt32(TextBox4.Text) / 25).ToString();
            }
            else
            {

            }  

            if (TextBox5.Text.Length >= 1)
            {
                LabelResult5.Text = (Convert.ToInt32(TextBox5.Text) + Convert.ToInt32(LabelResult5.Text)).ToString();
            }
            else
            {

            }

            if (ComboBox1.Text == "1 -> 3")
            {
                LabelResult3.Text = (Convert.ToInt32(TextBox1.Text) / 50 / 50).ToString();
            }

            if (ComboBox1.Text == "1 -> 4")
            {
                LabelResult4.Text = (Convert.ToInt32(TextBox1.Text) / 50 / 50 / 35).ToString();
            }

            if (ComboBox1.Text == "1 -> 5")
            {
                LabelResult5.Text = (Convert.ToInt32(TextBox1.Text) / 50 / 50 / 35 / 25).ToString();

                if (TextBox5.Text != "")
                {
                   // LabelResult5 = (TextBox5.Text + LabelResult5.Text).ToString();
                }
            }
        }

        private void ComboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void ButtonClean_Click(object sender, EventArgs e)
        {
            TextBox1.Text = null;
            TextBox2.Text = null;
            TextBox3.Text = null;
            TextBox4.Text = null;
            TextBox5.Text = null;
        }
    }
}