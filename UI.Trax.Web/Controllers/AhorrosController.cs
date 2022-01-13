using RAX.Models.Web.Api.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trax.Infraestructure.Web_.CoreApi;
using TRAX.Models.Web.Api.OperationResult;
using TRAX.Models.Web.Api.TraxApi.Response;

namespace UI.Trax.Web.Controllers
{
    public class AhorrosController : Controller
    {
        private Logger _Logger;
        // GET: FichaTec
        public AhorrosController()
        {
            this._Logger = new Logger(System.Web.HttpContext.Current.Server.MapPath("~//" + Properties.Settings.Default.PathLog));
        }

        // GET: Ahorros
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public JsonResult ObtenerUsuariosConAhorros()
        {
            var result = new object();
            try
            {
                ObtenerListadoUsuariosResponseDTO _OperationResult = new ObtenerListadoUsuariosResponseDTO();
                TraxCore core = new TraxCore(this._Logger);
                _OperationResult = core.ListaUsuariosConAhorros(Properties.Settings.Default.TraxApiEndPoint);
                //if (_OperationResult.Result.Code == OperationResult.StatusCodesEnum.CONFLICT.ToString("D"))
                //    return Json(new { Error = string.Empty, IsOK = false, Code = OperationResult.StatusCodesEnum.CONFLICT });
                //if (!_OperationResult.Result.IsOK() && _OperationResult.Result.Code != OperationResult.StatusCodesEnum.ACCEPTED.ToString("D"))
                //    throw new Exception(string.Join(", ", _OperationResult.Result.Errors.Select(x => x.Message)));
                result = new { Error = string.Empty, IsOK = true, Code = OperationResult.StatusCodesEnum.OK, _OperationResult.List };

            }
            catch (Exception ex)
            {
                //this._Logger.LogText("Erorr: Usuario : " + _CurrentUserName);
                this._Logger.LogError(ex);
                result = new { Error = ex.Message, IsOK = false, Code = OperationResult.StatusCodesEnum.INTERNAL_SERVER_ERROR };

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }



    }
}