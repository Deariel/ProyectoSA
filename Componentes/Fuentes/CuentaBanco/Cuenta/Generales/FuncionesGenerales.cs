using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
    }
}
