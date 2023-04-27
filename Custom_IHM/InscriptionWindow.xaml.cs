using NS_Jouje;
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
using System.Windows.Shapes;


namespace Custom_IHM
{
    /// <summary>
    /// Logique d'interaction pour InscriptionWindow.xaml
    /// </summary>
    public partial class InscriptionWindow : Window
    {
        public InscriptionWindow()
        {
            InitializeComponent();
            DataContext = Coordination.Coordination.Instance;
        }

        private void connectBTN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void signUpBTN_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            SecureString pwd = PasswordBox.SecurePassword;

            IntPtr ptr = Marshal.SecureStringToBSTR(pwd);
            string mdpClair = Marshal.PtrToStringBSTR(ptr);
            Marshal.ZeroFreeBSTR(ptr);

            SHA256 sha256 = SHA256.Create();
            byte[] passwordHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(mdpClair));
            string passwordHashString = Convert.ToBase64String(passwordHash);


            Client nvClient = new Client
            {
                PseudoClient = username,
                MdpClient = passwordHashString
            };

            await Coordination.Coordination.Instance.CreateClient(nvClient);




        }
    }
}
