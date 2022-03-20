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
            int id = Convert.ToInt16(IdOfPokemon.Text);
            //foreach (var pokemoni in await App.PokemonRepository.GetPokemonList())
            //{
            //    int id = 
            //    if (pokemoni.Id == id )
            //    {
            bool answer = await DisplayAlert("Suppression", "Êtes vous sur de vouloir supprimer ce pokemon ?", "Oui", "Non");

            if (answer)
            {
                await App.PokemonRepository.DeletePokemon(id);
                //    }

                //}


                ListOfPokomonViewModel.Instance.MyList.Clear();
                foreach (var poke in await App.PokemonRepository.GetPokemonList())
                {
                    ListOfPokomonViewModel.Instance.MyList.Add(poke);
                }
                //foreach (var pokemoni in await App.PokemonRepository.GetPokemonList())
                //{

                //    ListOfPokomonViewModel.Instance.MyList.Add(pokemoni);
                //}
                await Navigation.PushAsync(new ListOfPokemonView());
                DisplayAlert("Suppression", "Le pokemon a bien été supprimé.", "OK");
            }

        }
    }
}