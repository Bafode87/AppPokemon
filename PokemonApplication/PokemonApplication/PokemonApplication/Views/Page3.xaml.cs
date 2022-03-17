

using PokemonApplication.Models;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PokemonApplication.ViewModels;
using System;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.Linq;
using System.IO;

namespace PokemonApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3 : ContentPage
    {
        public Page3()
        {
            InitializeComponent();
         
            

        }


        void OnHpSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;
            
            hpLabel.Text = String.Format(" PV : {0}", args.NewValue);
        }

        void OnAttackSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;

            attackLabel.Text = String.Format(" ATT : {0}", args.NewValue);
        }

        void OnDefenseSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;

            defenseLabel.Text = String.Format(" DEF : {0}", args.NewValue);
        }

        void OnSpecialAttackSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;

            specialAttackLabel.Text = String.Format(" SP ATT : {0}", args.NewValue);
        }

        void OnSpecialDefsenseSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;

            specialDefenseLabel.Text = String.Format(" SP DEF : {0}", args.NewValue);
        }

        void OnSpeedSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;

            speedLabel.Text = String.Format(" VIT : {0}", args.NewValue);
        }


        private async void OnTakePicture(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Impossible", "Votre appareil ne prend pas en charge cette fonctionnalité!", "OK");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync();
            if (file == null)
                return;
            image.Source = ImageSource.FromStream(() => file.GetStream());
            lbl.Text = file.Path;
        }



      
        private async void OnNewButtonClicked(object sender, System.EventArgs e)
        {
            
            PokemonModel pokemon = new PokemonModel();
            pokemon.Name = pokemonName.Text;
            pokemon.Type1 = pickerType1.SelectedItem.ToString();
            pokemon.ColorType1 = TypeModel.typesOfPokemon[pokemon.Type1.ToLower()].Item1;
            pokemon.Type2 = pickerType2.SelectedItem.ToString();
            pokemon.ColorType2 = TypeModel.typesOfPokemon[pokemon.Type2.ToLower()].Item1;
            pokemon.FrontPicture = lbl.Text;
            pokemon.Weight = Convert.ToDouble(pokemonWeight.Text);
            pokemon.Height = Convert.ToDouble(pokemonHeight.Text);
            pokemon.Description = pokemonDescription.Text;
            pokemon.HpStatistics = ((double)hpSlider.Value/255);
            pokemon.AttackStatistics = ((double)attackSlider.Value / 255);
            pokemon.DefenseStatistics =((double)defenseSlider.Value/255);
            pokemon.SpecialAttackStatistics = ((double)specialAttackSlider.Value/255);
            pokemon.SpecialDefenseStatistics = ((double)specialDefenseSlider.Value/255);
            pokemon.SpeedStatistics = ((double)speedSlider.Value/255);

            /*if(monpicker != null)
            {
                IsVisible = true
            }*/

            await App.PokemonRepository.AddNewPokemon(pokemon);
            
             
            ListOfPokomonViewModel.Instance.MyList.Clear();
            foreach (var pokemoni in await App.PokemonRepository.GetPokemonList())
            {
                ListOfPokomonViewModel.Instance.MyList.Add(pokemoni);
            }
            
            await DisplayAlert("Ajout", App.PokemonRepository.StatusMessage , "OK");
            await Navigation.PushAsync(new Page3());
           

        }
    }
}
