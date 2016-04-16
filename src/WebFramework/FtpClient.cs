using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Net;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Web.Framework.Misc
{
    public class FtpClient
    {
        private const int bufferLength = 2048;

        public delegate void NotifyDelegate(string text);

        public event NotifyDelegate Notify;

        protected void OnNotify(string text)
        {
            if (Notify != null)
            {
                Notify(text);
            }
        }

        public string FTPAddress { get; set; }

        public string FTPUser { get; set; }

        public string FTPPassword { get; set; }


        public void LoadFromConfig()
        {
            FTPAddress = ConfigurationManager.AppSettings["FTPAddress"];
            FTPUser = ConfigurationManager.AppSettings["FTPUser"];
            FTPPassword = ConfigurationManager.AppSettings["FTPPassword"];
        }

        public void CreateDirectory(string directoryToCreate)
        {
            FtpWebRequest fwr = (FtpWebRequest)FtpWebRequest.Create(new Uri(directoryToCreate));
            fwr.Method = WebRequestMethods.Ftp.MakeDirectory;
            fwr.Credentials = new NetworkCredential(FTPUser, FTPPassword);

            // Creo el directorio en el servidor remoto
            using (FtpWebResponse response = (FtpWebResponse)fwr.GetResponse())
            {
                OnNotify(string.Format("Creacion de Directorio Remoto: {0}", response.StatusCode.ToString()));
                response.Close();
            }
        }

        public void UploadFile(string filePath, string remoteAddressPath)
        {
            string fileName = Path.GetFileName(filePath);
            FtpWebRequest fwr = (FtpWebRequest)FtpWebRequest.Create(new Uri(remoteAddressPath));
            fwr.Method = WebRequestMethods.Ftp.UploadFile;
            fwr.Credentials = new NetworkCredential(FTPUser, FTPPassword);

            FileInfo fileInfo = new FileInfo(filePath);

            using (FileStream fileStream = fileInfo.OpenRead())
            {
                // Escribo el archivo al request FTP
                using (Stream requestStream = fwr.GetRequestStream())
                {
                    // Leo el archivo
                    byte[] buffer = new byte[bufferLength];
                    int count = 0;
                    int readBytes = 0;
                    do
                    {
                        readBytes = fileStream.Read(buffer, 0, bufferLength);
                        requestStream.Write(buffer, 0, readBytes);
                        count += readBytes;
                    }
                    while (readBytes != 0);
                    requestStream.Flush();
                    requestStream.Close();
                }

                // obtengo la respuesta
                using (FtpWebResponse response = (FtpWebResponse)fwr.GetResponse())
                {
                    OnNotify(string.Format("Subida de archivo {0}  en el servidor remoto: {1}", fileName, response.StatusCode.ToString()));
                    response.Close();
                }
            }
        }

        private void AsignarCertificado(FtpWebRequest fwr)
        {
            X509Certificate cer = null;
            X509Store store = new X509Store(StoreName.Root, StoreLocation.LocalMachine); //StoreName.TrustedPeople, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);

            foreach (X509Certificate cert in store.Certificates)
            {
                if (cert.Subject.Contains("https://endesafews/"))
                {
                    cer = cert;
                    break;
                }
            }

            //X509Certificate2 objCert = null;

            //if (cer != null)
            //    objCert = new X509Certificate2(cer);
            //else
            //    throw new Exception("Certificado inexistente!");

            fwr.ClientCertificates.Add(cer);

        }
    }

}
