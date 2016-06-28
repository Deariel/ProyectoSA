using Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for Entidad
/// </summary>
namespace ClaseMaestra
{
    public class ClaseMaestraClass
    {
        public string NumeroTracking { get; set; }
        public int Cantidad { get; set; }
        public int Categoria { get; set; }
        public double Peso { get; set; }
        public double precio { get; set; }
        public string Descripcion { get; set; }
        public int PorcentajeArancelIndiviual { get; set; }
        public double Monto { get; set; }
        public List<DefinicionItem> Detalle = new List<DefinicionItem>();
        public int Transacion { get; set; }
        public int NumeroManifiesto { get; set; }
        public int Estado { get; set; }
        public int NumeroCuentaAcreditar { get; set; }
        public int NumeroTarjeta { get; set; }
        public int TipoPago { get; set; }
        public int NumeroFormulario { get; set; }
        public int NumeroOrden { get; set; }
        public string HTMLPDF { get; set; }
        public int EstadoFormulario { get; set; }
    }
}