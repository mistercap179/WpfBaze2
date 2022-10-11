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
    /// Interaction logic for InfoTrenings.xaml
    /// </summary>
    public partial class InfoTrenings : Window
    {
        public Models.Klub klubM;
        public DBCrud.Cruds cruds = new DBCrud.Cruds();
        public InfoTrenings(object klub)
        {
            this.klubM = (Models.Klub)klub;
            InitializeComponent();
            tabelaTreninzi.ItemsSource = cruds.citajSveTreninge();
        }

    }
}
