using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SolidEat;


namespace SolidEat
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThirdQuestionPage : ContentPage
    {
        public ThirdQuestionPage(string userResponse)
        {
            InitializeComponent();
            // Utilisez la réponse ici, par exemple, affichez-la dans un Label
            Label responseLabel = new Label
            {
                Text = $"Votre choix : {userResponse}",
                FontSize = 24,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            this.Content = responseLabel;
        }
    }


}