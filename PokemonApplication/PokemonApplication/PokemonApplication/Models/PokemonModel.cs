using Newtonsoft.Json;
using System;
using SQLite;
using System.Collections.Generic;

namespace PokemonApplication.Models
{
    [Table("Pokemon")]
    public class PokemonModel
    {
        

       [Unique]
        public string Name { get; set; }

        public string Image { get; set; }

       
        public string Description { get; set; }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Type1 { get; set; }
        public string Type2 { get; set; }

        public double Stat1 { get; set; }
        public double Stat2 { get; set; }
        public double Stat3 { get; set; }
        public double Stat4 { get; set; }
        public double Stat5 { get; set; }
        public double Stat6{ get; set; }
        public string Couleur { get; set; }  

        

        


    }
}
