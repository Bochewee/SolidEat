using System;
using Xamarin.Forms;

namespace SolidEat
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private async void OnSignUpClicked(object sender, EventArgs e)
        {
            var firstName = firstNameEntry.Text;
            var lastName = lastNameEntry.Text;
            var email = emailEntry.Text;
            var password = passwordEntry.Text;

            // Stocker temporairement les données
            Application.Current.Properties["tempFirstName"] = firstName;
            Application.Current.Properties["tempLastName"] = lastName;
            Application.Current.Properties["tempEmail"] = email;
            Application.Current.Properties["tempPassword"] = password;

            // Sauvegarde immédiate des propriétés
            await Application.Current.SavePropertiesAsync();

            // Navigation à la page suivante
            await Navigation.PushAsync(new MainPage());
        }

        private async void OnSignInClicked(object sender, EventArgs e)
        {
            // Naviguer vers la page de connexion
            await Navigation.PushAsync(new LoginPage());
        }

    }
}
