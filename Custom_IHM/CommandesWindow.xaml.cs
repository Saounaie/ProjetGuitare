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

namespace Custom_IHM
{
    /// <summary>
    /// Logique d'interaction pour CommandesWindow.xaml
    /// </summary>
    public partial class CommandesWindow : Window
    {
        Guitare guitare;

        public CommandesWindow(Guitare guitare)
        {
            this.guitare = guitare;
            InitializeComponent();
            DataContext = Coordination.Coordination.Instance;

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
            Vibrato vibrato = Coordination.Coordination.Instance.Liste_Vibratos.FirstOrDefault(v => v.IdVibrato== guitare.IdVibrato);
            ComboBoxTypeDeVibrato.SelectedItem = vibrato;

            /*DataContext = Coordination.Coordination.Instance;
            ComboBoxTypeDeBois.SelectedItem = guitare.IdBois;
            ComboBoxTypeDeBois2.SelectedItem = guitare.IdBois_1;
            ComboBoxTypeDeBois3.SelectedItem = guitare.IdBois_2;
            ComboBoxMicro1.SelectedItem = guitare.IdMicro;
            ComboBoxMicro2.SelectedItem = guitare.IdMicro_1;
            ComboBoxMicro3.SelectedItem = guitare.IdMicro_2;
            ComboBoxTypeDeVibrato.SelectedItem = guitare.IdVibrato;*/


        }
    }
}
