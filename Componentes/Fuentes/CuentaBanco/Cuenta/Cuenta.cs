using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Cuenta.Generales;

namespace Cuenta
{
    public class Cuenta
    {
        public int RealizarCobro(string NumCuentaDebitar,
                                     string NumCuentaAcreditar,
                                     double MontoPago)
        {
            double saldoDebitar;
            double saldoCuentaDebitar;
            double saldoCuentaAcreditar;
            string sql;
            int resultado = -1;
            ConexionBanco.Conexion conexion = new ConexionBanco.Conexion();
            sql = "select saldo from CUENTA where RTrim(Ltrim(numCuenta)) = '" + NumCuentaDebitar.Trim() + "'";
            saldoDebitar = Convert.ToDouble(conexion.selectstring(sql));
            if (saldoDebitar >= MontoPago)
            {
                saldoCuentaDebitar = saldoDebitar - MontoPago;
                sql = "update cuenta set saldo = " + saldoCuentaDebitar + " where RTrim(Ltrim(numCuenta)) = '" + NumCuentaDebitar.Trim() + "'";
                if (conexion.executecommand(sql))
                {
                    sql = "select saldo from CUENTA where RTrim(Ltrim(numCuenta)) = '" + NumCuentaAcreditar.Trim() + "'";
                    saldoCuentaAcreditar = Convert.ToDouble(conexion.selectstring(sql));
                    saldoCuentaAcreditar = saldoCuentaAcreditar + MontoPago;
                    sql = "update cuenta set saldo = " + saldoCuentaAcreditar + " where RTrim(Ltrim(numCuenta)) = '" + NumCuentaAcreditar.Trim() + "'";
                    if (conexion.executecommand(sql))
                    {
                        resultado = 0;
                    }
                }
            }
            else
            {
                resultado = -2;
            }
            return resultado;
        }

        public string CrearCuenta(string PrimerNombre,
                               string SegundoNombre,
                               string PrimerApellido,
                               string SegundoApellido,
                               string FechaNacimiento,
                               string Telefono,
                               string Direccion,
                               string TipoCuenta,
                               string Password,
                               string NoTarjeta,
                               double Saldo)
        {
            ConexionBanco.Conexion conexion = new ConexionBanco.Conexion();
            string datos="";
            string valores="";

            try {
                //Crear Usuario en DB
                if (!PrimerNombre.Trim().Equals("")) { datos = "primerNombre"; valores = "'"+PrimerNombre.Trim()+ "'"; }
                if (!SegundoNombre.Trim().Equals("")) { if (datos.Equals("")) { datos = "segundoNombre"; valores = "'"+SegundoNombre.Trim()+ "'"; } else { datos += ",segundoNombre"; valores += ",'" + SegundoNombre.Trim()+ "'"; } }
                if (!PrimerApellido.Trim().Equals("")) { if (datos.Equals("")) { datos = "primerApellido"; valores = "'"+PrimerApellido.Trim()+ "'"; } else { datos += ",primerApellido"; valores += ",'" + PrimerApellido.Trim()+ "'"; } }
                if (!SegundoApellido.Trim().Equals("")) { if (datos.Equals("")) { datos = "segundoApellido"; valores = "'"+SegundoApellido.Trim()+ "'"; } else { datos += ",segundoApellido"; valores += ",'" + SegundoApellido.Trim()+ "'"; } }
                if (!FechaNacimiento.Trim().Equals("")) { if (datos.Equals("")) { datos = "fechaNacimiento"; valores = "'"+FechaNacimiento.Trim()+ "'"; } else { datos += ",fechaNacimiento"; valores += ",'" + FechaNacimiento.Trim()+ "'"; } }
                if (!Telefono.Trim().Equals("")) { if (datos.Equals("")) { datos = "telefono"; valores = "'" + Telefono.Trim() + "'"; } else { datos += ",telefono"; valores += ",'" + Telefono.Trim()+ "'"; } }
                if (!Direccion.Trim().Equals("")) { if (datos.Equals("")) { datos = "direccion"; valores = "'"+Direccion.Trim()+ "'"; } else { datos += ",direccion"; valores += ",'" + Direccion.Trim()+ "'"; } }
                if (!Password.Trim().Equals("")) { if (datos.Equals("")) { datos = "password"; valores = "'"+Password.Trim()+ "'"; } else { datos += ",password"; valores += ",'" + Password.Trim()+ "'"; } }
                
                string sql = "INSERT INTO USUARIO (" + datos + ") OUTPUT Inserted.idUsuario values (" + valores + ")";
                int idUsuario = Convert.ToInt32(conexion.selectstring(sql));

                //Crear Cuenta en DB
                Random rnd = new Random();
                string numeroCuenta = rnd.Next(100000, 999999).ToString();
                datos = "";
                valores = "";

                if (!TipoCuenta.Trim().Equals("")) { datos = "tipoCuenta"; valores = TipoCuenta.Trim(); }
                if (!numeroCuenta.Trim().Equals("")) { if (datos.Equals("")) { datos = "numCuenta"; valores = "'"+numeroCuenta.Trim()+ "'"; } else { datos += ",numCuenta"; valores += ",'" + numeroCuenta.Trim()+ "'"; } }
                if (datos.Equals("")) { datos = "saldo"; valores = Saldo.ToString(); } else { datos += ",saldo"; valores += "," + Saldo; }
                if (!idUsuario.ToString().Trim().Equals("")) { if (datos.Equals("")) { datos = "idUsuario"; valores = idUsuario.ToString(); } else { datos += ",idUsuario"; valores += "," + idUsuario; } }
                sql = "INSERT INTO CUENTA (" + datos + ") values (" + valores + ")";

                if (conexion.executecommand(sql)) { return numeroCuenta; }else { return "-1"; }
            }
            catch {
                return "-1";
            }
        }
    }
}
