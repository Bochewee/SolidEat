using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SolidEat
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThirdQuestionPage : ContentPage
    {
        public ThirdQuestionPage(string userResponse)
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            // Attendez un court délai pour assurer une transition fluide
            await Navigation.PushAsync(new LoginPage());
        }
    }
}
