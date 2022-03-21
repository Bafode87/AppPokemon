using PokeApiNet;
using PokemonApplication.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApplication.ViewModels
{
    public class ListOfPokemonViewModel : BaseViewModel
    {
        private static ListOfPokemonViewModel _instance = new ListOfPokemonViewModel();
        public static ListOfPokemonViewModel Instance { get { return _instance; } }

        public ObservableCollection<PokemonModel> MyList
        {
            // Le getter retourne l'observable "MyList" qui contient une liste de Pokemon
            get { return GetValue<ObservableCollection<PokemonModel>>(); }

            // Le setter permet de modifier les valeurs de l'observable "MyList"
            set { SetValue(value); }
        }

        public ListOfPokemonViewModel()
        {
            MyList = new ObservableCollection<PokemonModel>();

            // Méthode qui permet d'initialiser l'observable "MyList"
            InitList();
        }

        public async void InitList()
        {
            // Variable qui récupère la liste des pokemons de la table "Pokemon" en base de données
            List<PokemonModel> listOfPokemon = await App.Repository.GetPokemonList();
          
            // Déclaration et instantiation d'une variable (utilisable grâce au nugget "PokeApiNet") qui va nous permettre de récupérer les données de l'API.
            PokeApiClient pokeApiClient = new PokeApiClient();
           
            // Boucle "if" qui permet de vérifier si la table "Pokemon" en base de données est vide. 
            if (listOfPokemon.Count != 0)
            {
               // Permet d'ajouter les pokemons de la table "Pokemon" en base de données à l'observable "MyList"
                foreach (PokemonModel pokemon in listOfPokemon)
                {
                        MyList.Add(pokemon);
                }
            }
            else
            {
                // Boucle "for" qui permet de récupérer les 50 premiers pokemons de l'API
                for (int i = 1; i <= 50; i++)
                {
                    // Permet de récupérer les pokemons avec leurs attributs
                    PokeApiNet.PokemonSpecies pokemonSpecies = await Task.Run(() => pokeApiClient.GetResourceAsync<PokemonSpecies>(i));

                    // Permet de récupérer les pokemons avec d'autres attributs
                    PokeApiNet.Pokemon pokemon = await Task.Run(() => pokeApiClient.GetResourceAsync<Pokemon>(i));

                    // Déclaration et instanciation d'un pokemon (classe PokemonModel)
                    PokemonModel mypokemon = new PokemonModel();

                    // Permet de récupérer les types des pokemons en français
                    int idOfType;
                    // La méthode "TrimStart" supprime toutes les occurrences du jeu de caractères spécifié dans un tableau au début de la chaîne sur laquelle elle s'applique.
                    string urlOfType = pokemon.Types[0].Type.Url.TrimStart('h', 't', 'p', 's', ':', '/', 'o', 'k', 'a', 'p', 'i', '.', 'c', 'v', '2', 't', 'y', 'p', 'e');
                    // La méthode "Trim" retourne une nouvelle chaîne dans laquelle toutes les occurrences d’un jeu de caractères spécifique sont supprimées au début et à la fin de la chaîne sur laquelle elle s'applique
                    idOfType = Convert.ToInt16(urlOfType.Trim('/'));

                    //Permer de récupérer le type du pokemon
                    PokeApiNet.Type pokemonType = await Task.Run(() => pokeApiClient.GetResourceAsync<PokeApiNet.Type>(idOfType));

                   

                   

                    // Affection du pokemon avec les données provenant de l'API
                    mypokemon.Name = pokemonSpecies.Names[4].Name.ToUpper();
                    mypokemon.FrontPicture = pokemon.Sprites.FrontDefault;
                    mypokemon.BackPicture = pokemon.Sprites.BackDefault;
                    mypokemon.Id = pokemon.Id;
                    mypokemon.Type1 = pokemonType.Names[3].Name.ToLower();
                    mypokemon.Color = pokemonSpecies.Color.Name;
                    mypokemon.HpStatistics = ((double)pokemon.Stats[0].BaseStat / 255);
                    mypokemon.AttackStatistics = ((double)pokemon.Stats[1].BaseStat / 255);
                    mypokemon.DefenseStatistics = ((double)pokemon.Stats[2].BaseStat / 255);
                    mypokemon.SpecialAttackStatistics = ((double)pokemon.Stats[3].BaseStat / 255);
                    mypokemon.SpecialDefenseStatistics = ((double)pokemon.Stats[4].BaseStat / 255);
                    mypokemon.SpeedStatistics = ((double)pokemon.Stats[5].BaseStat / 255);
                    mypokemon.ColorType1 = TypeModel.typesOfPokemon[mypokemon.Type1].Item1;
                    mypokemon.Weight = ((double)pokemon.Weight / 10);
                    mypokemon.Height = ((double)pokemon.Height / 10);
                    mypokemon.Genus = pokemonSpecies.Genera[3].Genus;
                    mypokemon.LogoType1 = TypeModel.typesOfPokemon[mypokemon.Type1].Item2;

                   

                    // Boucle "if" qui permet d'afficher la description d'un pokemon (la véritable description n'est présente que pour les 31 premiers pokemons)
                    if (i < 31)
                    {
                        // Permet de renvoyer les caractéristiques des pokemons
                        PokeApiNet.Characteristic characteristic = await Task.Run(() => pokeApiClient.GetResourceAsync<Characteristic>(i));
                        
                        // Boucle qui permet de récuperer la "deuxième" description en français du pokemon car elle se situe à la position 41 pour le pokemon 10 et le pokemon 19 et non à la 40ème position comme pour les autres pokemons  
                        if (i != 10 && i != 19)
                        {
                            mypokemon.Description = pokemonSpecies.FlavorTextEntries[40].FlavorText + '\n' + characteristic.Descriptions[3].Description + '\n';
                        }
                        else
                        {
                            mypokemon.Description = pokemonSpecies.FlavorTextEntries[41].FlavorText + '\n' + characteristic.Descriptions[3].Description + '\n';
                        }
                    }
                    else
                    {
                        mypokemon.Description = pokemonSpecies.FlavorTextEntries[40].FlavorText;
                    }

                    // Boucle "if" qui permet de récupérer le deuxième type du pokemon si il existe
                    if (pokemon.Types.Count == 2)
                    {
                        string urlOfType2 = pokemon.Types[1].Type.Url.TrimStart('h', 't', 'p', 's', ':', '/', 'o', 'k', 'a', 'p', 'i', '.', 'c', 'v', '2', 't', 'y', 'p', 'e');
                        idOfType = Convert.ToInt16(urlOfType2.Trim('/'));
                        PokeApiNet.Type pokemonType1 = await Task.Run(() => pokeApiClient.GetResourceAsync<PokeApiNet.Type>(idOfType));
                        mypokemon.Type2 = pokemonType1.Names[3].Name.ToLower();
                        mypokemon.ColorType2 = TypeModel.typesOfPokemon[mypokemon.Type2].Item1;
                        mypokemon.LogoType2 = TypeModel.typesOfPokemon[mypokemon.Type2].Item2;
                    }
                    else 
                    {
                        mypokemon.Type2 = "/";
                    }

                    // Ajout du pokemon a la table "Pokemon" en base de données
                    await App.Repository.AddNewPokemon(mypokemon);

                    // Ajout du pokemon a l'observable "MyList"
                    MyList.Add(mypokemon);
                }
            }
        }
    }
}
