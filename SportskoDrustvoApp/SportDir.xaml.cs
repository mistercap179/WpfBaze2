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
    /// Interaction logic for SportDir.xaml
    /// </summary>
    public partial class SportDir : Window
    {
        public int IDU;
        public SportDir(int idU)
        {
            this.IDU = idU;
            InitializeComponent();
        }

        private void createSD_Click(object sender, RoutedEventArgs e)
        {
            DBCrud.Cruds cruds = new DBCrud.Cruds();
            Models.ClanUpravnogOdbora clanUpravnogOdbora = new Models.ClanUpravnogOdbora(0,
                textboxname.Text.ToString(),(DateTime)calendar.SelectedDate,textboxQ.Text.ToString(),this.IDU);
            cruds.CreateClanU(clanUpravnogOdbora);

            int brck = cruds.GetMaxClanU();

            Models.SportskiDirektor direktor = new Models.SportskiDirektor(Convert.ToInt32(textBoxtransfers.Text.ToString()),
                brck,textboxname.Text.ToString() ,(DateTime)calendar.SelectedDate, textboxQ.Text.ToString(), this.IDU);
            cruds.CreateSportDir(direktor);
            this.Close();
        }
    }
}
