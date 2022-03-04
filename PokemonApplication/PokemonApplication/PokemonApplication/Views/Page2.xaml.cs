using Newtonsoft.Json;
using PokeApiNet;
using PokemonApplication.Models;
using PokemonApplication.ViewModels;
using PokemonApplication.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokemonApplication.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
   
        public Page2()
        {
            InitializeComponent();
            BindingContext = SecondViewModel.Instance;

        }

       private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as PokemonModel;
            await Navigation.PushAsync(new Page2Detail(item.Name, item.Image, item.Id, item.Type1, item.Type2, item.Stat1, item.Stat2, item.Stat3, item.Stat4, item.Stat5, item.Stat6, item.NomStat1, item.NomStat2, item.NomStat3, item.NomStat4, item.NomStat5, item.NomStat6));
        }
    }

}