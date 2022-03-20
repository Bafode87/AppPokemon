
using PokemonApplication.Models;
using PokemonApplication.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokemonApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page4 : ContentPage
    {
        public Page4()
        {
            InitializeComponent();
            BindingContext = ListOfPokomonViewModel.Instance;
        }

        private async void OnItemSelected(Object sender, SelectionChangedEventArgs e)
        {
            PokemonModel selectedPokemon = (e.CurrentSelection.FirstOrDefault() as PokemonModel);
            if (selectedPokemon == null)
            {
                return;
            }
           (sender as CollectionView).SelectedItem = null;
            
        }
    }
}