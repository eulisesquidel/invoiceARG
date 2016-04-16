using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace FacturaElectronica.Ui.Win.Administrador.Code.Cert
{
    public class CertUtil
    {
        public static void SetCertificatePolicy()
        {
            ServicePointManager.ServerCertificateValidationCallback  += new RemoteCertificateValidationCallback(RemoteCertificateValidate);
        }

        private static bool RemoteCertificateValidate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            return true;
            //if (cert.Subject.Contains("endesacemsa"))
            //{
            //    // trust any certificate!!!   
            //    //System.Console.WriteLine("Warning, trust any certificate");
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
    }
                                                                                                                                                                              
}

 


