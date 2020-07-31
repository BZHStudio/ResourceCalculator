using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Microsoft.Win32;

namespace ResourceCalculator
{
    public partial class Updater : Form
    {
        public Updater()
        {
            InitializeComponent();

            progressBar1.Visible = false;

            var key = Registry.CurrentUser.CreateSubKey(@"Software\ResourceCalculator");

            if (key?.GetValue("DarkMode")?.ToString() == "true")
            {
                BackColor = Color.FromArgb(255, 29, 29, 29);
                label1.ForeColor = Color.FromArgb(255, 255, 255, 255);

                ButtonUpdate.BackColor = Color.FromArgb(255, 29, 29, 29);
                ButtonUpdate.ForeColor = Color.FromArgb(255, 255, 255, 255);

                progressBar1.BackColor = Color.FromArgb(255, 29, 29, 29);
                progressBar1.ForeColor = Color.FromArgb(255, 245, 245, 245);
            }
            else if (key?.GetValue("DarkMode")?.ToString() == "false")
            {
                BackColor = Color.FromArgb(255, 255, 255, 255);
                label1.ForeColor = SystemColors.ControlText;

                ButtonUpdate.BackColor = Color.FromArgb(255, 255, 255, 255);
                ButtonUpdate.ForeColor = Color.FromArgb(255, 29, 29, 29);


            }

        }

        public static string versionProg = Application.ProductVersion;

        private void Button1_Click(object sender, EventArgs e)
        {
            File.Move("ResourceCalculator.exe", "ResourceCalculatorOldVersion.exe");

            using (WebClient wc = new WebClient())
            {

            var Preurl = wc.DownloadString("https://raw.githubusercontent.com/BZHStudio/ResourceCalculator/master/url.txt");

              string url = Preurl.ToString();

                wc.OpenRead(url);
               // string size = (Convert.ToDouble(wc.ResponseHeaders["Content-Length"]) / 1048576).ToString("#.# МБ");
                string size = (Convert.ToDouble(wc.ResponseHeaders["Content-Length"]) / 1024).ToString("#.# КБ");
                
                wc.DownloadProgressChanged += (s, a) =>
                {
                   // label1.Text = $"Размер файла: {size}\nЗагружено: {a.ProgressPercentage}% ({((double)a.BytesReceived / 1048576).ToString("#.# МБ")})";
                    label1.Text = $"Размер файла: {size}\nЗагружено: {a.ProgressPercentage}% ({((double)a.BytesReceived / 1024).ToString("#.# КБ")})";

                    progressBar1.Value = a.ProgressPercentage;
                };

                string fileName = Path.Combine(Environment.CurrentDirectory, "ResourceCalculator.exe");

                wc.DownloadFileAsync(new Uri(url), fileName);
            }

            ButtonUpdate.Enabled = false;

            progressBar1.Visible = true;

            timer1.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == 100)
            {
                timer1.Enabled = false;

                if (MessageBox.Show("Приложение будет автоматически обновлено и перезапущено.", "Обновление завершино!", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    Application.Restart();
                }
            } 
        }
    }
}
