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

namespace ResourceCalculator
{
    public partial class Updater : Form
    {
        public Updater()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            File.Move("ResourceCalculator.exe", "ResourceCalculatorOldVersion.exe");

            string url = "http://atas.kl.com.ua/updater/ResourceCalculator.exe";

            using (WebClient wc = new WebClient())
            {
                // var urlget wc.DownloadString();
               // urlget.Contains(cont);

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
        }
    }
}
