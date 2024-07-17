using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    class PokemonNegocio
    {
        public List<Pokemon> Listar()
        {
            List<Pokemon> listaPokemones = new List<Pokemon>();

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server= .\\SQLEXPRESS; database= POKEDEX_DB; integrated security= true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select P.Nombre, P.Numero, P.Descripcion, P.UrlImagen, E.Descripcion Tipo, T.Descripcion Debilidad from POKEMONS P, ELEMENTOS E, ELEMENTOS T where P.IdTipo = E.Id and T.Id = P.IdDebilidad";

                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Pokemon auxPokemon = new Pokemon();
                    auxPokemon.Nombre = (string)lector["Nombre"];
                    auxPokemon.Numero = (int)lector["Numero"];
                    auxPokemon.Descripcion = (string)lector["Descripcion"];
                    auxPokemon.UrlImagen = (string)lector["UrlImagen"];
                    auxPokemon.Tipo = new Elemento();
                    auxPokemon.Tipo.Descripcion = (string)lector["Tipo"];
                    auxPokemon.Debilidad = new Elemento();
                    auxPokemon.Debilidad.Descripcion = (string)lector["Debilidad"];


                    listaPokemones.Add(auxPokemon);
                }

                return listaPokemones;
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                conexion.Close();
            }







        }
    }
}