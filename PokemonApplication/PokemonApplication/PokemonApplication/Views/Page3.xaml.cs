

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


        private async void OnTakeFrontPicture(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Impossible", "Votre appareil ne prend pas en charge cette fonctionnalité!", "OK");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync();
            if (file == null)
                return;
            frontPicture.Source = ImageSource.FromStream(() => file.GetStream());
            lbl.Text = file.Path;
        }

        private async void OnTakeBackPicture(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Impossible", "Votre appareil ne prend pas en charge cette fonctionnalité!", "OK");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync();
            if (file == null)
                return;
            backPicture.Source = ImageSource.FromStream(() => file.GetStream());
            lbl1.Text = file.Path;
        }




        private async void OnNewButtonClicked(object sender, System.EventArgs e)
        {
            
            PokemonModel pokemon = new PokemonModel();
            
            if (pokemonName.Text != null && pickerType1.SelectedItem != null && lbl.Text != null && lbl1.Text != null && pickerColorOfType.SelectedItem != null && pokemonWeight.Text != null && pokemonHeight.Text != null && pokemonGenus.Text != null)
            {
                pokemon.Name = pokemonName.Text.ToUpper();
                pokemon.Type1 = pickerType1.SelectedItem.ToString();
                pokemon.ColorType1 = TypeModel.typesOfPokemon[pokemon.Type1.ToLower()].Item1;
                pokemon.LogoType1 = TypeModel.typesOfPokemon[pokemon.Type1].Item2;
                if (pickerType2.SelectedItem != null)
                {
                    pokemon.Type2 = pickerType2.SelectedItem.ToString();
                    pokemon.ColorType2 = TypeModel.typesOfPokemon[pokemon.Type2.ToLower()].Item1;
                    pokemon.LogoType2 = TypeModel.typesOfPokemon[pokemon.Type2].Item2;
                }
                else
                {
                    pokemon.Type2 = "/";
                }
                pokemon.FrontPicture = lbl.Text;
                pokemon.BackPicture = lbl1.Text;
                pokemon.Color = pickerColorOfType.SelectedItem.ToString();
                pokemon.Weight = Convert.ToDouble(pokemonWeight.Text);
                pokemon.Height = Convert.ToDouble(pokemonHeight.Text);
                pokemon.Description = pokemonDescription.Text;
                pokemon.HpStatistics = ((double)hpSlider.Value / 255);
                pokemon.AttackStatistics = ((double)attackSlider.Value / 255);
                pokemon.DefenseStatistics = ((double)defenseSlider.Value / 255);
                pokemon.SpecialAttackStatistics = ((double)specialAttackSlider.Value / 255);
                pokemon.SpecialDefenseStatistics = ((double)specialDefenseSlider.Value / 255);
                pokemon.SpeedStatistics = ((double)speedSlider.Value / 255);
                pokemon.Genus = pokemonGenus.Text;
                
                List<PokemonModel> listOfPokemon = await App.PokemonRepository.GetPokemonList();
                int position = 0;
                foreach (PokemonModel poke in listOfPokemon)
                {
                    position = position + 1;

                }


                ListOfPokomonViewModel.Instance.MyList.Insert(position, pokemon);
                await App.PokemonRepository.AddNewPokemon(pokemon);

                await DisplayAlert("Ajout", "Le pokémon a bien été ajouté en fin de liste ", "OK");
                
            }
            else
            {
               await DisplayAlert("Erreur", "Tous les champs obligatoires doivent être renseignés", "OK");
            }

            

         
           

           
                
           
            
           
           
            
         

            /*if(monpicker != null)
            {
                IsVisible = true
            }*/



            
            

        }
    }
}
