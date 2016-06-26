﻿using System;
using System.Collections.Generic;
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
    public string RequestCrearContribuyente(string xmlContribuyente) {
        RequestContribuyente.CrearContribuyente contribuyente = new RequestContribuyente.CrearContribuyente ();
        contribuyente = (RequestContribuyente.CrearContribuyente)ConvertirXML.XmlDeserealizar(xmlContribuyente, typeof(RequestContribuyente.CrearContribuyente));
        GestionSat.Class1 crearContribuyente = new GestionSat.Class1();
        string nitContribuyente = crearContribuyente.CrearContribuyente("7821998-1");
        ResponseContribuyente.CrearContribuyente xml = new ResponseContribuyente.CrearContribuyente();
        if (!nitContribuyente.Equals("-1"))
        {
            xml.Estado = 0;
            xml.MensajeRespuesta = "Transaccion Exitosa";
            xml.NIT = nitContribuyente;
        }
        else
        {
            xml.Estado = 1;
            xml.MensajeRespuesta = "Transaccion Fallida. Intentelo de nuevo mas tarde.";
        }

        //Guardar Transaccion en BitacoraSat
        BitacoraSat.Class1 transaccion = new BitacoraSat.Class1();
        String Respuesta = ConvertirXML.XmlSerializar(xml);
        transaccion.InsertarTransaccion(Respuesta, xmlContribuyente, "", "RequestCrearContribuyente");

        return Respuesta;
    }
    
}