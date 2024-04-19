using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static SolidEat.MainPage;


namespace SolidEat
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class SecondQuestionPage : ContentPage
    {
        private int _age;

        public SecondQuestionPage(int age)
        {
            InitializeComponent();
            _age = age;
            Debug.WriteLine("Received age: " + _age);

        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var button = sender as Button;
                var role = button.Text;

                switch (role)
                {
                    case "Je suis un restaurant":
                        role = "Restaurant";
                        break;
                    case "Je suis un donateur":
                        role = "Donateur";
                        break;
                    case "Je réserve mon plat":
                        role = "Client";
                        break;
                    default:
                        break;
                }

                var firstName = Application.Current.Properties["tempFirstName"] as string;
                var lastName = Application.Current.Properties["tempLastName"] as string;
                var email = Application.Current.Properties["tempEmail"] as string;
                var password = Application.Current.Properties["tempPassword"] as string;
                var age = (int)Application.Current.Properties["tempAge"];

                Debug.WriteLine($"First Name: {firstName}, Last Name: {lastName}, Email: {email}, Password: {password}, Age: {age}, Role: {role}");

                await App.UserRepository.AddNewUserAsync(firstName, lastName, email, password, age, role);
                ClearTempData();

                await Navigation.PushAsync(new LoginPage());
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error during user registration: " + ex.Message);
                await DisplayAlert("Registration Error", "Failed to register user. Please try again.", "OK");
            }
        }

        private void ClearTempData()
        {
            Application.Current.Properties.Remove("tempFirstName");
            Application.Current.Properties.Remove("tempLastName");
            Application.Current.Properties.Remove("tempEmail");
            Application.Current.Properties.Remove("tempPassword");
            Application.Current.Properties.Remove("tempAge");
        }

    }
}