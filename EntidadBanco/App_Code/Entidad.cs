using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RecepcionPago
/// </summary>
namespace RequestRecepcionPago
{
    public class RecepcionPago
    {
        public string NumeroCuenta { get; set; }
        public string NumeroCuentaCPX { get; set; }
        public double PagoTotal { get; set; }
    }
}
namespace ResponseGeneral
{
    public class RecepcionPago
    {
        public int Estado { get; set; }
        public string MensajeRespuesta { get; set;}
    }
}
