using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonApplication.Models;
using PokemonApplication.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;

namespace PokemonApplication.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {

        public string Url;
        public string next;
        public string Previous;
        public Page2()
        {

            InitializeComponent();
            Url = "https://pokeapi.co/api/v2/pokemon?limit=50";
            _ = GetPokemon(Url);

        }
            //pokemons = new ObservableCollection<Pokemons>();
            
            //   for (int i = 0; i < 50; i++) { 
            //    pokemons.Add(new Pokemons{ Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" });
            //    }
            

           

            public async  Task<bool> GetPokemon(string s)
            {
                HttpClient http = new HttpClient();
            var response = await http.GetAsync(s);
            if (response.IsSuccessStatusCode)
            {
                var respString = await response.Content.ReadAsStringAsync();
                var json_s = JsonConvert.DeserializeObject<PokemonApiModel>(respString);

                List<PokemonListModel> list = new List<PokemonListModel>();
                
                foreach(var pokemon in json_s.Results)
                {
                    PokemonListModel n = new PokemonListModel();
                    n.Name = pokemon.Name;
                    n.Url = pokemon.Url;
                    n.UrlImg = "https://img.pokemondb.net/artwork/" + pokemon.Name + ".jpg";

                    list.Add(n);
                }
                
                ListPokemons.ItemsSource = list;
            }
            else
            {

            }
            return true;
            }


        }
    }
