using RAX.Models.Web.Api.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TRAX.Models.Web.Api.Api;
using TRAX.Models.Web.Api.OperationResult;
using TRAX.Models.Web.Api.Serializer;
using TRAX.Models.Web.Api.TraxApi.Request.RequestCajaAhorro;
using TRAX.Models.Web.Api.TraxApi.Response;

namespace Trax.Infraestructure.Web_.ClienteApi
{
    public class ClientApiTrax
    {
        private string Token;
        private string UrlEndPoint;
        private Logger _Logger;


        public ClientApiTrax(Logger Logger)
        {
            this.Token = string.Empty;
            this.UrlEndPoint = string.Empty;
            this._Logger = Logger;

        }

        public bool HasToken()
        {
            return !string.IsNullOrEmpty(this.Token);
        }
        public bool HasEndPoint()
        {
            return !string.IsNullOrEmpty(this.UrlEndPoint);
        }

        public void SetEndPoint(string UrlEndPoint)
        {
            this.UrlEndPoint = UrlEndPoint;
        }

        public ObtenerAhorroByUsuarioReponseDTO ObtenerUsuarioById(ObtenerAhorroByUsuarioRequestDTO request)
        {
            var _Response = new ObtenerAhorroByUsuarioReponseDTO();

            if (!this.HasEndPoint())
            {
                _Response.Result.SetStatusCode(OperationResult.StatusCodesEnum.UNAUTHORIZED);
                _Response.Result.AddException(new Exception("Es necesario asignar una UrlEndPoint"));
                return _Response;
            }

            string _Payload = JsonSerializer.Serialize(request);
            MessageFactory _MessageFactory = new MessageFactory(this._Logger);
            _Response = _MessageFactory.SendRequest<ObtenerAhorroByUsuarioReponseDTO>(this.UrlEndPoint, this.Token, "/CajaAhorro/obtenerAhorros", _Payload, HttpMethod.Post);
            return _Response;
        }

    }
}
