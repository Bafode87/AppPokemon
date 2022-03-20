using PokeApiNet;
using PokemonApplication.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApplication.ViewModels
{
    public class ListOfPokomonViewModel : BaseViewModel
    {
        private static ListOfPokomonViewModel _instance = new ListOfPokomonViewModel();
        public static ListOfPokomonViewModel Instance { get { return _instance; } }

        public ObservableCollection<PokemonModel> MyList
        {
            get { return GetValue<ObservableCollection<PokemonModel>>(); }
            set { SetValue(value); }
        }

        public ListOfPokomonViewModel()
        {
            MyList = new ObservableCollection<PokemonModel>();
            InitList();
        }

        public async void InitList()
        {
            List<PokemonModel> listOfPokemon = await App.PokemonRepository.GetPokemonList();
            PokeApiClient pokeApiClient = new PokeApiClient();
            PokeApiClient pokeApiClient1 = new PokeApiClient();
            PokeApiClient pokeApiClient2 = new PokeApiClient();
            PokeApiClient pokeApiClient3 = new PokeApiClient();
            PokeApiClient pokeApiClient4 = new PokeApiClient();
            PokeApiClient pokeApiClient5 = new PokeApiClient();
           

            if (listOfPokemon.Count != 0)
            {
               
                foreach (PokemonModel pokemon in listOfPokemon)
                {
                  
                        MyList.Add(pokemon);
                  
                }
            }
            else
            {
                for (int i = 1; i <= 50; i++)
                {
                    int idOfType;


                    PokeApiNet.PokemonSpecies pokemonSpecies = await Task.Run(() => pokeApiClient.GetResourceAsync<PokemonSpecies>(i));
                    PokeApiNet.Pokemon pokemon = await Task.Run(() => pokeApiClient.GetResourceAsync<Pokemon>(i));



                    PokemonModel mypokemon = new PokemonModel();


                    mypokemon.Name = pokemonSpecies.Names[4].Name.ToUpper();

                    mypokemon.FrontPicture = pokemon.Sprites.FrontDefault;
                    mypokemon.BackPicture = pokemon.Sprites.BackDefault;
                    mypokemon.Id = pokemon.Id;
                    string urlOfType = pokemon.Types[0].Type.Url.TrimStart('h', 't', 'p', 's', ':', '/', 'o', 'k', 'a', 'p', 'i', '.', 'c', 'v', '2', 't', 'y', 'p', 'e');


                    idOfType = Convert.ToInt16(urlOfType.Trim('/'));

                    PokeApiNet.Type pokemonType = await Task.Run(() => pokeApiClient3.GetResourceAsync<PokeApiNet.Type>(idOfType));

                    mypokemon.Id = i;
                   
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
                  




                    if (i < 31)
                    {
                        PokeApiNet.Characteristic characteristic = await Task.Run(() => pokeApiClient.GetResourceAsync<Characteristic>(i));
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


                    if (pokemon.Types.Count == 2)
                    {
                        string urlOfType2 = pokemon.Types[1].Type.Url.TrimStart('h', 't', 'p', 's', ':', '/', 'o', 'k', 'a', 'p', 'i', '.', 'c', 'v', '2', 't', 'y', 'p', 'e');
                        idOfType = Convert.ToInt16(urlOfType2.Trim('/'));
                        PokeApiNet.Type pokemonType1 = await Task.Run(() => pokeApiClient3.GetResourceAsync<PokeApiNet.Type>(idOfType));
                        mypokemon.Type2 = pokemonType1.Names[3].Name.ToLower();
                        mypokemon.ColorType2 = TypeModel.typesOfPokemon[mypokemon.Type2].Item1;
                        mypokemon.LogoType2 = TypeModel.typesOfPokemon[mypokemon.Type2].Item2;
                    }

                    if (mypokemon.Type2 == null)
                    {
                        mypokemon.Type2 = "/";
                    }


                    await App.PokemonRepository.AddNewPokemon(mypokemon);
                    MyList.Add(mypokemon);
                }
            }
        }
    }
}
