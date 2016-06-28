using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ClaseMaestra;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService
{
    public Service()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public ClaseMaestraClass ResquestPagoFormulario(ClaseMaestraClass Manifiesto)
    {
        GestionCPXGT.Class1 guardarManifiesto = new GestionCPXGT.Class1();
        if (guardarManifiesto.InsertarManifiesto(Manifiesto.NumeroFormulario, Manifiesto.NumeroManifiesto, Manifiesto.Monto))
        {
            foreach(Item.DefinicionItem item in Manifiesto.Detalle)
            {
                guardarManifiesto.InsertarDetalleManifiesto(Manifiesto.NumeroFormulario,item.Categoria,item.Cantidad,item.precio,item.Descripcion,item.Peso);
            }
        }

        ClaseMaestraClass pagarBanco = new ClaseMaestraClass();
        pagarBanco.NumeroFormulario = Manifiesto.NumeroFormulario;
        pagarBanco.NumeroCuentaAcreditar = 123456; //Numero de Cuenta de la SAT
        pagarBanco.Monto = Manifiesto.Monto;
        pagarBanco.NumeroTarjeta = 123456; //numero Tarjeta de credito a debitar
        pagarBanco.TipoPago = 1; //Pago de tarjetaCredito

       //consumir servicio del banco para el pago de formulario a la SAT.

        ClaseMaestraClass respuesta = new ClaseMaestraClass();

        //Guardar Transaccion en BitacoraCPXGT respuesta de pago al banco
        BitacoraCpxGT.Class1 transaccion = new BitacoraCpxGT.Class1();
        transaccion.InsertarTransaccion(ConvertirXML.XmlSerializar(respuesta), ConvertirXML.XmlSerializar(pagarBanco), "", "ResquestPagoFormulario");


        //Guardar Transaccion en BitacoraCPXGT respuesta de la solicitud de CPX USA
        transaccion.InsertarTransaccion(ConvertirXML.XmlSerializar(respuesta), ConvertirXML.XmlSerializar(Manifiesto), "", "ResquestPagoFormulario");
        respuesta.Estado = 1;
        return respuesta;
    }
}