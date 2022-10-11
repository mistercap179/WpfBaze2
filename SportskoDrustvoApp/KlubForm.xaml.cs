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
    /// Interaction logic for KlubForm.xaml
    /// </summary>
    public partial class KlubForm : Window
    {
        public object sd;
        public Models.Klub kl;
        public int klubId;
        DBCrud.Cruds cruds = new DBCrud.Cruds();
        List<Models.Klub> klubovi = new List<Models.Klub>();
        public KlubForm(object sdModel)
        {
            this.sd = sdModel;
            InitializeComponent();
            this.update();
        }

        public void update()
        {
            Models.SD sdModel = (Models.SD)this.sd;
            int sdId = sdModel.IdSD;
            klubovi.Clear();
            klubovi = cruds.citajSveKlubove(sdId);
            this.tabelaKlubovi.ItemsSource = klubovi;
        }

        private void createClub_Click(object sender, RoutedEventArgs e)
        {
            Models.SD sdModel = (Models.SD)this.sd;
            int sdId = sdModel.IdSD;

            DBCrud.Cruds cruds = new DBCrud.Cruds();
            Models.Klub klub = new Models.Klub()
            {
                BrojTitutala = Convert.ToInt32(tbTitles.Text.ToString()),
                Sport = tBSport.Text.ToString(),
                Liga = tBName.Text.ToString(),
                IdSD = sdId
            };
            cruds.CreateKLUB(klub);
            klubId = cruds.GetMaxKlubId();

            this.createManagementKlub_Click(sender, e);
            //kl = klub;
        }

        private void createManagementKlub_Click(object sender, RoutedEventArgs e)
        {
            Models.SD sdModel = (Models.SD)this.sd;
            int sdId = sdModel.IdSD;
            FormManagementKlub klubManag = new FormManagementKlub(klubId,sdId);
            klubManag.Show();
        }

        private void createPlayer_Click(object sender, RoutedEventArgs e)
        {
            object klub = tabelaKlubovi.SelectedItem;
            PlayerForm playerForm = new PlayerForm(klub);
            playerForm.Show();
        }

        private void createCoach_Click(object sender, RoutedEventArgs e)
        {
            object klub = tabelaKlubovi.SelectedItem;
            CoachForm coachForm = new CoachForm(klub);
            coachForm.Show();
        }

        private void createField_Click(object sender, RoutedEventArgs e)
        {
            object klub = tabelaKlubovi.SelectedItem;
            FieldForm fieldForm = new FieldForm(klub);
            fieldForm.Show();
        }

        private void createTrening_Click(object sender, RoutedEventArgs e)
        {
            object klub = tabelaKlubovi.SelectedItem;
            TreningForm treningForm = new TreningForm(klub);
            treningForm.Show();
        }

        private void info_Click(object sender, RoutedEventArgs e)
        {
            object klub = tabelaKlubovi.SelectedItem;
            InfoTrenings info = new InfoTrenings(klub);
            info.Show();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            object klub = tabelaKlubovi.SelectedItem;
            Models.Klub kl = (Models.Klub)klub;
            cruds.DeleteKlub(kl.IdK);
            update();
        }
    }
}
