using PokemonApplication.Models;
using PokemonApplication.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokemonApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2Detail : ContentPage
    {
        public Page2Detail( PokemonModel pokemon)
        {
            InitializeComponent();
           BindingContext = pokemon;
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListOfPokemonView());
        }

        private async void deletePokemon(object sender, EventArgs e)
        {
            foreach (var pokemoni in await App.PokemonRepository.GetPokemonList())
            {
                int id = Convert.ToInt16(IdOfPokemon.Text);
                if (pokemoni.Id == id )
                {
                    await App.PokemonRepository.DeletePokemon(pokemoni);
                }
                
            }

            
            ListOfPokomonViewModel.Instance.MyList.Clear();
            foreach (var pokemoni in await App.PokemonRepository.GetPokemonList())
            {
               
                ListOfPokomonViewModel.Instance.MyList.Add(pokemoni);
            }
            await Navigation.PushAsync(new ListOfPokemonView());

        }
    }
}