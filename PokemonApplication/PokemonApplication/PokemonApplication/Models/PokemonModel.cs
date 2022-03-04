using Newtonsoft.Json;
using System;

namespace PokemonApplication.Models
{
    public class PokemonModel
    {
        public string Name { get; set; }

        public string Image { get; set; }

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
        
        

    }
}
