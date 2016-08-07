using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AccesoaDatos
{
    public class ClsManejadores
    {
        SqlConnection conexion = new SqlConnection("Server=.;DataBase=DemoNCapas;Integrated Security=True");
        //metodo abrir conexion

        void abrir_conexion()
        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();

        }

        void cerrar_conexion()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
        }

        //Metodos para ejecutar SP
        public void Ejecutar_SP(String NombreSP,List<ClsParametros> lst)
        {
            SqlCommand cmd;
            try
            {
                abrir_conexion();
                cmd = new SqlCommand(NombreSP, conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                if(lst!=null)
                {
                    for(int i=0;i<lst.Count;i++)
                    {
                        if(lst[i].Direccion==ParameterDirection.Input)
                        {
                            cmd.Parameters.AddWithValue(lst[i].Nombre, lst[i].Valor);
                        }

                        if (lst[i].Direccion ==ParameterDirection.Output)
                        {
                            cmd.Parameters.Add(lst[i].Nombre, lst[i].TipoDato, lst[i].Tamano).Direction = ParameterDirection.Output;
                        }
                    }
                    cmd.ExecuteNonQuery();

                    //recuperar parametro de salida

                    for(int i=0; i<lst.Count;i++)
                    {
                        if (cmd.Parameters[i].Direction == ParameterDirection.Output)
                            lst[i].Valor = cmd.Parameters[i].Value.ToString();
                    }
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
            cerrar_conexion();
        }

        //Metodos para ejecutar Listados o Consultas

        public DataTable Listado(String NombreSP, List<ClsParametros> lst)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da;
            try
            {
                da = new SqlDataAdapter(NombreSP, conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                if(lst !=null)
                {
                    for (int i = 0; i < lst.Count; i++)
                    {
                        da.SelectCommand.Parameters.AddWithValue(lst[i].Nombre, lst[i].Valor);
                    }
                }

                da.Fill(dt);
            }
            catch(Exception ex)
            {

                throw ex;
            }

            return dt;
        }

    }
}
