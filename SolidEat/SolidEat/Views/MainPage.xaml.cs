using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
            BindingContext = new MainViewModel(Navigation);
        }

        private async void OnValidateButtonClicked(object sender, EventArgs e)
        {
            var model = (MainViewModel)BindingContext;
            Application.Current.Properties["tempAge"] = model.Age;  // Stockage de l'âge
            await Application.Current.SavePropertiesAsync();
            await Navigation.PushAsync(new SecondQuestionPage(model.Age));
        }


        public class MainViewModel : INotifyPropertyChanged
        {
            private int _age = 18;

            public int Age
            {
                get { return _age; }
                set
                {
                    if (_age != value)
                    {
                        _age = value;
                        OnPropertyChanged(nameof(_age));
                    }
                }
            }


            public ICommand IncrementCommand => new Command(() =>
            {
                if (Age < 99)
                {
                    Age++;
                    OnPropertyChanged(nameof(Age)); // Make sure OnPropertyChanged is called here
                }
            });

            public ICommand DecrementCommand => new Command(() =>
            {
                if (Age > 18)
                {
                    Age--;
                    OnPropertyChanged(nameof(Age)); // And also here
                }
            });


            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            public ICommand ValidateCommand { get; }

            public MainViewModel(INavigation navigation)
            {
                ValidateCommand = new Command(async () =>
                {
                    // Utilisation de navigation passée au ViewModel
                    await navigation.PushAsync(new SecondQuestionPage(this._age));
                });
            }

        }

    }

}