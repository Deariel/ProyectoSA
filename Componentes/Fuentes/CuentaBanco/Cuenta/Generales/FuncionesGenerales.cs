using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Cuenta.Generales
{
    class FuncionesGenerales
    {
        public static bool DataSetVacio(DataSet obj)
        {
            if (obj.Tables[0].Rows.Count == 0 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GenerarNumeroCuenta(string str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}
