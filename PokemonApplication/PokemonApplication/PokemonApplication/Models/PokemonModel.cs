using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PokemonApplication.Models
{
    public class PokemonModel
    {
        public string Name { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public string Id { get; set; }

        public string Type1 { get; set; }
        public string Type2 { get; set; }

        public double Stat1 { get; set; }
        public double Stat2 { get; set; }
        public double Stat3 { get; set; }
        public double Stat4 { get; set; }
        public double Stat5 { get; set; }
        public double Stat6{ get; set; }

        public string NomStat1  { get; set; }
        public string NomStat2  { get; set; }
        public string NomStat3  { get; set; }
        public string NomStat4  { get; set; }
        public string NomStat5 { get; set; }
        public string NomStat6  { get; set; }

        public string Couleur { get; set; }  

        public string ImageShiny { get; set; }

        public static Dictionary<string, string> listeDeCouleurs = new Dictionary<string, string>
        {
            { "normal", "#A8A77A" },
            { "fire", "#EE8130" },
            { "water", "#6390F0" },
            { "electric", "#F7D02C" },
            { "grass", "#7AC74C" },
            { "ice", "#96D9D6" },
            { "fighting", "#C22E28" },
            { "poison", "#A33EA" },
            { "ground",  "#E2BF65" },
            {"flying" ,"#A98FF3" },
            {"psychic", "#F95587" },
            {"bug" ,"#A6B91A" },
            {"rock" ,"#B6A136" },
            {"ghost" ,"#735797" },
            {"dragon" ,"#6F35FC" },
            {"dark" ,"#705746" },
            {"steel" ,"#B7B7CE" },
            {"fairy" ,"#D685AD" }

            };


    }
}
