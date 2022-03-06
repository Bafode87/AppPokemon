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
        public Page2Detail(string Name, string Id, string Type1, string Type2, double Stat1, double Stat2, double Stat3, double Stat4, double Stat5, double Stat6, string NomStat1, string NomStat2, string NomStat3, string NomStat4, string NomStat5, string NomStat6, string Couleur, string Description, string ImageShiny )
        {
            InitializeComponent();
            MonImage.Source = new UriImageSource()
            {
                Uri = new Uri(ImageShiny)

            };
            MonNom.Text =  Name;
            MonId.Text = "Id : " + Id;
            MonType.Text = "Type : " + Type1;
            if (Type2 != null)
            {
                MonType.Text = "Type : " + Type1 + ", " + Type2;
            }
            ProgressBar1.Progress = Stat1;
            ProgressBar2.Progress = Stat2;
            ProgressBar3.Progress = Stat3;
            ProgressBar4.Progress = Stat4;
            ProgressBar5.Progress = Stat5;
            ProgressBar6.Progress = Stat6;
            MaStat1.Text = NomStat1 + "(" + Stat1 * 100 + ")"; 
            MaStat2.Text = NomStat2 + "(" + Stat2 * 100 + ")";;
            MaStat3.Text = NomStat3 + "(" + Stat3 * 100 + ")";
            MaStat4.Text = NomStat4 + "(" + Stat4 * 100 + ")";
            MaStat5.Text = NomStat5 + "(" + Stat5 * 100 + ")";
            MaStat6.Text = NomStat6 + "(" + Stat6 * 100 + ")";
            if (Description != null)
            {
                MaDescription.Text = "Description : " + Description;
            }
            else
            {
                MaDescription.Text = "Description : Pas de description";
            }

            MaCouleur.BackgroundColor = Color.FromHex(Couleur);
            ProgressBar1.ProgressColor = Color.FromHex(Couleur);
            ProgressBar2.ProgressColor = Color.FromHex(Couleur);
            ProgressBar3.ProgressColor = Color.FromHex(Couleur);
            ProgressBar4.ProgressColor = Color.FromHex(Couleur);
            ProgressBar5.ProgressColor = Color.FromHex(Couleur);
            ProgressBar6.ProgressColor = Color.FromHex(Couleur);
           

            MaCouleur1.BackgroundColor = Color.FromHex(Couleur);
            

            
            
            
        }
    }
}