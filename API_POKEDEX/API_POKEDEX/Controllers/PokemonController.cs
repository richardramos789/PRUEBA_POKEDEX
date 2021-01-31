using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_POKEDEX.Data;
using API_POKEDEX.Entities.BuscarPokemonPorNombre.Response;
using API_POKEDEX.Entities.BuscarPokemonPorNombre.Request;
using API_POKEDEX.Entities.VerInformacionPokemon.Response;
using API_POKEDEX.Entities.VerInformacionPokemon.Request;
using API_POKEDEX.Entities.Models;
using System.Data;

namespace API_POKEDEX.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        PokemonService  oDatos = new PokemonService();

        [Route("PokemonByNombre")]
        [HttpPost]
        public List<ResponseBuscarPokemonPorNombre> BuscarPokemonPorNombre([FromBody]RequestBuscarPokemonPorNombre RequestPokemon)
        {
            try
            {
                List<ResponseBuscarPokemonPorNombre> oPokemonResponse = new List<ResponseBuscarPokemonPorNombre>();
                DataSet ds = oDatos.BuscarPokemonPorNombre(RequestPokemon);

                int idPokemon;

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ResponseBuscarPokemonPorNombre oPokemon = new ResponseBuscarPokemonPorNombre();
                        idPokemon = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());

                        oPokemon.id_pokemon = idPokemon;
                        oPokemon.nombre_pokemon = ds.Tables[0].Rows[i]["pokemon_name"].ToString();
                        oPokemon.img_pokemon = ds.Tables[0].Rows[i]["name_img"].ToString();

                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            List<Tipos> oTiposResponse = new List<Tipos>();
                            for (int x = 0; x < ds.Tables[1].Rows.Count; x++)
                            {
                                if (ds.Tables[1].Rows[x]["id"].ToString() == idPokemon.ToString())
                                {
                                    Tipos oENT_Tipos = new Tipos();
                                    oENT_Tipos.Tipo_Nombre = ds.Tables[1].Rows[x]["español_name"].ToString();
                                    oTiposResponse.Add(oENT_Tipos);
                                }
                            }
                            oPokemon.Tipos = oTiposResponse;
                        }
                        
                        oPokemonResponse.Add(oPokemon);
                    }
                }
                return oPokemonResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [Route("VerInformacionPokemon")]
        [HttpPost]
        public List<ResponseVerInformacionPokemon> VerInformacionPokemon([FromBody]RequestVerInformacionPokemon RequestPokemon)
        {
            try
            {
                List<ResponseVerInformacionPokemon> oPokemonResponse = new List<ResponseVerInformacionPokemon>();
                DataSet ds = oDatos.VerInformacionPokemon(RequestPokemon);

                int idPokemon;

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ResponseVerInformacionPokemon oPokemon = new ResponseVerInformacionPokemon();
                        idPokemon = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());

                        oPokemon.id_pokemon = idPokemon;
                        oPokemon.nombre_pokemon = ds.Tables[0].Rows[i]["pokemon_name"].ToString();
                        oPokemon.img_pokemon = ds.Tables[0].Rows[i]["name_img"].ToString();
                        oPokemon.Weight = Convert.ToInt32(ds.Tables[0].Rows[i]["Peso"].ToString());
                        oPokemon.Height = Convert.ToInt32(ds.Tables[0].Rows[i]["Altura"].ToString());

                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            List<Tipos> oTiposResponse = new List<Tipos>();
                            for (int x = 0; x < ds.Tables[1].Rows.Count; x++)
                            {
                                Tipos oENT_Tipos = new Tipos();
                                oENT_Tipos.Tipo_Nombre = ds.Tables[1].Rows[x]["español_name"].ToString();
                                oTiposResponse.Add(oENT_Tipos);
                            }
                            oPokemon.Tipos = oTiposResponse;
                        }

                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            for (int y = 0; y < ds.Tables[2].Rows.Count; y++)
                            {
                                Base oENT_Base = new Base();

                                oENT_Base.HP = Convert.ToInt32(ds.Tables[2].Rows[y]["HP"].ToString());
                                oENT_Base.Attack = Convert.ToInt32(ds.Tables[2].Rows[y]["Attack"].ToString());
                                oENT_Base.Defense = Convert.ToInt32(ds.Tables[2].Rows[y]["Defense"].ToString());
                                oENT_Base.Sp_Attack = Convert.ToInt32(ds.Tables[2].Rows[y]["Sp_Attack"].ToString());
                                oENT_Base.Sp_Deffense = Convert.ToInt32(ds.Tables[2].Rows[y]["Sp_Defense"].ToString());
                                oENT_Base.Speed = Convert.ToInt32(ds.Tables[2].Rows[y]["Speed"].ToString());
                                oPokemon.Base = oENT_Base;
                            }
                        }

                        if (ds.Tables[3].Rows.Count > 0)
                        {
                            List<Habilidades> oHabilidadesResponse = new List<Habilidades>();
                            for (int z = 0; z < ds.Tables[3].Rows.Count; z++)
                            {
                                Habilidades oENT_Habilidad = new Habilidades();

                                oENT_Habilidad.Nombre_Habilidad = ds.Tables[3].Rows[z]["Nombre_Habilidad"].ToString();
                                oHabilidadesResponse.Add(oENT_Habilidad);
                            }
                            oPokemon.Habilidades = oHabilidadesResponse;
                        }

                        oPokemonResponse.Add(oPokemon);
                    }
                }
                return oPokemonResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}