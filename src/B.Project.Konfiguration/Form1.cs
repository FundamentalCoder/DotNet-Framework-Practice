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
       
        public Form1(RootConfig config, Fahrzeug fahrzeug)
        {

            InitializeComponent();
            Text = config.test;
            
            lblHund.Text = fahrzeug.AutoAnzeigen();
            lblKatze.Text = fahrzeug.MotorradAnzeigen();
            LbLastwagen.Text = fahrzeug.LastwagenAnzeigen();

            MessageBox.Show(config.Vehicle[0].Name);

            MessageBox.Show(config.ConnectionStrings.DefaultConnection);

            config.ConnectionStrings.DefaultConnection = "jetzt anderst";

            MessageBox.Show(config.ConnectionStrings.DefaultConnection);
          
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
