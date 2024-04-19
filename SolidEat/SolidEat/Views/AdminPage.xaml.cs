using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SolidEat.Repositories;
using SolidEat.Models;
using SolidEat.Views;

namespace SolidEat
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminPage : ContentPage
    {
        public ObservableCollection<User> Users { get; private set; } = new ObservableCollection<User>();

        public AdminPage()
        {
            InitializeComponent();
            LoadDefaultView(); // Charge la vue par défaut (Restaurants)
        }

        private void LoadDefaultView()
        {
            contentHolder.Children.Clear();
            contentHolder.Children.Add(new RestaurantView());  // Assurez-vous que RestaurantView est correctement implémenté
        }

        private void OnRestaurantsTapped(object sender, EventArgs e)
        {
            // Réagir au clic sur l'onglet Restaurants
            LoadDefaultView();
        }

        private void OnReviewsTapped(object sender, EventArgs e)
        {
            // Réagir au clic sur l'onglet Avis
            contentHolder.Children.Clear();
            contentHolder.Children.Add(new ReviewView()); // ReviewView est une vue personnalisée pour les avis
        }

        private void OnUsersTapped(object sender, EventArgs e)
        {
            // Réagir au clic sur l'onglet Utilisateurs
            contentHolder.Children.Clear();
            contentHolder.Children.Add(new UsersView(this)); // UsersView est une vue personnalisée pour les utilisateurs
        }

        private async void OnDeleteUser(object sender, EventArgs e)
        {
            // Suppression d'un utilisateur
            var button = sender as Button;
            var user = button.CommandParameter as User;
            if (user != null)
            {
                await App.UserRepository.DeleteUserAsync(user.Id);
                Users.Remove(user); // Supprime l'utilisateur de la liste affichée
            }
        }

        private async void LoadUsers()
        {
            // Chargement de tous les utilisateurs
            var usersList = await App.UserRepository.GetAllUsersAsync();
            Users.Clear();
            foreach (var user in usersList)
            {
                Users.Add(user);
            }
        }
    }
}
