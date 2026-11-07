using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B.Project.Konfiguration.Aufgabe
{
    public partial class Form1 : Form
    {
        public Form1( FahrzuegeConfig config)
        {
            InitializeComponent();
            foreach (var item in config.Fahrzeug.Auto)
            {
                if(item.Pkw != null)
                {
                    MessageBox.Show(item.Pkw.name + " : " + item.Pkw.ps + " : " + item.Pkw.doors);
                }
                if(item.Limousine != null)
                {
                    MessageBox.Show(item.Limousine.name + " : " + item.Limousine.ps + " : " + item.Limousine.doors);
                }
            }

            var lkw = config.Fahrzeug.Lastwagen.LKW;
       
            var ag = lkw.Anhänger;

            MessageBox.Show("LKW: " + lkw.name + " : " + lkw.ps + " : " + lkw.doors + " : " + ag.name + " : " + ag.size);

            var kleinenLastwagen = config.Fahrzeug.Lastwagen.KleineLastwagen;
            MessageBox.Show(kleinenLastwagen.name + " : " + kleinenLastwagen.ps + " : " + kleinenLastwagen.doors);







        }
    }
}
