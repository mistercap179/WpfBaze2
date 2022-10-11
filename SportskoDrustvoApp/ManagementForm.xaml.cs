using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SportskoDrustvoApp
{
    /// <summary>
    /// Interaction logic for ManagementForm.xaml
    /// </summary>
    public partial class ManagementForm : Window
    {
        private MainWindow _MainWindow = null;
        public object sdItem;
        public int managId;
        public ManagementForm(MainWindow mainWindow,object sd)
        {
            this._MainWindow = mainWindow;
            this.sdItem = sd;
            InitializeComponent();
        }

        private void createManagement_Click(object sender, RoutedEventArgs e)
        {
            DBCrud.Cruds crud = new DBCrud.Cruds();
           
            Models.Uprava uprava = new Models.Uprava() { SjedisteUprave = textBoxSjediste.Text, OpisPosla = textBoxOpis.Text };
            crud.CreateManagement(uprava);
            
            managId = crud.GetMaxManagmentId();
            //uprava.IdU = managId;
            Models.SD sdModel = (Models.SD)this.sdItem;
            int sdId = sdModel.IdSD;
            crud.CreateVlada(sdId, managId);


            _MainWindow.update();
        }

        private void createsportDir_Click(object sender, RoutedEventArgs e)
        {
            SportDir sportDir = new SportDir(managId);
            sportDir.Show();
        }

        private void createPresident_Click(object sender, RoutedEventArgs e)
        {
            President president = new President(managId);
            president.Show();
        }

        private void createMD_Click(object sender, RoutedEventArgs e)
        {
            MD mD = new MD(managId);
            mD.Show();
        }
    }
}
