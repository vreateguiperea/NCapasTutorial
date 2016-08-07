using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AccesoaDatos
{
    public class ClsParametros
    {
        //Parametros
        public String Nombre { get; set; }
        public Object Valor { get; set; }
        public SqlDbType TipoDato { get; set; }
        public Int32 Tamano { get; set; }
        public ParameterDirection Direccion { get; set; }


        //C.Constructores
        //Entrada
        public ClsParametros(String objNombre,Object objValor)
        {
            Nombre = objNombre;
            Valor = objValor;
            Direccion = ParameterDirection.Input;
        }

        //Salida
        public ClsParametros(String objNombre, SqlDbType ObjTipoDato,Int32 objTamano)
        {
            Nombre = objNombre;
            TipoDato = ObjTipoDato;
            Tamano = objTamano;
            Direccion = ParameterDirection.Output;
        }

    }
}
