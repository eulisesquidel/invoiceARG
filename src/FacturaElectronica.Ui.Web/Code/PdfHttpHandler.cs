using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace FacturaElectronica.Ui.Web.Code
{
    public class PdfHttpHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            //MemoryStream outputStream = new MemoryStream();
            //PdfReader pdfReader = new PdfReader(context.Request.PhysicalPath);
            //int numberOfPages = pdfReader.NumberOfPages;
            //PdfStamper pdfStamper = new PdfStamper(pdfReader, outputStream);
            //PdfContentByte waterMarkContent;
            //Image image = Image.GetInstance(context.Server.MapPath("watermark.jpg"));
            //image.SetAbsolutePosition(250, 300);
            //for (int i = 1; i <= numberOfPages; i++)
            //{
            //    waterMarkContent = pdfStamper.GetUnderContent(i);
            //    waterMarkContent.AddImage(image);
            //}
            //pdfStamper.Close();
            //byte[] content = outputStream.ToArray();
            //outputStream.Close();
            //byte[] content = ;
            //context.Response.Clear(); //clear buffer
            //context.Response.ContentType = "application/pdf";
            //context.Response.AddHeader("content-disposition", "attachment;filename=" + context.Request.PhysicalPath);  //tell the browser the file is to be downloaded
            //context.Response.BinaryWrite(content);
            //context.Response.End();

            //byte[] data;
            //Response.Clear(); //clear buffer
            //Response.ContentType = "image/gif"; //should be the MIME type of the document see http://www.w3schools.com/media/media_mimeref.asp for the complete list

            //Response.BinaryWrite(data);
            //Response.End();


        }
    }
}