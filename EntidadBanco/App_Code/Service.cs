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
        return pago.NumeroCuenta + " " + pago.NumeroCuentaCPX + " " + pago.PagoTotal; 
    }

    [WebMethod ]
    public string ResponseRecepcionPagoCPX()
    {
        ConexionBanco.Conexion conexion = new ConexionBanco.Conexion();
        DataSet resultado = conexion.SelectDataSet("select * from usuario", "Usuario");
        ResponseGeneral.RecepcionPago xml = new ResponseGeneral.RecepcionPago();
        xml.Estado = 0;
        xml.MensajeRespuesta = "Transaccion Exitosa";
        return ConvertirXML.XmlSerializar(xml);
    }
}