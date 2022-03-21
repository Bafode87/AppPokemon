
using PokemonApplication.Models;
using PokemonApplication.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokemonApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeamView : ContentPage
    {
        public TeamView()
        {
            InitializeComponent();
            BindingContext = TeamViewModel.Instance;
        }

        // Méthode asynchrone qui permet d'afficher la page détaillé du pokemon selection dans la CollectionView de la vue
        private async void OnItemSelected(Object sender, SelectionChangedEventArgs e)
        {
            // Récupération du pokemon
            PokemonTeamModel selectedPokemon = (e.CurrentSelection.FirstOrDefault() as PokemonTeamModel);
            if (selectedPokemon == null)
            {
                return;
            }

            // Création d'une nouvelle page de détail pour le pokemon selectionné
           (sender as CollectionView).SelectedItem = null;
            await Navigation.PushAsync(new TeamDetailView(selectedPokemon));

        }

        // Méthode qui permet de supprimer toute l'équipe de la table "Team" en base de données
        private async void deleteTeam(object sender, EventArgs e)
        {
            await App.Repository.DeleteTeam();
            TeamViewModel.Instance.MyList1.Clear();
        }
    }
}