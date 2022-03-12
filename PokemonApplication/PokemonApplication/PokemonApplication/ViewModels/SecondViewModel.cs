using PokeApiNet;
using PokemonApplication.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApplication.ViewModels
{
    public class SecondViewModel : BaseViewModel
    {
        private static SecondViewModel _instance = new SecondViewModel();
        public static SecondViewModel Instance { get { return _instance; } }

        public ObservableCollection<PokemonModel> MyList
        {
            get { return GetValue<ObservableCollection<PokemonModel>>(); }
            set { SetValue(value); }
        }

        public SecondViewModel()
        {
            MyList = new ObservableCollection<PokemonModel>();
            InitList();
        }

        public async void InitList()
        {
            List<PokemonModel> pokemons_bd = await App.PokemonRepository.GetPokemonList();
            PokeApiClient pokeClient = new PokeApiClient();
            PokeApiClient pokeApiClient = new PokeApiClient();




            if (pokemons_bd.Count != 0)
            {
                foreach (PokemonModel pokemoni in pokemons_bd)
                {
                    MyList.Add(pokemoni);
                }
            }
            else
            {



                for (int i = 1; i <= 50; i++)
                {




                    PokeApiNet.Pokemon pokemon = await Task.Run(() => pokeClient.GetResourceAsync<Pokemon>(i));

                    PokemonModel mypokemon = new PokemonModel();
                    mypokemon.Name = pokemon.Name;



                    mypokemon.Image = pokemon.Sprites.FrontDefault;
                    mypokemon.Id = pokemon.Id;
                    mypokemon.Type1 =  pokemon.Types[0].Type.Name;
                    mypokemon.Stat1 = ((double)pokemon.Stats[0].BaseStat / 100);
                    mypokemon.Stat2 = ((double)pokemon.Stats[1].BaseStat / 100);
                    mypokemon.Stat3 = ((double)pokemon.Stats[2].BaseStat / 100);
                    mypokemon.Stat4 = ((double)pokemon.Stats[3].BaseStat / 100);
                    mypokemon.Stat5 = ((double)pokemon.Stats[4].BaseStat / 100);
                    mypokemon.Stat6 = ((double)pokemon.Stats[5].BaseStat / 100);
                    mypokemon.Couleur = ColorModel.listeDeCouleurs[mypokemon.Type1.ToLower()];
                    if (i < 31)
                    {
                        PokeApiNet.Characteristic characteristic = await Task.Run(() => pokeClient.GetResourceAsync<Characteristic>(i));
                        
                            mypokemon.Description = characteristic.Descriptions[3].Description.ToLower();
                        
                        
                        
                       
                    }

                    if (mypokemon.Description == null)
                    {
                        mypokemon.Description = "Pas de description";
                    }

                    if (pokemon.Types.Count == 2)
                    {
                        mypokemon.Type2 = pokemon.Types[1].Type.Name;

                    }



                    await App.PokemonRepository.AddNewPokemon(mypokemon);
                    MyList.Add(mypokemon);




                }

            }

        }

            }
           

    }
