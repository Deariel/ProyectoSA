using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Entidad
/// </summary>
namespace Item
{
    public class DefinicionItem
    {
        public string NumeroTracking { get; set; }
        public int Cantidad { get; set; }
        public int Categoria { get; set; }
        public double Peso { get; set; }
        public double precio { get; set; }
        public string Descripcion { get; set; }
        public int PorcentajeArancelIndiviual { get; set; }
    }
}