using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using B.Project.Konfiguration.Configs;

namespace B.Project.Konfiguration
{
    public partial class Form1 : Form
    {
        public Form1(RootConfig config, Tiere tiere)
        {

            InitializeComponent();
            Text = config.test;

            lblHund.Text = tiere.HundAnzeigen();
            lblKatze.Text = tiere.KatzeAnzeigen();


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
