using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using API_POKEDEX.Entities.BuscarPokemonPorNombre.Request;
using API_POKEDEX.Entities.VerInformacionPokemon.Request;

namespace API_POKEDEX.Data
{
    public class PokemonService
    {
        SqlConnection SqlCN;

        public PokemonService()
        {
            var configuration = GetConfiguration();
            SqlCN = new SqlConnection(configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value);
        }
        IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

        public DataSet BuscarPokemonPorNombre(RequestBuscarPokemonPorNombre oPokemonRequest)
        {
            using (SqlConnection cn = SqlCN)
            {
                DataSet ds = new DataSet();
                SqlDataAdapter sql_adapter;
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_BuscarPokemonPorNombre", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@TextoBusqueda", oPokemonRequest.ValorBusqueda));
                        sql_adapter = new SqlDataAdapter(cmd);
                        sql_adapter.Fill(ds);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cn.Close();
                    cn.Dispose();
                }
                return ds;
            }
        }

        public DataSet VerInformacionPokemon(RequestVerInformacionPokemon oPokemonRequest)
        {
            using (SqlConnection cn = SqlCN)
            {
                DataSet ds = new DataSet();
                SqlDataAdapter sql_adapter;
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_VerInformaciónPorId", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@idPokemon", oPokemonRequest.idPokemon));
                        sql_adapter = new SqlDataAdapter(cmd);
                        sql_adapter.Fill(ds);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cn.Close();
                    cn.Dispose();
                }
                return ds;
            }
        }

    }
}
