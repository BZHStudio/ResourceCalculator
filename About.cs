using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            label3.Text += Application.UserAppDataPath;
            label4.Text += Application.CommonAppDataPath;
            label5.Text += Application.LocalUserAppDataPath;
            label6.Text += Application.ExecutablePath;
            label7.Text += Application.UseWaitCursor;
            label8.Text += Application.CompanyName;
            label9.Text += Application.CurrentCulture;
            label10.Text += Application.CurrentInputLanguage;
            label11.Text += Path.GetTempPath();
        }
    }
}
