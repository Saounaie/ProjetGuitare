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

namespace Custom_IHM
{
    /// <summary>
    /// Logique d'interaction pour AddGuitareWindow.xaml
    /// </summary>
    public partial class AddGuitareWindow : Window
    {
        private int clientID;

        public AddGuitareWindow(int clientID)
        {
            InitializeComponent();
            this.clientID = clientID;
            DataContext = Coordination.Coordination.Instance;
        }

        private async void addGuitareBTN_Click(object sender, RoutedEventArgs e)
        {
            Bois selectedBois = (Bois)ComboBoxTypeDeBois.SelectedItem;
            int selectedBoisID = selectedBois.IdBois;

            Bois selectedBois2 = (Bois)ComboBoxTypeDeBois2.SelectedItem;
            int selectedBoisID2 = selectedBois2.IdBois;

            Bois selectedBois3 = (Bois)ComboBoxTypeDeBois3.SelectedItem;
            int selectedBoisID3 = selectedBois3.IdBois;
            //------
            PickUp selectedMicro1 = (PickUp)ComboBoxMicro1.SelectedItem;
            int selectedMicroID1 = selectedMicro1.IdMicro;

            PickUp selectedMicro2 = (PickUp)ComboBoxMicro2.SelectedItem;
            int selectedMicroID2 = selectedMicro2.IdMicro;

            PickUp selectedMicro3 = (PickUp)ComboBoxMicro3.SelectedItem;
            int selectedMicroID3 = selectedMicro3.IdMicro;

            // ---- 
            Vibrato selectedVibrato = (Vibrato)ComboBoxTypeDeVibrato.SelectedItem;
            int selectedVibratoID = selectedVibrato.IdVibrato;



            var nouvelleGuitare = new Guitare
            {
                IdBois = selectedBoisID,
                IdBois_1 = selectedBoisID2,
                IdBois_2 = selectedBoisID3,
                IdMicro = selectedMicroID1,
                IdMicro_1 = selectedMicroID2,
                IdMicro_2 = selectedMicroID3,
                IdVibrato = selectedVibratoID,
                NomGuitare = tbGuitareName.Text,
                IdClient = clientID
            };

            try
            {
                await Coordination.Coordination.Instance.AddGuitare(nouvelleGuitare);
                MessageBox.Show("Opération réussie");
            }catch(Exception ex)
            {
                MessageBox.Show("Une erreur est survenue :" + ex.Message);
            }

            
        }

        private void ComboBoxTypeDeBois_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Bois selectedBois = (Bois)ComboBoxTypeDeBois.SelectedItem;
           

            if (selectedBois != null )
            {
                bool enStock = selectedBois.StockBois;

                if (!enStock)
                {
                    MessageBox.Show("Stock épuisé");
                }
            }
        }

        private void ComboBoxTypeDeBois2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
   


            Bois selectedBois2 = (Bois)ComboBoxTypeDeBois2.SelectedItem;



            if (selectedBois2 != null)
            {
                bool enStock = selectedBois2.StockBois;

                if (!enStock)
                {
                    MessageBox.Show("Stock épuisé");
                }
            }
        }

        private void ComboBoxTypeDeBois3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Bois selectedBois3 = (Bois)ComboBoxTypeDeBois3.SelectedItem;



            if (selectedBois3 != null)
            {
                bool enStock = selectedBois3.StockBois;

                if (!enStock)
                {
                    MessageBox.Show("Stock épuisé");
                }
            }
        }
    }
}
