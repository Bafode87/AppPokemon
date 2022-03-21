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

namespace PokemonApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListOfPokemonView : ContentPage
    {
   
        public ListOfPokemonView()
        {
            InitializeComponent();
            BindingContext = ListOfPokemonViewModel.Instance;
            // Permet à la vue "ListOfPokemonView" d'acceder au donner du view model "ListOfPokemonViewModel"

        }

        // Méthode asynchrone qui permet d'afficher la page détaillé du pokemon selection dans la CollectionView de la vue
        private async void OnItemSelected(Object sender, SelectionChangedEventArgs e)
        {
            // Récupération du pokemon
            PokemonModel selectedPokemon = (e.CurrentSelection.FirstOrDefault() as PokemonModel);
            if (selectedPokemon == null)
            {
                return;
            }
            (sender as CollectionView).SelectedItem = null;

            // Création d'une nouvelle page de détail pour le pokemon selectionné
            await Navigation.PushAsync(new ListOfPokemonDetailView(selectedPokemon));
        }

        // Méthode qui permet de rechercher un pokemon dans la CollectionView de la vue
        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filteredList = ListOfPokemonViewModel.Instance.MyList.Where(p => p.Name.StartsWith(e.NewTextValue.ToUpper()));
            MyCollectionView.ItemsSource = filteredList;
        }
    }

}