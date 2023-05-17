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
    /// Logique d'interaction pour AddVibratoWindow.xaml
    /// </summary>
    public partial class AddVibratoWindow : Window
    {
        public AddVibratoWindow()
        {
            InitializeComponent();
        }

        private void cancelAddVibratoBTN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void addVibratoBTN_Click(object sender, RoutedEventArgs e)
        {
            int stock = Convert.ToInt32(stockVibratoTBX.Text);

            var nvVibrato = new Vibrato
            {
                NomVibrato = nomVibratoTBX.Text,
                TypeVibrato = typeVibratoTBX.Text,
                // StockVibrato = stock

            };


            await Coordination.Coordination.Instance.AddVibrato(nvVibrato);
            Close();
        }
    }
}
