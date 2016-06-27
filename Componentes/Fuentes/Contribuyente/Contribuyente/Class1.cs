using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace Contribuyente
{
    public class GestionContribuyente
    {
        public void CrearContribuyente(
                    String Nit,
                    String DPI,
                    String PNombre,
                    String SNombre,
                    String PApellido,
                    String SApellido,
                    String Direccion,
                    DateTime FNacimiento
                                       )
        {
            String into = "";
            String value = "";
            if (!Nit.Equals("")) { into = "NIT"; value = "'" + Nit + "'"; }
            if (!DPI.Equals("")) { into = into + ",DPI"; value = value + ",'" + DPI + "'"; }
            if (!PNombre.Equals("")) { into = into + ",PNombre"; value = value + ",'" + PNombre + "'"; }
            if (!SNombre.Equals("")) { into = into + ",SNombre"; value = value + ",'" + SNombre + "'"; }
            if (!PApellido.Equals("")) { into = into + ",PApellido"; value = value + ",'" + PApellido + "'"; }
            if (!SApellido.Equals("")) { into = into + ",SApellido"; value = value + ",'" + SApellido + "'"; }
            if (!Direccion.Equals("")) { into = into + ",Direccion"; value = value + ",'" + Direccion + "'"; }
            if (!FNacimiento.Equals("19010101")) { into = into + ",Fnacimiento"; value = value + ",'" + FNacimiento.ToString("yyyyMMdd HH:mm:ss") + "'"; }
            String sql = "INSERT INTO CONTRIBUYENTE (" + into + ") VALUES (" + value + ")";

            ConexionSat.Conexion cSat = new ConexionSat.Conexion();
            cSat.executecommand(sql);

        } // CrearContribuyente

        public void eliminaContribuyente(String nit)
        {
            String sql = "DELETE CONTRIBUYENTE WHERE NIT = '" + nit + "'";
            ConexionSat.Conexion cSat = new ConexionSat.Conexion();
            cSat.executecommand(sql);
        } // eliminar Contribuyente

        public void actualizarContribuyente(
                       String Nit,
                    String DPI,
                    String PNombre,
                    String SNombre,
                    String PApellido,
                    String SApellido,
                    String Direccion,
                    DateTime FNacimiento


            )
        {
            String actualizar = "SET ";
            //if (!Nit.Equals("")) { into = "NIT"; value = "'" + Nit + "'"; }
            if (!DPI.Equals("")) { actualizar = actualizar + " DPI ='" + DPI + "'"; }
            if (!PNombre.Equals("")) { actualizar = actualizar + ", PNombre= '" + PNombre + "'"; }
            if (!SNombre.Equals("")) { actualizar = actualizar + ", SNombre= '" + SNombre + "'"; }
            if (!PApellido.Equals("")) { actualizar = actualizar + ", PApellido ='" + PApellido + "'"; }
            if (!SApellido.Equals("")) { actualizar = actualizar + ", SApellido ='" + SApellido + "'"; }
            if (!Direccion.Equals("")) { actualizar = actualizar + ",Direccion ='" + Direccion + "'"; }
            if (!FNacimiento.Equals("19010101")) { actualizar = actualizar + ",Fnacimiento='" + FNacimiento.ToString("yyyyMMdd HH:mm:ss") + "'"; }

            String sql = "UPDATE CONTRIBUYENTE " + actualizar + " WHERE NIT= '" + Nit + "'";
            ConexionSat.Conexion cSat = new ConexionSat.Conexion();
            cSat.executecommand(sql);

        }// Actualizar Contribuyente

        public Boolean verificaContribuyente(String nit)
        {
            String sql = "Select * from CONTRIBUYENTE (nolock) where NIT = '" + nit + "'";
            ConexionSat.Conexion cSat = new ConexionSat.Conexion();
            DataTable dt = cSat.SelectDataTable(sql);

            int val = dt.Rows.Count;
            if (dt.Rows.Count > 0) return true;
            return false;
        }

        public DataTable obtenerContribuyente(String nit)
        {
            String sql = "Select * from CONTRIBUYENTE (nolock) where NIT = '" + nit + "'";
            ConexionSat.Conexion cSat = new ConexionSat.Conexion();
            return cSat.SelectDataTable(sql);

        }



    }
}
