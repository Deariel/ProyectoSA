using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Entidad
/// </summary>
namespace RequestContribuyente
{
    public class CrearContribuyente
    {
        public string Nombre { get; set; }
    }
}
namespace ResponseContribuyente
{
    public class CrearContribuyente
    {
        public int Estado { get; set; }
        public string MensajeRespuesta { get; set; }
        public string NIT { get; set; }
    }
}