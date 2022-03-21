using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using PokemonApplication.Models;
using PokemonApplication.ViewModels;
using SQLite;

namespace PokemonApplication.Repository
{

    public class Repository
    {
        
        private SQLiteAsyncConnection connection;
        public string StatusMessage { get; set; }
        
    

        // Création d'une connextion avec la base de données
        // et création des deux tables de la base. Le paramè
        // -tre d'entré renvoie le chemin qui va vers les
        // fichiers de la base de données.
        public Repository(string dbPath)
        {
            connection = new SQLiteAsyncConnection(dbPath);
            connection.CreateTableAsync<PokemonModel>();
            connection.CreateTableAsync<PokemonTeamModel>();

        }



        // Méthode qui sert a inséré un pokemon dans la table
        // "Team". Elle prend en entré un paramètre qui est
        // le pokemon à ajouté dans la table. Pour finir elle
        // renvoie un message de succès ou d'erreur.
        public async Task AddNewPokemonInTeam(PokemonTeamModel pokemonTeam)
        {
            int result = 0;
            try
            {
                result = await connection.InsertAsync(pokemonTeam);
                StatusMessage = $"Le pokemon {pokemonTeam.Name} a été ajouté à l'équipe.";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Le pokemon n'a pas pu être ajouté à l'équipe";
            }
        }



        // Méthode qui sert a inséré un pokemon dans la table
        // "Pokemon". Elle prend en entré un paramètre qui est
        // le pokemon à ajouté dans la table. Pour finir elle
        // renvoie un message de succès ou d'erreur.
        public async Task AddNewPokemon(PokemonModel pokemon)
        {
            int result = 0;
            try
            {
                result = await connection.InsertAsync(pokemon);
                StatusMessage = $"Le pokemon {pokemon.Name} a été ajouté au pokedex";
            }
            catch (Exception ex)
            {
                StatusMessage = "Le pokemon n'a pas pu être ajouté au pokedex";
            }
        }


        // Méthode asynchrone qui sert a supprimer un pokemon de la table
        // "Pokemon". Elle prend en entré un paramètre qui est
        // l'id du pokemon à supprimer dans la table. Pour finir
        // elle renvoie un message de succès ou d'erreur.
        public async Task DeletePokemon(int i)
        {
            int result = 0;
            try
            {
                result = await connection.Table<PokemonModel>().Where(p => p.Id == i).DeleteAsync();
                StatusMessage = $"Le pokémon n° {i} a été supprimé au pokedex"; 
            }
            catch(Exception ex)
            {
                StatusMessage = $"Imposible de supprimer le pokémon n° {i}.\n Erreur : {ex.Message}";
            }
        }

        // Méthode asynchrone qui sert a supprimer l'equipe de pokemon de la 
        //  table "Team". Pour finir elle renvoie un message de
        //  succès ou d'erreur.
        public async Task DeleteTeam()
        {
            int result = 0;
            try
            {
                foreach(PokemonTeamModel pokemonTeam in await App.Repository.GetPokemonTeam())
                {
                    result = await connection.Table<PokemonTeamModel>().Where(p => p.Id == pokemonTeam.Id).DeleteAsync();
                }
                
                StatusMessage = "L'equipe a bien été supprimé";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Imposible de supprimer le pokémon l'équipe;";
            }
        }


        // Méthode qui sert a renvoyé les pokemon de la table
        // "Pokemon". Elle donne en sortie la liste des poke
        // - mons de la table. Pour finir elle renvoie un
        // message d'erreur si elle n'arrive pas à récupérer
        // les pokemon.
        public async Task<List<PokemonModel>> GetPokemonList()
        {
            try
            {
                return await connection.Table<PokemonModel>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Imposible de récupérer la liste des pokemons.\n Erreur : {ex.Message}";

            }

            return new List<PokemonModel>();
        }


        // Méthode qui sert a renvoyé les pokemon de la table
        // "Team". Elle donne en sortie la liste des poke
        // - mons de la table. Pour finir elle renvoie un
        // message d'erreur si elle n'arrive pas à récupérer
        // les pokemon.
        public async Task<List<PokemonTeamModel>> GetPokemonTeam()
        {
            try
            {
                return await connection.Table<PokemonTeamModel>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Imposible de récupérer la liste des pokemons.\n Erreur : {ex.Message}";

            }

            return new List<PokemonTeamModel>();
        }


    }
}
