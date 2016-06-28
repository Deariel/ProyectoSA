using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCPXGT
{
    public class Class1
    {
        public int InsertarDetalleManifiesto(int idFormulario,
                                             int categoria,
                                             int cantidad,
                                             double precio,
                                             string descripcion,
                                             double peso)
        {
            string sql = "";
            ConexionCpxGT.Class1 conexion = new ConexionCpxGT.Class1();

            if (conexion.executecommand(sql))
            {
                    sql = "Insert into DetalleFormulario (idFormulario, Categoria, Cantidad, Precio, Descripcion, Peso) values ("  + 
                          idFormulario + "," + categoria + "," + cantidad +","+ precio +"," + descripcion.Trim().Replace("'","''")+","+ peso + ")";
                    conexion.executecommand(sql);
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public bool InsertarManifiesto(int Formulario,
                                      int Manifiesto,
                                      double Monto)
        {
            String sql = "Insert into Formulario (idFormulario, NumeroManifiesto, Monto) values (" +
                                                  Formulario + "," + Manifiesto + "," + Monto + ")";
            ConexionCpxGT.Class1 conexion = new ConexionCpxGT.Class1();
            return conexion.executecommand(sql);
        }
    }
}
