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
    /// Logique d'interaction pour CommandesWindow.xaml
    /// </summary>
    public partial class CommandesWindow : Window
    {
        Guitare guitare;
        private int clientID;

        public CommandesWindow(Guitare guitare, int clientID)
        {
            this.guitare = guitare;
            this.clientID = clientID;
            InitializeComponent();
            DataContext = Coordination.Coordination.Instance;
            actuelGuiatreName.Text = guitare.NomGuitare;


            Bois bois1 = Coordination.Coordination.Instance.Liste_Bois.FirstOrDefault(b => b.IdBois == guitare.IdBois);
            ComboBoxTypeDeBois.SelectedItem = bois1;

            Bois bois2 = Coordination.Coordination.Instance.Liste_Bois.FirstOrDefault(b => b.IdBois == guitare.IdBois_1);
            ComboBoxTypeDeBois2.SelectedItem = bois2;

            Bois bois3 = Coordination.Coordination.Instance.Liste_Bois.FirstOrDefault(b => b.IdBois == guitare.IdBois_2);
            ComboBoxTypeDeBois3.SelectedItem = bois3;
            //-----------------------------------------------
            PickUp micro1 = Coordination.Coordination.Instance.Liste_Micros.FirstOrDefault(m => m.IdMicro == guitare.IdMicro);
            ComboBoxMicro1.SelectedItem = micro1;

            PickUp micro2 = Coordination.Coordination.Instance.Liste_Micros.FirstOrDefault(m => m.IdMicro == guitare.IdMicro_1);
            ComboBoxMicro2.SelectedItem = micro2;

            PickUp micro3 = Coordination.Coordination.Instance.Liste_Micros.FirstOrDefault(m => m.IdMicro == guitare.IdMicro_2);
            ComboBoxMicro3.SelectedItem = micro3;
            //-------------------------------------------------
            Vibrato vibrato = Coordination.Coordination.Instance.Liste_Vibratos.FirstOrDefault(v => v.IdVibrato == guitare.IdVibrato);
            ComboBoxTypeDeVibrato.SelectedItem = vibrato;
            this.clientID = clientID;

            /*DataContext = Coordination.Coordination.Instance;
            ComboBoxTypeDeBois.SelectedItem = guitare.IdBois;
            ComboBoxTypeDeBois2.SelectedItem = guitare.IdBois_1;
            ComboBoxTypeDeBois3.SelectedItem = guitare.IdBois_2;
            ComboBoxMicro1.SelectedItem = guitare.IdMicro;
            ComboBoxMicro2.SelectedItem = guitare.IdMicro_1;
            ComboBoxMicro3.SelectedItem = guitare.IdMicro_2;
            ComboBoxTypeDeVibrato.SelectedItem = guitare.IdVibrato;*/


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

            try
            {
                await Coordination.Coordination.Instance.UpdateGuitare(guitare.IdGuitare, tbGuitareName.Text, clientID, selectedMicroID1, selectedMicroID2, selectedMicroID3, selectedBoisID, selectedBoisID2, selectedBoisID3, selectedVibratoID);
                MessageBox.Show("Opération réussie !");
                actuelGuiatreName.Text = guitare.NomGuitare;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }
    }
}
