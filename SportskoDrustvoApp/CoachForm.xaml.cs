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
    /// Interaction logic for CoachForm.xaml
    /// </summary>
    public partial class CoachForm : Window
    {
        public Models.Klub klubM;
        public CoachForm(object klub)
        {
            this.klubM = (Models.Klub)klub;
            InitializeComponent();
        }

        private void createCoach_Click(object sender, RoutedEventArgs e)
        {
            DBCrud.Cruds cruds = new DBCrud.Cruds();
            Models.Trener trener = new Models.Trener()
            {
                IdKlub = klubM.IdK,
                IdSD = klubM.IdSD,
                ImePrezime = tBName.Text.ToString(),
                BrojTitula = Convert.ToInt32(tbTitles.Text.ToString()),
                Karijera = tbCareer.Text.ToString()
            };
            cruds.CreateCoach(trener);
            this.Close();
        }
    }
}
