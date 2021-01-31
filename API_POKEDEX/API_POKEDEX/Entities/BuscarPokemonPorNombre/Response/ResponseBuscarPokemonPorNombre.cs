using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_POKEDEX.Entities.Models;

namespace API_POKEDEX.Entities.BuscarPokemonPorNombre.Response
{
    public class ResponseBuscarPokemonPorNombre
    {
        public int id_pokemon { get; set; }
        public string nombre_pokemon { get; set; }
        public string img_pokemon { get; set; }
        public List<Tipos> Tipos { get; set; }
    }
}
