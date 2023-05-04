using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Luthier_Android
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StocksPage : TabbedPage
    {
        public StocksPage()
        {
            InitializeComponent();
            BindingContext = Coordination.Instance;
        }
    }
}