using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace FacturaElectronica.Afip.Business.Wsaa
{
    /// <summary> 
    /// Clase principal 
    /// </summary> 
    /// <remarks></remarks> 
    public class Ticket
    {

        // Valores por defecto, globales en esta clase 
        public const string DEFAULT_URLWSAAWSDL = "https://wsaahomo.afip.gov.ar/ws/services/LoginCms?WSDL";
        public const string DEFAULT_SERVICIO = "wsfe";
        public const string DEFAULT_CERTSIGNERSUBJECT = "C=AR, O=Socorro Medico Privado SA, SERIALNUMBER=CUIT 30612213417, CN=Vittal";

        /// <summary> 
        /// Funcion Main (consola) 
        /// </summary> 
        /// <param name="args">Argumentos de linea de comandos</param> 
        /// <returns>0 si terminó bien, valores negativos si hubieron errores</returns> 
        /// <remarks></remarks> 
        public static bool GetTicket(out string response)
        {
            response = string.Empty;

            try
            {
                string urlWsaaWsdl = DEFAULT_URLWSAAWSDL;
                string idServicioNegocio = DEFAULT_SERVICIO;
                string certSignerSubject = DEFAULT_CERTSIGNERSUBJECT;

                // Argumentos OK, entonces procesar normalmente... 

                LoginTicket objTicketRespuesta;
                objTicketRespuesta = new LoginTicket();


                StoreName storeName = StoreName.TrustedPeople;
                StoreLocation storeLocation = StoreLocation.CurrentUser;
                response = objTicketRespuesta.ObtenerLoginTicketResponse(idServicioNegocio, certSignerSubject, false, storeName, storeLocation);
                return true;
            }
            catch (Exception excepcionAlObtenerTicket)
            {
                //ErrorsHandler.HandleError("ERROR AL OBTENER TICKET", excepcionAlObtenerTicket, true);
                return false;
            }
        }
    }
}
