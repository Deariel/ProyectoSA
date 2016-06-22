using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService
{
    public Service () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string RequestRecepcionPagoCPX(String XmlRecepcionPagoCpx) {
        RequestRecepcionPago.RecepcionPago pago = new RequestRecepcionPago.RecepcionPago();
        pago = (RequestRecepcionPago.RecepcionPago)ConvertirXML.XmlDeserealizar(XmlRecepcionPagoCpx, typeof(RequestRecepcionPago.RecepcionPago));
        Cuenta.Cuenta realizarpago = new Cuenta.Cuenta();
        int resultado = realizarpago.RealizarCobro(pago.NoCuenta, pago.NumeroCuentaCPX,pago.PagoTotal);
        ResponseGeneral.RecepcionPago xml = new ResponseGeneral.RecepcionPago();
        if (resultado == 0)
        {
            xml.Estado = resultado;
            xml.MensajeRespuesta = "Transaccion Exitosa";
        }
        else if(resultado == -1)
        {
            xml.Estado = 1;
            xml.MensajeRespuesta = "Transaccion Fallida. Intentelo de nuevo mas tarde.";
        }
        else if (resultado == -2)
        {
            xml.Estado = 1;
            xml.MensajeRespuesta = "Transaccion Fallida. No dispone de saldo para realizar la transaccion.";
        }
        return ConvertirXML.XmlSerializar(xml);
    }
}