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
    /// Logique d'interaction pour AddMicroWindow.xaml
    /// </summary>
    public partial class AddMicroWindow : Window
    {
        public AddMicroWindow()
        {
            InitializeComponent();
            caractMicroTBX.AcceptsReturn = true;
            caractMicroTBX.TextWrapping = TextWrapping.Wrap;
        }

        private void cancelAddMicroBTN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void addMicroBTN_Click(object sender, RoutedEventArgs e)
        {
            int stock = Convert.ToInt32(stockMicTBX.Text);

            var nvMic = new PickUp
            {
                NomMicro = nomMicroTBX.Text,
                CaracteristiquesMicro = caractMicroTBX.Text,
               // StockMicro = stock

            };


            await Coordination.Coordination.Instance.AddMicro(nvMic);
            Close();
        }
    }
}
