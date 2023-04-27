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
    /// Logique d'interaction pour HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        private int clientID;

        public HomeWindow(int clientID)
        {
            InitializeComponent();
            this.clientID= clientID;
            DataContext = Coordination.Coordination.Instance;
        }

        private void newCommandBTN_Click(object sender, RoutedEventArgs e)
        {
            AddGuitareWindow addGuitare = new AddGuitareWindow(clientID);
            addGuitare.ShowDialog();
        }

        private void commandesInWaitBTN_Click(object sender, RoutedEventArgs e)
        {
            Guitare guitareCommande = Coordination.Coordination.Instance.GetGuitareByIDClient(clientID);
            CommandesWindow commandes = new CommandesWindow(guitareCommande);
            commandes.ShowDialog();
        }
    }
}
