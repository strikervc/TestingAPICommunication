using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestingAPICommunication.Models;
using TestingAPICommunication.Services;
using TestingAPICommunication.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TestingAPICommunication.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();
       
        public ICommand WordCommand { get; set; }

        public Definition definition = new Definition();

        WordsService wordService = new WordsService();

        public string Word { get; set; }
        public MainViewModel()
        {

            WordCommand = new Command(OnWord);
        }

        private async void OnWord()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                string meaning = "";

                definition = await wordService.GetDefinitionAsync(Word);

                foreach (Item item in definition.Definitions)
                {
                    Items.Add(item);
                    meaning = item.Definition;   
                }

                await App.Current.MainPage.DisplayAlert("Definition", meaning, "Ok");

            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Alert", "No hay conexión a internet", "Ok");
            }
        }
    } 
}
