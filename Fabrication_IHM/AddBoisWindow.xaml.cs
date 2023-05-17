using Fabrication_IHM.Coordination;
using NS_JOUJE_AZURE;
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

namespace Fabrication_IHM
{
    /// <summary>
    /// Logique d'interaction pour AddBoisWindow.xaml
    /// </summary>
    public partial class AddBoisWindow : Window
    {
        public AddBoisWindow()
        {
            InitializeComponent();
            DataContext = Coordination.Coordination.Instance;
        }

        private async void addBoisBTN_Click(object sender, RoutedEventArgs e)
        {
            double poids = Convert.ToDouble(poidsBoisTBX.Text);
            bool isStock = stockBoisCheckBox.IsChecked ?? false;

            var nvBois = new Bois
            {
                NomBois = nomBoisTBX.Text,
                PoidsBois = poids,
                Région = régionBoisTBX.Text,
                StockBois = isStock
                
            };


            await Coordination.Coordination.Instance.AddBois(nvBois);
            Close();
            
            


        }

        private void cancelAddBoisBTN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
