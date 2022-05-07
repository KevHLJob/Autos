using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace Autos.Datos
{
    public class ConexionBD
    {

        protected SqlConnection cn;
        protected void Conectar()
        {
            try
            {
                //conexion bd local in this case
                //
                cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Repos Visual\Autos\Autos\App_Data\Crud_autos.mdf;Integrated Security=True");
            cn.Open();
            }catch (Exception ex)
            {

                Console.WriteLine(ex.StackTrace);  
            }
        }
        protected void Desconectar()
        {
            try
            {
                cn.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}