using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace SolidEat
{

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }


        public class MainViewModel : INotifyPropertyChanged
        {
            private int _age = 18; // Valeur initiale

            public int Age
            {
                get { return _age; }
                set
                {
                    if (_age != value)
                    {
                        _age = value;
                        OnPropertyChanged(nameof(Age));
                    }
                }
            }

            public ICommand IncrementCommand => new Command(() =>
            {
                if (Age < 99)
                    Age++;
            });

            public ICommand DecrementCommand => new Command(() =>
            {
                if (Age > 18)
                    Age--;
            });

            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            public ICommand ValidateCommand => new Command(() =>
            {
                // Ajoutez votre logique de validation ici
                Console.WriteLine($"L'âge validé est {Age}");
            });

            private async void OnValidateButtonClicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new SecondQuestionPage());
            }

        }

    }
}