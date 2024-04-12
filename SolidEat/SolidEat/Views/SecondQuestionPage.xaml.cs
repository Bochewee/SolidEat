using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace SolidEat
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class SecondQuestionPage : ContentPage
    {
        public SecondQuestionPage()
        {
            InitializeComponent();

        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {

            var button = sender as Button;
            var userResponse = button.Text;  // Stocker la réponse de l'utilisateur

            // Ici, vous pouvez faire quelque chose avec la réponse, comme la passer à la nouvelle page
            var nextPage = new ThirdQuestionPage(userResponse);  // Supposons que ThirdPage est votre prochaine page
            await Navigation.PushAsync(nextPage);

        }
    }
}