using NS_JOUJE_AZURE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Custom_IHM
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = Coordination.Coordination.Instance;
        }

        private void btnInscrire_Click(object sender, RoutedEventArgs e)
        {
            InscriptionWindow inscription = new InscriptionWindow();
            inscription.ShowDialog();
        }

        private async void btnConnecter_Click(object sender, RoutedEventArgs e)
        {

            string username = tbUsername.Text;
            SecureString pwd = tbPassword.SecurePassword;

            IntPtr ptr = Marshal.SecureStringToBSTR(pwd);
            string mdpClair = Marshal.PtrToStringBSTR(ptr);
            Marshal.ZeroFreeBSTR(ptr);

            SHA256 sha256 = SHA256.Create();
            byte[] passwordHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(mdpClair));
            string passwordHashString = Convert.ToBase64String(passwordHash);

            var clientAVerifier = new Client
            {
                PseudoClient = username,
                MdpClient = passwordHashString
            };

            var isLoginSuccess = await Coordination.Coordination.Instance.VerifyLogin(clientAVerifier);
            if (isLoginSuccess)
            {
                var id = await Coordination.Coordination.Instance.GetIDByClient(clientAVerifier);
                clientAVerifier.IdClient = id;
                HomeWindow home = new HomeWindow(id);
                home.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect");
            }

        }
    }
}
