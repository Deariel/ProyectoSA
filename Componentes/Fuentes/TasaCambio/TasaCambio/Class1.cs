using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasaCambio
{
    public class ManejoTasa
    {
        public void agregarTasa(int Moneda, double valor)
        {

            DateTime thisDay = DateTime.Now;
            String sql = "insert into TASACAMBIO ( IDFechCambio,IDMoneda,Valor ) VALUES ('" + thisDay.ToString("yyyyMMdd HH:mm:ss") + "'," + Moneda.ToString() + "," + this.getDecimal(valor) + ");";
            this.guardarBD(sql);
        }


        public void agregarTasa(double valor)
        {

            DateTime thisDay = DateTime.Now;
            String sql = "insert into TASACAMBIO   ( IDFechCambio,IDMoneda,Valor ) VALUES ('" + thisDay.ToString("yyyyMMdd HH:mm:ss") + "',1," + this.getDecimal(valor) + ");";
            this.guardarBD(sql);
        }

        public double obtenerTasaCambio()
        {
            return obtValorTasa(1);
        }

        public double obtenerTasaCambio(int moneda)
        {
            return obtValorTasa(moneda);
        }

        private string getDecimal(double valor)
        {
            String val = valor.ToString();
            return val.Replace(",", ".");
        }


        private double obtValorTasa(int moneda)
        {
            ConexionBanco.Conexion coB = new ConexionBanco.Conexion();
            String sql = "Select valor from TasaCambio tc(nolock) " +
                          "  inner join ( " +
                          "      Select  MAX(IDFechCambio) IDFechCambio from TasaCambio (nolock) " +
                          "  where IDMoneda = " + moneda.ToString() + "   " +
                          ")Dat on " +
                        "Dat.IDFechCambio = Tc.IDFechCambio " +
                        " where IDMoneda = " + moneda.ToString() + "  ";
            String res = coB.selectstring(sql);
            return Convert.ToDouble(res);


        }

        private void guardarBD(String sql)
        {
            ConexionBanco.Conexion coB = new ConexionBanco.Conexion();
            Console.WriteLine(sql);
            coB.executecommand(sql);

        }


    }
}
