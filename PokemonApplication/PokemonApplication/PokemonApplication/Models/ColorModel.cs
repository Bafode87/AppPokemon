using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApplication.Models
{
    public class ColorModel
    {
        public static Dictionary<string, string> colorOfPokemon { get; } = new Dictionary<string, string>
        {
             { "rouge","red" },
            { "bleu","blue" },
            { "vert","green" },
            { "jaune", "yellow"},
            { "rose","pink" },
            { "violet", "purple" },
            { "brun","brown" },
            { "gris","gray" },
            { "blanc","white" },
            {"noir" ,"black" },
        };
} 
}
