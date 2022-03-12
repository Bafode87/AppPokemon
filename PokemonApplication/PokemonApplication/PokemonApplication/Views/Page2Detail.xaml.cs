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
    public partial class Page2Detail : ContentPage
    {
        public Page2Detail( PokemonModel pokemon)
        {
            InitializeComponent();
           BindingContext = pokemon;
            
        }
    }
}