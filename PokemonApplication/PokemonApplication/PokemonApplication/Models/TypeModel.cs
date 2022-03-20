using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace PokemonApplication.Models
{
    public class TypeModel
    {
        //Dictionary contenant les 18 types de Pokémon et les couleurs qui les caractérisent.
        public static Dictionary<string, (string,string)> typesOfPokemon { get; } = new Dictionary<string, (string,string)>
        {
            { "normal", ("#A8A77A", "normal.png") },
            { "feu", ("#EE8130","fire.png") },
            { "eau", ("#6390F0","water.png") },
            { "électrik", ("#F7D02C","electric.png") },
            { "plante", ("#7AC74C","grass.png") },
            { "glace", ("#96D9D6","ice.png") },
            { "combat", ("#C22E28","fighting.png") },
            { "poison", ("#A33EA1","poison.png") },
            { "sol",  ("#E2BF65","ground.png") },
            {"vol" ,("#A98FF3","flying.png") },
            {"psy", ("#F95587","psychic.png") },
            {"insecte" ,("#A6B91A","bug.png") },
            {"roche" ,("#B6A136","rock.png") },
            {"spectre" ,("#735797","ghost.png") },
            {"dragon" ,("#6F35FC","dragon.png") },
            {"tenebre" ,("#705746","dark.png") },
            {"acier" ,("#B7B7CE","steel.png") },
            {"fée" ,("#D685AD","fairy.png") },
        };

        
    }
}
