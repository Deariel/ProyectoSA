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
    }
}
