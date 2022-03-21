using PokemonApplication.Models;
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
    public partial class TeamDetailView : ContentPage
    {
        public TeamDetailView(PokemonTeamModel selectedPokemon)
        {
            InitializeComponent();
            BindingContext = selectedPokemon;
        }
    }
}