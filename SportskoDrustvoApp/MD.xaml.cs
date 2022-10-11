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
    /// Interaction logic for MD.xaml
    /// </summary>
    public partial class MD : Window
    {
        public int IdU;
        public MD(int idU)
        {
            this.IdU = idU;
            InitializeComponent();
        }

        private void createMD_Click(object sender, RoutedEventArgs e)
        {
            DBCrud.Cruds cruds = new DBCrud.Cruds();
            Models.ClanUpravnogOdbora clanUpravnogOdbora = new Models.ClanUpravnogOdbora(0,
                textboxname.Text.ToString(), (DateTime)calendar.SelectedDate, textboxQ.Text.ToString(), this.IdU);
            cruds.CreateClanU(clanUpravnogOdbora);

            int brck = cruds.GetMaxClanU();

            Models.GeneralniDirektor generalni = new Models.GeneralniDirektor(Convert.ToInt32(textBoxsponsors.Text.ToString()),
                brck, textboxname.Text.ToString(), (DateTime)calendar.SelectedDate, textboxQ.Text.ToString(), this.IdU);
            cruds.CreateGenDir(generalni);
            this.Close();
        }
    }
}
