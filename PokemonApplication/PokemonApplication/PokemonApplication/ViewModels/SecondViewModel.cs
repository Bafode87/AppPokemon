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
            PokeApiClient pokeClient = new PokeApiClient();

                for (int i = 1; i <= 50; i++)
                {
                
                PokeApiNet.Pokemon pokemon = await Task.Run(() => pokeClient.GetResourceAsync<Pokemon>(i));
                    PokemonModel mypokemon = new PokemonModel();
                    mypokemon.Name = pokemon.Name;
                    mypokemon.Image = pokemon.Sprites.FrontDefault;
                    mypokemon.Id = pokemon.Id.ToString();
                    mypokemon.Type1 = pokemon.Types[0].Type.Name;
                    mypokemon.Stat1 = ((double)pokemon.Stats[0].BaseStat/100);
                    mypokemon.Stat2 = ((double)pokemon.Stats[1].BaseStat / 100);
                    mypokemon.Stat3 = ((double)pokemon.Stats[2].BaseStat / 100);
                    mypokemon.Stat4 = ((double)pokemon.Stats[3].BaseStat / 100);
                    mypokemon.Stat5 = ((double)pokemon.Stats[4].BaseStat / 100);
                    mypokemon.Stat6 = ((double)pokemon.Stats[5].BaseStat / 100);
                    mypokemon.NomStat1 = pokemon.Stats[0].Stat.Name;
                    mypokemon.NomStat2 = pokemon.Stats[1].Stat.Name;
                    mypokemon.NomStat3 = pokemon.Stats[2].Stat.Name;
                    mypokemon.NomStat4 = pokemon.Stats[3].Stat.Name;
                    mypokemon.NomStat5 = pokemon.Stats[4].Stat.Name;
                    mypokemon.NomStat6 = pokemon.Stats[5].Stat.Name;
                
                    if (pokemon.Types.Count == 2)
                {
                    mypokemon.Type2 = pokemon.Types[1].Type.Name;
                }
                    MyList.Add(mypokemon);
                }
            
        }

    }
}
