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
            foreach (var item in config.Fahrzeug.Auto.Pkw.GetType().GetProperties())
            {
                MessageBox.Show(item.Name + " : " + item.GetValue(config.Fahrzeug.Auto.Pkw));
            }

            foreach (var item in config.Fahrzeug.Auto.Limousine.GetType().GetProperties())
            {
                MessageBox.Show(item.Name + " : " + item.GetValue(config.Fahrzeug.Auto.Limousine));
            }

            var lkw = config.Fahrzeug.Lastwagen.LKW;

            foreach (var item in lkw.GetType().GetProperties())
            {
                var value = item.GetValue(lkw);

                if (value is Anhänger anhänger)
                {
                    // Properties des Anhängers auslesen
                    foreach (var prop in anhänger.GetType().GetProperties())
                    {
                        MessageBox.Show(prop.Name + " : " + prop.GetValue(anhänger));
                    }
                }
                else
                {
                    // Normale LKW-Properties ausgeben
                    MessageBox.Show(item.Name + " : " + value);
                }
            }




        }
    }
}
