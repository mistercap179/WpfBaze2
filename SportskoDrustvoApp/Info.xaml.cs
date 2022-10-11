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
    /// Interaction logic for Info.xaml
    /// </summary>
    public partial class Info : Window
    {
        DBCrud.Cruds cruds = new DBCrud.Cruds();
        public List<int?> upraveIds = new List<int?>();
        public List<Models.Uprava> uprave = new List<Models.Uprava>();
        public object sdItem;
        public Info(object sd)
        {
            this.sdItem = sd;
            InitializeComponent();
            this.update();
        }

        public void update()
        {
            uprave.Clear();
            upraveIds.Clear();
            Models.SD sdModel = (Models.SD)this.sdItem;
            upraveIds = cruds.citajSveUpraveSD(sdModel.IdSD);
            foreach (var item in upraveIds)
            {
                uprave.Add(cruds.citajUpravu((int)item));
            }
            this.tabelaUprava.ItemsSource = uprave;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            object sd = tabelaUprava.SelectedItem;
            Models.Uprava uprava = (Models.Uprava)sd;
            cruds.DeleteUprava(uprava.IdU);
            this.Close();
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            object item = tabelaUprava.SelectedItem;
            Models.Uprava uprava = (Models.Uprava)item;
            cruds.ModifyInfoUprava(uprava);
        }

    }
}
