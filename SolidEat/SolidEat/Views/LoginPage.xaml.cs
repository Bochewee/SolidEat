using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SolidEat
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            // Logique de vérification des identifiants
            // Redirection après connexion réussie
            await DisplayAlert("Connexion", "Vous êtes maintenant connecté.", "OK");
            // Redirection vers une autre page après la connexion si nécessaire
        }

        private async void OnSignUpTapped(object sender, EventArgs e)
        {
            // Naviguer vers la page d'inscription
            await Navigation.PushAsync(new SignUpPage());
        }
    }
}
