using RAX.Models.Web.Api.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trax.Infraestructure.Web_.CoreApi;
using TRAX.Models.Web.Api.OperationResult;
using TRAX.Models.Web.Api.TraxApi.Request.RequestCajaAhorro;
using TRAX.Models.Web.Api.TraxApi.Response;

namespace UI.Trax.Web.Controllers
{
    public class HomeController : Controller
    {
        private Logger _Logger;
        // GET: FichaTec
        public HomeController()
        {
            this._Logger = new Logger(System.Web.HttpContext.Current.Server.MapPath("~//" + Properties.Settings.Default.PathLog));
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult ObtenerUsuarioById(ObtenerAhorroByUsuarioRequestDTO _Request)
        {
            ObtenerAhorroByUsuarioReponseDTO _Response = new ObtenerAhorroByUsuarioReponseDTO();
            TraxCore _Core = new TraxCore(this._Logger);
            var _CurrentUserName = System.Web.HttpContext.Current.User.Identity.Name;
            try
            {
                OperationResult _OperationResult = new OperationResult();
                _Response = _Core.ObtenerUsuario(_Request, Properties.Settings.Default.TraxApiEndPoint);
                //throw new Exception(string.Join(", ", _Response.Result.Errors.Select(x => x.Message)));
                _Response.IsOk = true;
                _Response.Message = string.Empty;
            }
            catch (Exception ex)
            {
                this._Logger.LogError(ex);
                _Response.IsOk = false;
                _Response.Message = ex.Message;
            }
            return PartialView("_PanelResult", _Response);
        }
    }
}