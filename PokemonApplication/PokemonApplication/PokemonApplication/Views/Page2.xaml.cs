using Newtonsoft.Json;
using PokeApiNet;
using PokemonApplication.Models;
using PokemonApplication.ViewModels;
using PokemonApplication.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokemonApplication.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
   
        public Page2()
        {
            InitializeComponent();
            BindingContext = SecondViewModel.Instance;

        }

       private async void OnItemSelected(Object sender, SelectionChangedEventArgs e)
        {
            PokemonModel selectedPokemon = (e.CurrentSelection.FirstOrDefault() as PokemonModel);
            if (selectedPokemon == null)
            {
                return;
            }
            (sender as CollectionView).SelectedItem = null;
            await Navigation.PushAsync(new Page2Detail(selectedPokemon));
        }

      
    }

}