using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PokeApiNet;

namespace ProbarConectarPokeApi_DAL
{
    public class Listados
    {
        public static async Task<Pokedex> pruebaAsync() {
            
            PokeApiClient apiClient = new PokeApiClient();
            Pokedex pokemon = await apiClient.GetResourceAsync<Pokedex>(1);

            return pokemon;
        }
    }
}
