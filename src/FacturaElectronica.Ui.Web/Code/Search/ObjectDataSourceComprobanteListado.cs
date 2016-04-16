using System;
using System.Linq;
using System.Web;
/*using Web.Framework.Search;*/
using System.Collections;
using FacturaElectronica.Common.Contracts;

namespace FacturaElectronica.Ui.Web.Code.Search
{
    public class ObjectDataSourceComprobanteListado/* : IGridViewSearchObjectDataSource*/
    {
        public bool DebeBuscar { get; set; }

        public ComprobanteCriteria SearchCriteria { get; set; }

        public IList GetObjects()
        {
            return GetObjects(int.MaxValue, 0, string.Empty);
        }

        public IList GetObjects(int maximumRows, int startRowIndex)
        {
            return GetObjects(maximumRows, startRowIndex, string.Empty);
        }

        public IList GetObjects(string sortExpression)
        {
            return GetObjects(int.MaxValue, 0, sortExpression);
        }

        public int TotalNumberOfGetObjects()
        {
            if (DebeBuscar)
            {
                return 0;// ServiceFactory.GetComprobanteService().ObtenerComprobantesPorCliente(SearchCriteria).Count();
            }
            else
                return 0;
        }

        public IList GetObjects(int maximumRows, int startRowIndex, string sortExpression)
        {
            return null; //ServiceFactory.GetComprobanteService().ObtenerComprobantesPorCliente(SearchCriteria);    
        }
    }
}