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
using System.Diagnostics;

namespace ResourceCalculator
{
    public partial class Form1 : Form
    {
        public static string versionProg = Application.ProductVersion;
        public static string urlProg = "https://raw.githubusercontent.com/BZHStudio/ResourceCalculator/master/version.txt";
        /*string versurl = File.ReadAllText(urlProg);*/
            
        WebClient wc = new WebClient();

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

                TextBox1.ForeColor = Color.FromArgb(255, 245, 245, 245);
                TextBox1.BackColor = Color.FromArgb(255, 29, 29, 29);
                TextBox2.ForeColor = Color.FromArgb(255, 245, 245, 245);
                TextBox2.BackColor = Color.FromArgb(255, 29, 29, 29);
                TextBox3.ForeColor = Color.FromArgb(255, 245, 245, 245);
                TextBox3.BackColor = Color.FromArgb(255, 29, 29, 29);
                TextBox4.ForeColor = Color.FromArgb(255, 245, 245, 245);
                TextBox4.BackColor = Color.FromArgb(255, 29, 29, 29);
                TextBox5.ForeColor = Color.FromArgb(255, 245, 245, 245);
                TextBox5.BackColor = Color.FromArgb(255, 29, 29, 29);

                Button1.BackColor = Color.FromArgb(255, 29, 29, 29);
                Button1.ForeColor = Color.FromArgb(255, 255, 255, 255);
                ButtonClean.BackColor = Color.FromArgb(255, 29, 29, 29);
                ButtonClean.ForeColor = Color.FromArgb(255, 255, 255, 255);
                ButtonAllResult.BackColor = Color.FromArgb(255, 29, 29, 29);
                ButtonAllResult.ForeColor = Color.FromArgb(255, 255, 255, 255);

                ComboBox1.BackColor = Color.FromArgb(255, 29, 29, 29);
                ComboBox1.ForeColor = Color.FromArgb(255, 245, 245, 245);

                checkBoxSave.ForeColor = SystemColors.Control;

                menuStrip1.BackColor = Color.FromArgb(255, 29, 29, 29);
                настройкиToolStripMenuItem.ForeColor = Color.FromArgb(255, 245, 245, 245);
                настройкиToolStripMenuItem.BackColor = Color.FromArgb(255, 29, 29, 29);
                ОпрограммеToolStripMenuItem.ForeColor = Color.FromArgb(255, 245, 245, 245);
                темыToolStripMenuItem.ForeColor = Color.FromArgb(255, 29, 29, 29);
                темнаяToolStripMenuItem.ForeColor = Color.FromArgb(255, 29, 29, 29);
                светлаяToolStripMenuItem.ForeColor = Color.FromArgb(255, 29, 29, 29);
                проверитьОбновленияToolStripMenuItem.ForeColor = Color.FromArgb(255, 29, 29, 29);
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
                ButtonAllResult.BackColor = SystemColors.Control;
                ButtonAllResult.ForeColor = SystemColors.ControlText;

                checkBoxSave.ForeColor = SystemColors.ControlText;

                menuStrip1.BackColor = SystemColors.Control;
                настройкиToolStripMenuItem.ForeColor = SystemColors.ControlText;
                ОпрограммеToolStripMenuItem.ForeColor = SystemColors.ControlText;
                темыToolStripMenuItem.ForeColor = Color.FromArgb(255, 0, 0, 0);
                темнаяToolStripMenuItem.ForeColor = Color.FromArgb(255, 0, 0, 0);
                светлаяToolStripMenuItem.ForeColor = Color.FromArgb(255, 0, 0, 0);
                проверитьОбновленияToolStripMenuItem.ForeColor = Color.FromArgb(255, 0, 0, 0);
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

            using (RegistryKey keySave = Registry.CurrentUser.CreateSubKey(@"Software\ResourceCalculator"))
                TextBox1.Text = keySave?.GetValue("Savecfg1").ToString();
            using (RegistryKey keySave = Registry.CurrentUser.CreateSubKey(@"Software\ResourceCalculator"))
                TextBox2.Text = keySave?.GetValue("Savecfg2").ToString();
            using (RegistryKey keySave = Registry.CurrentUser.CreateSubKey(@"Software\ResourceCalculator"))
                TextBox3.Text = keySave?.GetValue("Savecfg3").ToString();
            using (RegistryKey keySave = Registry.CurrentUser.CreateSubKey(@"Software\ResourceCalculator"))
                TextBox4.Text = keySave?.GetValue("Savecfg4").ToString();
            using (RegistryKey keySave = Registry.CurrentUser.CreateSubKey(@"Software\ResourceCalculator"))
                TextBox5.Text = keySave?.GetValue("Savecfg5").ToString();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var UiTest = wc.DownloadString(urlProg);

            if (UiTest.Contains(versionProg))
            {
                /*MessageBox.Show("У вас установлена последняя версия программы!", "Обновления не найдены", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
            }
            else
            {
                if (MessageBox.Show("Текущая версия программы " + versionProg + "\nНовое обновление доступно " + UiTest + "\n\nТребуется обновление.\nОбновить программу до актуальной версии?", "Найдено новое обновление!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Updater upd = new Updater();

                    upd.ShowDialog();
                }
            }

        }

        private void ОпрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();

            aboutForm.ShowDialog();
        }

        private void темнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkBoxDarkMode.Checked == true)
            {

            }
            else
            {
                Registry.CurrentUser.CreateSubKey(@"Software\ResourceCalculator").SetValue("DarkMode", "true");
                checkBoxDarkMode.Checked = true;
                Application.Restart();
            }
            
        }

        private void светлаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkBoxDarkMode.Checked == false)
            {

            }
            else
            {
                Registry.CurrentUser.CreateSubKey(@"Software\ResourceCalculator").SetValue("DarkMode", "false");
                checkBoxDarkMode.Checked = false;
                Application.Restart();
            }

        }
        
        private void проверитьОбновленияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Ui = wc.DownloadString(urlProg);
            if (Ui.Contains(versionProg))
            {
                MessageBox.Show("У вас установлена последняя версия программы!", "Обновления не найдены", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("Текущая версия программы " + versionProg + "\nНовое обновление доступно " + Ui + "\n\nТребуется обновление.\nОбновить программу до актуальной версии?", "Найдено новое обновление!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                TextBox1.Text = (Convert.ToInt32(TextBox1.Text) / 50).ToString();
                LabelResult2.Text = (Convert.ToInt32(TextBox1.Text) / 50 / 50).ToString();
                LabelResult3.Text = LabelResult2.Text + LabelResult3.Text;
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

            LabelResult2.Text = null;
            LabelResult3.Text = null;
            LabelResult4.Text = null;
            LabelResult5.Text = null;
        }

        private void ButtonAllResult_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "" || TextBox4.Text == "" || TextBox5.Text == "") {
                MessageBox.Show("Заполните все поля!", "Поля не заполнены");
            } else if (LabelResult2.Text == "" || LabelResult3.Text == "" || LabelResult4.Text == "" || LabelResult5.Text == "") {
                MessageBox.Show("Вы не подсчитали ресурсы!", "Ошибка");
            } else
            {

                var tb2 = (Convert.ToInt32(LabelResult2.Text) / 50);
                var tb3 = (Convert.ToInt32(LabelResult3.Text) / 35);
                var tb4 = (Convert.ToInt32(LabelResult4.Text) / 25);
                var tb5 = (Convert.ToInt32(LabelResult5.Text));


                var ResultAll = tb2 + tb3 + tb4 + tb5;


                // var ResultAll = ((Convert.ToInt32(TextBox1.Text) / 50) + (Convert.ToInt32(TextBox2.Text) / 50) + (Convert.ToInt32(TextBox3.Text) / 35) + (Convert.ToInt32(TextBox4.Text) / 25) + (Convert.ToInt32(TextBox5.Text))).ToString();
                MessageBox.Show("Если все ресурсы перевести в 5 получите : " + " " + ResultAll, "result").ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form fru = new Updater();
            fru.ShowDialog();
        }

        private void checkBoxSave_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSave.Checked == true)
            {
                checkBoxSave.Checked = true;

                Registry.CurrentUser.CreateSubKey(@"Software\ResourceCalculator").SetValue("Savecfg1", TextBox1.Text);
                Registry.CurrentUser.CreateSubKey(@"Software\ResourceCalculator").SetValue("Savecfg2", TextBox2.Text);
                Registry.CurrentUser.CreateSubKey(@"Software\ResourceCalculator").SetValue("Savecfg3", TextBox3.Text);
                Registry.CurrentUser.CreateSubKey(@"Software\ResourceCalculator").SetValue("Savecfg4", TextBox4.Text);
                Registry.CurrentUser.CreateSubKey(@"Software\ResourceCalculator").SetValue("Savecfg5", TextBox5.Text);
            }


        }
    }
}