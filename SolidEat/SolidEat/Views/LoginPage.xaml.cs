using SolidEat;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace SolidEat
{
    public partial class LoginPage : ContentPage
    {
        private bool _passwordVisible = false;
        public LoginPage()
        {
            InitializeComponent();
            TogglePasswordVisibilityCommand = new Command(TogglePasswordVisibility);
            BindingContext = this;
        }

        public ICommand TogglePasswordVisibilityCommand { get; }

        private void TogglePasswordVisibility()
        {
            _passwordVisible = !_passwordVisible;
            passwordEntry.IsPassword = !_passwordVisible;
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var email = emailEntry.Text;
            var password = passwordEntry.Text;

            // Vérification si l'utilisateur est l'admin
            if (email == "admin" && password == "admin")
            {
                // Navigation directe vers la page AdminPage
                await Navigation.PushAsync(new AdminPage());
            }
            else
            {
                // Traitement de connexion classique
                var isValid = await App.UserRepository.CheckLoginAsync(email, password);
                if (isValid)
                {
                    await DisplayAlert("Connexion réussie", "Vous êtes maintenant connecté.", "OK");
                    // Redirection vers une autre page après la connexion, si nécessaire
                }
                else
                {
                    await DisplayAlert("Erreur", "Email ou mot de passe incorrect.", "OK");
                }
            }
        }

        private async void OnSignUpTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        private async void OnAdminPageTapped(object sender, EventArgs e)
        {
            // Navigation directe vers la page AdminPage
            await Navigation.PushAsync(new AdminPage());
        }
        public async void OnLogout(object sender, EventArgs e)
        {
            // Réinitialiser le statut d'enregistrement
            Application.Current.Properties["IsRegistered"] = false;
            await Application.Current.SavePropertiesAsync();

            // Retour à la page de connexion
            await Navigation.PushAsync(new LoginPage());
        }

    }
}