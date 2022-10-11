using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SportskoDrustvoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DBCrud.Cruds cruds = new DBCrud.Cruds();
        public static List<Models.SD> sDs = new List<Models.SD>();
        public MainWindow()
        {
            InitializeComponent();
            this.update();
        }

        public void update()
        {
            sDs.Clear();
            sDs = cruds.citajSveSd();
            this.tabelaSD.ItemsSource = sDs;
        }


        private void createSD_Click(object sender, RoutedEventArgs e)
        {
            SDForm sDForm = new SDForm(this);
            sDForm.Show();
        }

        private void create_uprava_Click(object sender, RoutedEventArgs e)
        {
            object sd = tabelaSD.SelectedItem;
            ManagementForm managementForm = new ManagementForm(this,sd);
            managementForm.Show();
        }

        private void info_Click(object sender, RoutedEventArgs e)
        {
            object sd = tabelaSD.SelectedItem;
            Info info = new Info(sd);
            info.Show();
        }

        private void klub_Click(object sender, RoutedEventArgs e)
        {
            object sd = tabelaSD.SelectedItem;
            KlubForm klubForm = new KlubForm(sd);
            klubForm.Show();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            object sd = tabelaSD.SelectedItem;
            Models.SD sD = (Models.SD)sd;
            cruds.DeleteSD(sD.IdSD);
            update();
        }

        private void modify_Click(object sender, RoutedEventArgs e)
        {
            object item = tabelaSD.SelectedItem;
            Models.SD sD = (Models.SD)item;
            cruds.ModifySD(sD);
        }

    }
}
