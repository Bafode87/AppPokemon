using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using PokemonApplication.Models;
using SQLite;

namespace PokemonApplication.Repository
{

    public class PokemonRepository
    {
        private SQLiteAsyncConnection connection;
        public string StatusMessage { get; set; }
        public PokemonRepository(string dbPath)
        {
            connection = new SQLiteAsyncConnection(dbPath);
            connection.CreateTableAsync<PokemonModel>();

        }

        public async Task AddNewPokemon(PokemonModel pokemon)
        {
            int result = 0;

            try
            {

                result = await connection.InsertAsync(pokemon);
                StatusMessage = $"Le pokémon {pokemon.Name} a été ajouté au pokedex";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Imposible d'ajouter le pokémon : {pokemon.Name}.\n Erreur : {ex.Message}";
            }
        }

        public async Task DeletePokemon(PokemonModel pokemon)
        {
            int result = 0;

            try
            {
                result = await connection.DeleteAsync(pokemon);
                StatusMessage = $"Le pokémon n° {pokemon.Name} a été supprimé au pokedex";
            }
            catch(Exception ex)
            {
                StatusMessage = $"Imposible de supprimer le pokémon n° {pokemon.Name}.\n Erreur : {ex.Message}";
            }
        }

        public async Task<List<PokemonModel>> GetPokemonList()
        {
            try
            {
                return await connection.Table<PokemonModel>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Imposible de récupérer la liste des pokémons.\n Erreur : {ex.Message}";

            }

            return new List<PokemonModel>();
        }


  
    }
}
