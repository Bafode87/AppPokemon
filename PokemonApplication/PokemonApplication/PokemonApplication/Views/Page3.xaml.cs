

using PokemonApplication.Models;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PokemonApplication.ViewModels;
using System;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.Linq;

namespace PokemonApplication.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3 : ContentPage
    {
        public Page3()
        {
            InitializeComponent();

        }
    







        private async void OnTakePicture(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Impossible", "Votre appareil ne prend pas en charge cette fonctionnalité!", "OK");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync();
            if (file == null)
                return;
            image.Source = ImageSource.FromStream(() => file.GetStream());
            
            

        }



      
        private async void OnNewButtonClicked(object sender, System.EventArgs e)
        {
            statusMessage.Text = "";
            PokemonModel pokemon = new PokemonModel();
            pokemon.Name = newPokemonName.Text;
            pokemon.Type1 = picker.SelectedItem.ToString();



            await App.PokemonRepository.AddNewPokemon(pokemon);
            List<PokemonModel> pokemons_bd = await App.PokemonRepository.GetPokemonList();
            SecondViewModel.Instance.MyList.Clear();
            foreach (var pokemoni in pokemons_bd)
            {
                SecondViewModel.Instance.MyList.Add(pokemoni);
            }

            statusMessage.Text = App.PokemonRepository.StatusMessage;
           

        }
    }
}
