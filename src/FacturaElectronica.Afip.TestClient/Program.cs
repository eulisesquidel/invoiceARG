using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacturaElectronica.Afip.Ws.Wsaa;
using System.Security.Cryptography.X509Certificates;
using FacturaElectronica.Afip.Ws.Wsfe;
using FacturaElectronica.Afip.Business.Wsfe;
using FacturaElectronica.Afip.Business.Wsaa;


namespace FacturaElectronica.Afip.TestClient
{
    class Program
    {
        // Valores por defecto, globales en esta clase 
        const string DEFAULT_URLWSAAWSDL = "https://wsaahomo.afip.gov.ar/ws/services/LoginCms?WSDL";
        const string DEFAULT_SERVICIO = "wsfe";
        const string DEFAULT_CERTSIGNER = "f:\\wsaa_test\\MiCertificadoConClavePrivada.pfx";
        const bool DEFAULT_VERBOSE = true;

        /// <summary> 
        /// Funcion Main (consola) 
        /// </summary> 
        /// <param name="args">Argumentos de linea de comandos</param> 
        /// <returns>0 si terminó bien, valores negativos si hubieron errores</returns> 
        /// <remarks></remarks> 
        static int Main(string[] args)
        {
            //TestDummy();
            //GetCertificatesInMyStore();
            GetTiposMonedas();


            while (Console.ReadKey().KeyChar != '1') { };
            return 0;
        }

        private static void TestDummy()
        {
            Console.WriteLine("***Llamando al DummyResponse en URL");
            WsfeClient client = new WsfeClient();
            FacturaElectronica.Afip.Ws.Wsfe.DummyResponse result = client.DummyResponse();
            Console.WriteLine("Result");
            Console.WriteLine(result.AppServer, "DummyResponse.appserver");
        }

        private static void GetTiposMonedas()
        {
            //string certSigner = @"C:\Diego\Proyectos\FacturaElect\Afip - Ejemplos Codigo\FeCertificadoDesarrollo\certificadoAFIP.crt";
            string certSigner = @"C=AR, O=ENDESA, SERIALNUMBER=CUIT 23289508759, CN=TestFE";
            LoginTicket loginTicket = new LoginTicket();
            string ticketReponse = loginTicket.ObtenerLoginTicketResponse(DEFAULT_SERVICIO, certSigner, false, StoreName.TrustedPeople, StoreLocation.CurrentUser);

            string cuit = "23289508759";
            FEAuthRequest feAuthRequest = new FEAuthRequest();
            feAuthRequest.Cuit = Convert.ToInt64(cuit);
            feAuthRequest.Sign = loginTicket.Sign;
            feAuthRequest.Token = loginTicket.Token;
                      
            Console.WriteLine("***Llamando al GetTiposMoneda en URL");
            WsfeClient client = new WsfeClient();
            FacturaElectronica.Afip.Ws.Wsfe.MonedaResponse result = client.GetTiposMonedas(feAuthRequest);
            Console.WriteLine("Result");
            foreach (var item in result.ResultGet)
            {
                Console.WriteLine("item Id: " + item.Id + " Desc: " + item.Desc);
            }
            
        }

        private static void GetCertificatesInMyStore()
        {
            //certificados
            X509Certificate cer = null;
            //X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            X509Store store = new X509Store(StoreName.TrustedPeople, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);

            Console.WriteLine("Certificados");
            int i = 1;
            foreach (X509Certificate cert in store.Certificates)
            {
                //if (cert.Subject == certSubject)
                //{
                //    cer = cert;
                //    break;
                //}
                //Console.WriteLine("Certificado {0}: Subjet-{1} Issuer-{2}", i++, cert.Subject, cert.Issuer);
                if (cert.Subject.Contains("O=ENDESA"))
                { 
                    Console.WriteLine("Certificado {0}: Subjet-{1} Issuer-{2}", i++, cert.Subject, cert.Issuer);
                }
            }
        }

        public static int ObtenerTicketAcceso()
        {
            MostrarVersion();

            string strUrlWsaaWsdl = DEFAULT_URLWSAAWSDL;
            string strIdServicioNegocio = DEFAULT_SERVICIO;
            string strRutaCertSigner = DEFAULT_CERTSIGNER;
            bool blnVerboseMode = DEFAULT_VERBOSE;

            #region -Comment-
            // Analizo argumentos de linea de comandos 
            //if (args.Length == 0)
            //{
            //    ExplicarUso();
            //    return -1;
            //}
            //Console.ReadKey();
            //for (int i = 0; i <= args.Length - 1; i++)
            //{
            //    string argumento;
            //    argumento = args[i];

            //    if (String.Compare(argumento, "-w", true) == 0)
            //    {
            //        if (args.Length < (i + 2))
            //        {
            //            Console.WriteLine("Error: no se especificó la URL del WSDL del WSAA");
            //            return -1;
            //        }
            //        else
            //        {
            //            strUrlWsaaWsdl = args[i + 1];
            //            i = i + 1;
            //        }
            //    }

            //    else if (String.Compare(argumento, "-s", true) == 0)
            //    {
            //        if (args.Length < (i + 2))
            //        {
            //            Console.WriteLine("Error: no se especificó el ID del servicio de negocio");
            //            return -1;
            //        }
            //        else
            //        {
            //            strIdServicioNegocio = args[i + 1];
            //            i = i + 1;
            //        }
            //    }

            //    else if (String.Compare(argumento, "-c", true) == 0)
            //    {
            //        if (args.Length < (i + 2))
            //        {
            //            Console.WriteLine("Error: no se especificó ruta del certificado firmante");
            //            return -1;
            //        }
            //        else
            //        {
            //            strRutaCertSigner = args[i + 1];
            //            i = i + 1;
            //        }
            //    }

            //    else if (String.Compare(argumento, "-v", true) == 0)
            //    {
            //        if (args.Length < (i + 2))
            //        {
            //            Console.WriteLine("Error: no se especificó modo: on|off");
            //            return -1;
            //        }
            //        else
            //        {
            //            blnVerboseMode = (String.Compare(args[i + 1], "on", true) == 0 ? true : false);
            //            i = i + 1;
            //        }
            //    }

            //    else if (String.Compare(argumento, "-?", true) == 0)
            //    {
            //        ExplicarUso();
            //        return 0;
            //    }
            //    else
            //    {

            //        Microsoft.VisualBasic.ApplicationServices.ApplicationBase MyApplication = new Microsoft.VisualBasic.ApplicationServices.ApplicationBase();

            //        Console.WriteLine("Error: argumento desconocido: {0}", argumento);
            //        Console.WriteLine("Para obtener ayuda: {0} -?", MyApplication.Info.AssemblyName);
            //        return -2;
            //    }
            //}
            #endregion
            // Argumentos OK, entonces procesar normalmente... 

            LoginTicket objTicketRespuesta;
            string strTicketRespuesta;

            try
            {

                if (blnVerboseMode)
                {
                    Console.WriteLine("***Servicio a acceder: {0}", strIdServicioNegocio);
                    Console.WriteLine("***URL del WSAA: {0}", strUrlWsaaWsdl);
                    Console.WriteLine("***Ruta del certificado: {0}", strRutaCertSigner);
                    Console.WriteLine("***Modo verbose: {0}", blnVerboseMode);

                }

                objTicketRespuesta = new LoginTicket();

                if (blnVerboseMode)
                {
                    Console.WriteLine("***Accediendo a {0}", strUrlWsaaWsdl);
                }

                strTicketRespuesta = objTicketRespuesta.ObtenerLoginTicketResponse(strIdServicioNegocio, strRutaCertSigner, blnVerboseMode, StoreName.TrustedPeople, StoreLocation.CurrentUser);

                if (blnVerboseMode)
                {
                    Console.WriteLine("***CONTENIDO DEL TICKET RESPUESTA:");
                    Console.WriteLine(" Token: {0}", objTicketRespuesta.Token);
                    Console.WriteLine(" Sign: {0}", objTicketRespuesta.Sign);
                    Console.WriteLine(" GenerationTime: {0}", Convert.ToString(objTicketRespuesta.GenerationTime));
                    Console.WriteLine(" ExpirationTime: {0}", Convert.ToString(objTicketRespuesta.ExpirationTime));
                    Console.WriteLine(" Service: {0}", objTicketRespuesta.Service);
                    Console.WriteLine(" UniqueID: {0}", Convert.ToString(objTicketRespuesta.UniqueId));
                }
            }

            catch (Exception excepcionAlObtenerTicket)
            {

                Console.WriteLine("***EXCEPCION AL OBTENER TICKET:");
                Console.WriteLine(excepcionAlObtenerTicket.Message);
                Console.ReadKey();
                return -10;

            }

            Console.ReadKey();
            return 0;        
        }


        /// <summary> 
        /// Explica el uso del comando 
        /// </summary> 
        /// <remarks></remarks> 
        public static void ExplicarUso()
        {

            Microsoft.VisualBasic.ApplicationServices.ApplicationBase MyApplication = new Microsoft.VisualBasic.ApplicationServices.ApplicationBase();

            Console.WriteLine("");
            Console.WriteLine("Uso: {0} (opciones) ...", MyApplication.Info.AssemblyName);
            Console.WriteLine("");
            Console.WriteLine("opciones:");
            Console.WriteLine(" -s servicio ID del servicio de negocio");
            Console.WriteLine(" Valor por defecto: " + DEFAULT_SERVICIO);
            Console.WriteLine(" -c certificado Ruta del certificado (con clave privada)");
            Console.WriteLine(" Valor por defecto: " + DEFAULT_CERTSIGNER);
            Console.WriteLine(" -w url URL del WSDL del WSAA");
            Console.WriteLine(" Valor por defecto: " + DEFAULT_URLWSAAWSDL);
            Console.WriteLine(" -v on|off Reportes detallados de la ejecución");
            Console.WriteLine(" -? Esta ayuda");
            Console.ReadKey();
        }

        public static void MostrarVersion()
        {
            Microsoft.VisualBasic.ApplicationServices.ApplicationBase MyApplication = new Microsoft.VisualBasic.ApplicationServices.ApplicationBase();

            Console.WriteLine("Aplicacion : {0}", MyApplication.Info.AssemblyName);
            Console.WriteLine("Version : {0}", Convert.ToString(MyApplication.Info.Version));
            Console.WriteLine("Descripcion: {0}", MyApplication.Info.Description);
        }
    }
}
