﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bitacora
{
    public class Class1
    {
        public void InsertarTransaccion(String TramaEnviada,
                                       String TramaRecivida,
                                       String numTransaccion,
                                       String Detalle)
        {
            ConexionBanco.Conexion conexion = new ConexionBanco.Conexion();
            String sql;
            string datos="";
            string valores="";

            if (!TramaEnviada.Trim().Equals("")) { datos = "tramaEnviada"; valores = "'" + TramaEnviada.Trim() + "'"; }
            if (!TramaRecivida.Trim().Equals("")) { if (datos.Equals("")){ datos = "tramaEnviada"; valores = "'" + TramaEnviada.Trim() + "'"; } else { datos += ",tramaRecivida"; valores += ",'" + TramaRecivida.Trim() + "'"; } }
            if (!numTransaccion.Trim().Equals("")) { if (datos.Equals("")) { datos = "numTransaccion"; valores = "'" + numTransaccion.Trim() + "'"; } else { datos += ",numTransaccion"; valores += ",'" + numTransaccion.Trim() + "'"; } }
            if (!Detalle.Trim().Equals("")) { if (datos.Equals("")) { datos = "detalle"; valores = "'" + Detalle.Trim() + "'"; } else { datos += ",detalle"; valores += ",'" + Detalle.Trim() + "'"; } }

            sql = "INSERT INTO BITACORA_BANCO (" + datos + ") values(" + valores + ")";
            conexion.executecommand(sql);
        }
    }
}
