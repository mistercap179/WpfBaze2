using DataBase;
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
    /// Interaction logic for TreningForm.xaml
    /// </summary>
    public partial class TreningForm : Window
    {
        public Models.Klub klub;
        public DBCrud.Cruds cruds = new DBCrud.Cruds();
//      public List<udfTrening_Result> udfTrening_s = new List<udfTrening_Result>();
        public int treningid;
        public TreningForm(object klubM)
        {
            this.klub = (Models.Klub)klubM;
            InitializeComponent();
            this.getLists();
        }

        public void getLists()
        {
            listBoxCoachs.ItemsSource = klub.treneri;
            listBoxPlayers.ItemsSource = klub.igraci;
            listBoxFields.ItemsSource = klub.tereni;
            //treningid = cruds.GetMaxTraningId();
            //udfTrening_s = cruds.treningTableCreate(treningid);
            //this.tabelaTrening.ItemsSource = udfTrening_s;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            object teren = listBoxFields.SelectedItem;
            object trener = listBoxCoachs.SelectedItem;
            object igrac = listBoxPlayers.SelectedItem;
            // int idIgrac = Convert.ToInt32(listBoxPlayers.SelectedItem.ToString());
            // Models.Trener trener = cruds.citajTrenera(idtrener);
            //Models.Igrac igrac = cruds.citajIgraca(idIgrac);
            Models.Teren teren1 = (Models.Teren)teren;
            Models.Igrac igrac1 = (Models.Igrac)igrac;
            Models.Trener trener1 = (Models.Trener)trener;
            Models.Trening trening = new Models.Trening()
            {
                Trajanje = DateTime.Parse(tbDuration.Text).TimeOfDay,
                Opis = tbDescription.Text.ToString(),
                IdTeren = teren1.IdT,
                Trener = (int)trener1.JMBGT,
                Igrac = (int)igrac1.JBMG

            };

            cruds.CreateTrening(trening);
            treningid = cruds.GetMaxTraningId();
           // getLists();
            this.Close();
        }
    }
}
