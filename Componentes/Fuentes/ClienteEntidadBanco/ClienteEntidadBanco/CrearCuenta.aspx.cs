using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteEntidadBanco
{
    public partial class CrearCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCuenta_Click(object sender, EventArgs e)
        {
            WSBanco.ServiceSoapClient crearcuenta = new WSBanco.ServiceSoapClient();
            RequestCreacionCuenta.CreacionCuenta datosCuenta = new RequestCreacionCuenta.CreacionCuenta();
            datosCuenta.DatosPersonales.PrimerNombre = txtPrimerNombre.Text;
            datosCuenta.DatosPersonales.SegundoNombre = txtSegundoNombre.Text;
            datosCuenta.DatosPersonales.PrimerApellido = txtPrimerApellido.Text;
            datosCuenta.DatosPersonales.SegundoApellido = txtSegundoApellido.Text;
            datosCuenta.DatosPersonales.FechaNacimiento = txtFechaNac.Text;
            datosCuenta.DatosPersonales.Direccion = txtDireccion.Text;
            datosCuenta.DatosPersonales.Telefono = txtTelefono.Text;
            datosCuenta.Cuenta.NoTarjeta = "";
            datosCuenta.Cuenta.Password = "123";
            datosCuenta.Cuenta.Saldo = Convert.ToDouble( txtSaldo.Text);
            datosCuenta.Cuenta.TipoCuenta = "1";
            String Respuesta = crearcuenta.RequestCrearCuenta(ConvertirXML.XmlSerializar(datosCuenta));

            ResponseGeneral.CreacionCuenta respuestaCreacion;
            respuestaCreacion = (ResponseGeneral.CreacionCuenta)ConvertirXML.XmlDeserealizar(Respuesta, typeof(ResponseGeneral.CreacionCuenta));
            if (respuestaCreacion.Estado == 0)
            {
                lblRespuesta.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                lblRespuesta.ForeColor = System.Drawing.Color.Red;
            }
            lblRespuesta.Visible = true;
            lblRespuesta.Text = respuestaCreacion.MensajeRespuesta + " Su numero de cuenta es: " + respuestaCreacion.NumCuenta;
        }
    }
}