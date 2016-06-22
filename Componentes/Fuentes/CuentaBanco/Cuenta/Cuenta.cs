using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Cuenta
{
    public class Cuenta
    {
        public DataSet prueba()
        {
            ConexionBanco.Conexion conexion = new ConexionBanco.Conexion();
            DataSet resultado = conexion.SelectDataSet("select * from usuario", "Usuario");
            return resultado;
        }
    }
}
