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
    /// Interaction logic for PlayerForm.xaml
    /// </summary>
    public partial class PlayerForm : Window
    {
        public Models.Klub klubM;
        public PlayerForm(object klub)
        {
            this.klubM = (Models.Klub)klub;
            InitializeComponent();
        }

        private void createPlayer_Click(object sender, RoutedEventArgs e)
        {
            DBCrud.Cruds cruds = new DBCrud.Cruds();
            Models.Igrac igrac = new Models.Igrac()
            {
                IdKlub = klubM.IdK,
                IdSd = klubM.IdSD,
                ImePrezime = tBName.Text.ToString(),
                DatumRodjenja = (DateTime)calendar.SelectedDate,
                Karijera = tbCareer.Text.ToString()
            };
            cruds.CreatePlayer(igrac);
            this.Close();
        }
    }
}
