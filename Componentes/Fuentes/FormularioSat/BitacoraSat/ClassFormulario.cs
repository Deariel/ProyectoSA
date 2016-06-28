using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormularioSat
{
    public class Class1
    {       
        public int InsertarFormulario(int Manifiesto)
        {
            int Formulario;
            ConexionSat.Conexion conexion = new ConexionSat.Conexion();
            String sql;
            sql = "INSERT INTO Formulario ( NumeroManifiesto) values(" + Manifiesto.ToString() + ")";
            conexion.executecommand(sql);
            return Formulario = ObtenerFormulario(Manifiesto);
        }

        public int ObtenerFormulario(int Manifiesto)
        {
            ConexionSat.Conexion conexion = new ConexionSat.Conexion();
            String sql;
            sql = "SELECT idFormulario from Formulario where NumeroManifiesto = " + Manifiesto.ToString() + ")";
            String Codigo = conexion.executecommand(sql).ToString();
            return Int32.Parse(Codigo);
        }

        public int ConsultarEstadoFormulario(int NumFormulario)
        {
            ConexionSat.Conexion conexion = new ConexionSat.Conexion();
            String sql;
            sql = "SELECT Estado from Formulario where idFormulario = " + NumFormulario;
            String Codigo = conexion.selectstring(sql);
            if (Codigo.Trim().Equals(""))
            {
                return -1;
            }
            else
            {
                return Int32.Parse(Codigo);
            }
        }

    }
}
