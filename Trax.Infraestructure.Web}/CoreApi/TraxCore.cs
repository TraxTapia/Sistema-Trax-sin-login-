using RAX.Models.Web.Api.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trax.Infraestructure.Web_.ClienteApi;
using TRAX.Models.Web.Api.OperationResult;
using TRAX.Models.Web.Api.TraxApi.Request.RequestCajaAhorro;
using TRAX.Models.Web.Api.TraxApi.Response;

namespace Trax.Infraestructure.Web_.CoreApi
{
    public class TraxCore
    {
        private Logger _Logger;

        public TraxCore(Logger Logger)
        {
            this._Logger = Logger;
        }
        public ObtenerAhorroByUsuarioReponseDTO ObtenerUsuario(ObtenerAhorroByUsuarioRequestDTO request, string EndPoint)
        {
            ObtenerAhorroByUsuarioReponseDTO _Response = new ObtenerAhorroByUsuarioReponseDTO();
            try
            {
                ClientApiTrax _client = new ClientApiTrax(this._Logger);
                _client.SetEndPoint(EndPoint);
                _Response = _client.ObtenerUsuarioById(request);
            }
            catch (Exception ex)
            {
                this._Logger.LogError(ex);
                _Response.Result.SetStatusCode(OperationResult.StatusCodesEnum.INTERNAL_SERVER_ERROR);
                _Response.Result.AddException(ex);
            }
            return _Response;

        }



    }
}
