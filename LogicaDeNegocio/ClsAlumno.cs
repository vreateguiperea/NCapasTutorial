using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoaDatos;
using System.Data;


namespace LogicaDeNegocio
{
    public class ClsAlumno
    {
        public String m_Dni { get; set; }
        public String m_Apellidos { get; set; }
        public String m_Nombres { get; set; }
        public Char m_Sexo { get; set; }
        public DateTime m_FechaNac { get; set; }
        public String m_Direccion { get; set; }

        ClsManejadores M = new ClsManejadores(); // agregamos referecio al ClsManejador

        //Registrar Alumnos
        public String Registrar_Alumnos()
        {
            String msj="";
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {
                //pasamos los parametros de entrada
                lst.Add(new ClsParametros("@dni", m_Dni));
                lst.Add(new ClsParametros("@Apellidos", m_Apellidos));
                lst.Add(new ClsParametros("@Nombres", m_Nombres));
                lst.Add(new ClsParametros("@Sexo", m_Sexo));
                lst.Add(new ClsParametros("@FechaNac", m_FechaNac));
                lst.Add(new ClsParametros("@Direccion", m_Direccion));
                //Pasamos el parametro de salida
                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));

                M.Ejecutar_SP("Registrar_Alumnos", lst);
                msj = lst[6].Valor.ToString();

            }
            catch(Exception ex)
            {
                throw ex;
            }
            
            return msj;

        }

        //Metodo para listado de alumnos

        public DataTable ListadoAlumnos()
        {
            return M.Listado("ListadoAlumnos", null);
        }




    }
}
