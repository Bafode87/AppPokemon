using Newtonsoft.Json;
using System;
using SQLite;
using System.Collections.Generic;

namespace PokemonApplication.Models
{
    //Création d'une table "Pokemon" dans la base de données
    [Table("Pokemon")]
    public class PokemonModel
    {   
       // Le champ ne peut pas être nul et il doit être unique dans la base de données
       [NotNull, Unique]
        public string Name { get; set; }

        [NotNull]
        public string FrontPicture { get; set; }

        public string BackPicture { get; set; }
        [NotNull]
        public string Description { get; set; }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string Type1 { get; set; }
       
        public string Type2 { get; set; }
        [NotNull]
        public double HpStatistics { get; set; }
        [NotNull]
        public double AttackStatistics { get; set; }
        [NotNull]
        public double DefenseStatistics { get; set; }
        [NotNull]
        public double SpecialAttackStatistics { get; set; }
        [NotNull]
        public double SpecialDefenseStatistics { get; set; }
        [NotNull]
        public double SpeedStatistics{ get; set; }
        [NotNull]
        public string Color { get; set; }
        [NotNull]
        public string ColorType1 { get; set; }  
        public string ColorType2 { get; set; }
        [NotNull]
        public double Weight { get; set; }
        [NotNull]
        public double Height { get; set; }
        [NotNull]
        public string LogoType1 { get; set; }

        public string LogoType2 { get; set; }
      
        [NotNull]
        public string Genus { get; set; }
    }
}
