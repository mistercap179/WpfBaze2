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
    /// Interaction logic for SDForm.xaml
    /// </summary>
    public partial class SDForm : Window
    {
        private MainWindow _MainWindow = null;
        public SDForm(MainWindow mainWindow)
        {
            this._MainWindow = mainWindow;
            InitializeComponent();
        }

        private void createSDForm_Click(object sender, RoutedEventArgs e)
        {
            DBCrud.Cruds crud = new DBCrud.Cruds();
            Models.SD sd = new Models.SD(0,textBoxName.Text.ToString(),textBoxPlace.Text.ToString(),calendar.SelectedDate,null);
            crud.CreateSD(sd);
            //((MainWindow)Application.Current.MainWindow).tabelaSD.Items.Add(sd);

            this.Close();
            _MainWindow.update();
            
        }
    }
}
