using System.Web;
using System.Web.Optimization;

namespace UI.Trax.Web
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // Assets Styles and Scripts
            bundles.Add(new StyleBundle("~/Content/assets/css").Include(
                      "~/Content/assets/css/preload.min.css",
                      "~/Content/assets/css/plugins.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/assets/js").Include(
                      "~/Scripts/assets/js/plugins.min.js",
                      "~/Scripts/assets/js/app.min.js",
                      "~/Scripts/assets/js/index.js"));

            // Fonts            
            bundles.Add(new StyleBundle("~/font-awesome/css").Include(
                      "~/Content/assets/plugins/revolution/revolution/fonts/font-awesome/css/font-awesome.min.css", new CssRewriteUrlTransform()));

        }
    }
}
