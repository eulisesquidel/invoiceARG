using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacturaElectronica.Common.Services;
using FacturaElectronica.Common.Contracts;
using FacturaElectronica.Data;

namespace FacturaElectronica.Business.Services
{
    public class MaestrosSevice : IMaestrosService
    {
        #region IMaestrosService Members

        public List<WebServiceAfipDto> ObtenerWebServicesAfip()
        {
            using (var ctx = new FacturaElectronicaEntities())
            {
                return ToWebServiceDtoList(ctx.WebServiceAfips.ToList());
            }
        }

        public static WebServiceAfipDto ToWebServiceAfipDto(WebServiceAfip wsAfip)
        {
            WebServiceAfipDto dto = new WebServiceAfipDto();
            dto.Id = wsAfip.Id;
            dto.Nombre = wsAfip.Nombre;
            dto.Descripcion = wsAfip.Descripcion;

            return dto;
        }

        private static List<WebServiceAfipDto> ToWebServiceDtoList(List<WebServiceAfip> corridaList)
        {
            List<WebServiceAfipDto> dtoList = new List<WebServiceAfipDto>();

            foreach (WebServiceAfip corrida in corridaList)
            {
                dtoList.Add(ToWebServiceAfipDto(corrida));
            }

            return dtoList;
        }


        #endregion
    }
}
