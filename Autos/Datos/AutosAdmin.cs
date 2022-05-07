using Autos.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Autos.Datos
{
    public class AutosAdmin:ConexionBD
    {


         //Void consult data of database 
        public IEnumerable<AutoModel> Consultar()
        {
            Conectar();
            List<AutoModel> listaut= new List<AutoModel>();
            try
            {
                SqlCommand cmd = new SqlCommand("spConsultar", cn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlDataReader rd=cmd.ExecuteReader();
                while (rd.Read())
                {
                    AutoModel model = new AutoModel()
                    {
                        Idauto = int.Parse(rd[0].ToString()),
                        Marca = (rd[1]+""),
                        Modelo = (rd[2]+"")
                    };
                    listaut.Add(model);
                }
            }catch(Exception ex)
            {
                Console.Write(ex.StackTrace);
            }
            finally
            {
                Desconectar();
            }
            return listaut;

        }
        //Void Save register...
        public void Guardar(AutoModel model)
        {
            Conectar();
            try
            {
                SqlCommand cmd = new SqlCommand("spGuardar", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Idauto",model.Idauto);
                cmd.Parameters.AddWithValue("@Marca", model.Marca);
                cmd.Parameters.AddWithValue("@Modelo", model.Modelo);
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace); 

            }
            finally
            {
                Desconectar();
            }
        }
        //Void for Delete register.... fix
        public void Delete(AutoModel model)
        {
            Conectar();
            try
            {
                SqlCommand cmd = new SqlCommand("spEliminar", cn);
                cmd.CommandType=System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Idauto", model.Idauto);
                cmd.ExecuteNonQuery();
            }catch(Exception ex)
            {
                Console.Write(ex.StackTrace);

            }
            finally
            {
                Desconectar();
            }
        }
    }
}