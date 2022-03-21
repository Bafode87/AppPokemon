using PokemonApplication.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PokemonApplication.ViewModels
{
    public class TeamViewModel: BaseViewModel
    {
        private static TeamViewModel _instance = new TeamViewModel();
        public static TeamViewModel Instance { get { return _instance; } }

        public ObservableCollection<PokemonTeamModel> MyList1
        {
            // Le getter retourne l'observable "MyList1" qui contient une liste de Pokemon
            get { return GetValue<ObservableCollection<PokemonTeamModel>>(); }

            // Le setter permet de modifier les valeurs de l'observable "MyList1"
            set { SetValue(value); }
        }

        public TeamViewModel()
        {
            MyList1 = new ObservableCollection<PokemonTeamModel>();

            // Méthode qui permet d'initialiser l'observable "MyList"
            InitList();

        }

        private async void InitList()
        {
            // Variable qui récupère la liste des pokemons de la table "Team" en base de données
            List<PokemonTeamModel> listOfPokemon = await App.Repository.GetPokemonTeam();

            /// Permet d'ajouter les pokemons de la table "Team" en base de données à l'observable "MyList1"
            foreach (PokemonTeamModel pokemon in listOfPokemon)
                {

                    MyList1.Add(pokemon);

                }
            
        }
    }
}
