using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApplication.Models
{
    public class PokemonApiModel
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("next")]
        public Uri Next { get; set; }

        [JsonProperty("previous")]
        public object Previous { get; set; }

        [JsonProperty("results")]
        public PokemonModel[] Results { get; set; }
    }


}
