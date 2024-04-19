using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SolidEat.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantView : ContentView
    {
        public RestaurantView()
        {
            InitializeComponent();
            this.BindingContext = new RestaurantViewModel();
        }
    }
}