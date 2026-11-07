namespace B.Project.Konfiguration.SettingsUmgebungen
{
    public partial class Form1 : Form
    {
        public Form1(RootConfig config)
        {
            InitializeComponent();
            changeApplication(config.Application);
            var test = config.Application.Name;
           
            int testInt = 1;
            changeInteger(testInt);
            changeString(test);
            MessageBox.Show(test);
            MessageBox.Show(testInt.ToString());
            MessageBox.Show(config.Database.Password);





        }
        public void changeString(string a) {

            a = a +"bla bla"; 

        }
        public void changeInteger(int a) {
            a++;
        }
        public void changeApplication(Application app) {
            app.Name += app.Name;
        }
    }
     
}
