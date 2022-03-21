using PokemonApplication.Models;
using PokemonApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokemonApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListOfPokemonDetailView : ContentPage
    {
        public ListOfPokemonDetailView( PokemonModel pokemon)
        {
            InitializeComponent();
           BindingContext = pokemon;
            
        }

        // Méthode asynchrone qui permet de revenir sur la vue "ListOfPokemonView" lorsqu'on clique sur le boutton qui y est associé
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListOfPokemonView());
        }

        // Méthode asynchrine qui permet de supprimer un pokemon autant dans l'observable MyList que dans la table "Pokemon" en base de données lorsqu'on clique sur le boutton qui y est associé
        private async void deletePokemon(object sender, EventArgs e)
        {
            // Récupère l'id du pokemon à supprimé
            int id = Convert.ToInt16(IdOfPokemon.Text);

            // Pop up pour validation de suppression
            bool answer = await DisplayAlert("Suppression", "Êtes vous sur de vouloir supprimer ce pokemon ?", "Oui", "Non");

            if (answer)
            {
                await App.Repository.DeletePokemon(id);
                ListOfPokemonViewModel.Instance.MyList.Clear();

                // Permet de rafraichir l'observable "MyList"
                foreach (var poke in await App.Repository.GetPokemonList())
                {
                    ListOfPokemonViewModel.Instance.MyList.Add(poke);
                }

                // Retour sur la vue "ListOfPokemonView"
                await Navigation.PushAsync(new ListOfPokemonView());

                // Message de validation
                DisplayAlert("Suppression", "Le pokemon a bien été supprimé.", "OK");
            }

        }


        // Méthode asynchrine qui permet d'ajouter un pokemon dans la table Team en base de données et dans l'observable "MyList1"
        private async void AddPokemonInTeam(object sender, EventArgs e)
        {
            List<PokemonTeamModel> listOfPokemonInTeam = await App.Repository.GetPokemonTeam();
      
                List<PokemonModel> listOfPokemon1 = await App.Repository.GetPokemonList();

                

                PokemonTeamModel pokemonTeam = new PokemonTeamModel();

                foreach (PokemonModel poke in listOfPokemon1)
                {
                    if (poke.Name == Name.Text)
                    {
                        pokemonTeam.Name = poke.Name;
                        pokemonTeam.FrontPicture = poke.FrontPicture;
                        pokemonTeam.BackPicture = poke.BackPicture;
                        pokemonTeam.Description = poke.Description;
                        pokemonTeam.Id = poke.Id;
                        pokemonTeam.Type1 = poke.Type1;
                        pokemonTeam.Type2 = poke.Type2;
                        pokemonTeam.HpStatistics = poke.HpStatistics;
                        pokemonTeam.AttackStatistics = poke.AttackStatistics;
                        pokemonTeam.DefenseStatistics = poke.DefenseStatistics;
                        pokemonTeam.SpecialAttackStatistics = poke.SpecialAttackStatistics;
                        pokemonTeam.SpecialDefenseStatistics = poke.SpecialDefenseStatistics;
                        pokemonTeam.SpeedStatistics = poke.SpeedStatistics;
                        pokemonTeam.Color = poke.Color;
                        pokemonTeam.ColorType1 = poke.ColorType1;
                        pokemonTeam.ColorType2 = poke.ColorType2;
                        pokemonTeam.Weight = poke.Weight;
                        pokemonTeam.Height = poke.Height;
                        pokemonTeam.LogoType1 = poke.LogoType1;
                        pokemonTeam.LogoType2 = poke.LogoType2;
                        pokemonTeam.Genus = poke.Genus;

                        TeamViewModel.Instance.MyList1.Add(pokemonTeam);
                        await App.Repository.AddNewPokemonInTeam(pokemonTeam);

                    }
                }
     
                await DisplayAlert("Ajout", "Le pokemon a bien ete ajouté a l'équipe", "OK");
            
        }
    }
}