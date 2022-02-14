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

namespace PokemonApplication.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        private ObservableCollection<Pokemons> pokemons;
        public Page2()
        {
            InitializeComponent();
            pokemons = new ObservableCollection<Pokemons>
            {
               
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
                    new Pokemons { Name = "Piplup", Level = "1", ImageSource = "piplup.png", Type = "Eau" },
            };
            ListPokemons.ItemsSource = pokemons;
        }

    }
}