using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_POKEDEX.Entities.Models;

namespace API_POKEDEX.Entities.VerInformacionPokemon.Response
{
    public class ResponseVerInformacionPokemon
    {
        public int id_pokemon { get; set; }
        public string nombre_pokemon { get; set; }
        public string img_pokemon { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public List<Tipos> Tipos { get; set; }
        public List<Habilidades> Habilidades { get; set; }
        public Base Base { get; set; }
    }
}
