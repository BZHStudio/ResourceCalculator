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
        }
    }
}
