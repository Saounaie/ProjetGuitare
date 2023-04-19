using Fabrication_IHM.Coordination;
using NS_Jouje;
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
    /// Logique d'interaction pour StockWindow.xaml
    /// </summary>
    public partial class StockWindow : Window
    {
        
        public StockWindow()
        {
            InitializeComponent();
            DataContext= Coordination.Coordination.Instance;
        }

        private void addBoisBtn_Click(object sender, RoutedEventArgs e)
        {
            AddBoisWindow addBois = new AddBoisWindow();
            // fenêtre micro
            AddMicroWindow addMicro = new AddMicroWindow();
            // fenêtre vibrato
            AddVibratoWindow addVibrato = new AddVibratoWindow();
            int selectedIndex = tabControlStock.SelectedIndex;
            switch (selectedIndex)
            {
                case 0:
                    addBois.ShowDialog();
                    break;
                case 1:
                    addMicro.ShowDialog();
                    break;
                case 2:
                    addVibrato.ShowDialog();
                    break;
                default:
                    break;
            }

        }

        private async void deleteBoisBtn_Click(object sender, RoutedEventArgs e)
        {
            Bois selectedBois = boisLBX.SelectedItem as Bois;
            PickUp selectedMicro = microsLBX.SelectedItem as PickUp;
            Vibrato selectedVibrato = vibratosLBX.SelectedItem as Vibrato;

            int selectedIndex = tabControlStock.SelectedIndex;
            switch (selectedIndex)
            {
                case 0:
                    if (selectedBois != null)
                    {
                        int selectedBoisId = selectedBois.IdBois;
                        await Coordination.Coordination.Instance.DeleteBois(selectedBoisId);

                    }
                    break;
                case 1:
                    if (selectedMicro != null)
                    {
                        int selectedMicroID = selectedMicro.IdMicro;
                        await Coordination.Coordination.Instance.DeleteMicro(selectedMicroID);

                    }
                    break;
                case 2:
                    if(selectedVibrato != null)
                    {
                        int selectedVibratoID = selectedVibrato.IdVibrato;
                        await Coordination.Coordination.Instance.DeleteVibrato(selectedVibratoID);
                    }
                    break;

                default:
                    break;
            }
            
        }

        private void tabControlStock_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = tabControlStock.SelectedIndex;

            switch (selectedIndex)
            {
                case 0:
                    addBoisBtn.Content = "Ajouter Bois";
                    deleteBoisBtn.Content = "Supprimer Bois";
                    break;
                case 1:
                    addBoisBtn.Content = "Ajouter Micro";
                    deleteBoisBtn.Content = "Supprimer Micro";
                    break;
                case 2:
                    addBoisBtn.Content = "Ajouter Vibrato";
                    deleteBoisBtn.Content = "Supprimer Vibrato";
                    break;
                default:
                    break;
            }
        }
    }
}
