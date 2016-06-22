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
        public string NoCuenta { get; set; }
        public string NumeroCuentaCPX { get; set; }
        public double PagoTotal { get; set; }
    }
}
namespace ResponseGeneral
{
    public class RecepcionPago
    {
        public int Estado { get; set; }
        public string MensajeRespuesta { get; set; }
    }
    public class CreacionCuenta
    {
        public int Estado { get; set; }
        public string MensajeRespuesta { get; set; }
        public string NumCuenta { get; set; }
    }
}
namespace RequestCreacionCuenta
{
    public class CreacionCuenta
    {
        public Datos_Personales DatosPersonales = new Datos_Personales();
        public Datos_Cuenta Cuenta = new Datos_Cuenta();
    }
    public class Datos_Personales
    {
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
    }
    public class Datos_Cuenta
    {
        public string  TipoCuenta { get; set; }
        public string Password { get; set; }
        public string NoTarjeta { get; set; }
        public Double  Saldo { get; set; }
    }
}
