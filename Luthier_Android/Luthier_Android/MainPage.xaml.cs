using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace Luthier_Android
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private async void stockBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StocksPage());
        }
    }
}
