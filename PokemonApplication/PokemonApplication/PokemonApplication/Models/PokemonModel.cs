using Newtonsoft.Json;
using System;
using SQLite;
using System.Collections.Generic;

namespace PokemonApplication.Models
{
    // Création d'une table "Pokemon" dans la base de données avec les attributs de la classe. 
    [Table("Pokemon")]
    public class PokemonModel
    {   
       // Dans la base de données, l'attribut Name doit être unique (Unique) et non nul (NotNull).
       [Unique, NotNull]
        public string Name { get; set; }

        public string FrontPicture { get; set; }

        public string BackPicture { get; set; }

        public string Description { get; set; }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Type1 { get; set; }

        public string Type2 { get; set; }

        public double HpStatistics { get; set; }

        public double AttackStatistics { get; set; }

        public double DefenseStatistics { get; set; }

        public double SpecialAttackStatistics { get; set; }

        public double SpecialDefenseStatistics { get; set; }

        public double SpeedStatistics{ get; set; }

        public string Color { get; set; }

        public string ColorType1 { get; set; }  
        public string ColorType2 { get; set; }

        public double Weight { get; set; }
        public double Height { get; set; }

        public string LogoType1 { get; set; }

        public string LogoType2 { get; set; }
      

        public string Genus { get; set; }
   
    }
}
