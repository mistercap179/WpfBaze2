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
    /// Interaction logic for FieldForm.xaml
    /// </summary>
    public partial class FieldForm : Window
    {
        public Models.Klub klubM;
        public FieldForm(object klub)
        {
            this.klubM = (Models.Klub)klub;
            InitializeComponent();
        }

        private void createField_Click(object sender, RoutedEventArgs e)
        {
            DBCrud.Cruds cruds = new DBCrud.Cruds();
            Models.Teren teren = new Models.Teren()
            {
                IdKlub = klubM.IdK,
                IdSD = klubM.IdSD,
                Istorijat = tbHist.Text.ToString(),
                Kapacitet = Convert.ToInt64(tbCapacity.Text.ToString()),
                Lokacija = tbLocation.Text.ToString(),
                Naziv = tbName.Text.ToString()
            };
            cruds.CreateField(teren);
            this.Close();
        }
    }
}
