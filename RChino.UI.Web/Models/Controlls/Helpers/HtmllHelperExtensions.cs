using RChino.UI.Web.Models.Controls;
using System.Web;
using System.Web.Mvc;

namespace RChino.UI.Web.Models.Helpers
{
    /// <summary>
    /// Via https://stackoverflow.com/questions/5955571/theres-no-html-button
    /// </summary>
    public static class HtmlHelperExtensions
    {

        public static HtmlString CtrlInput(this HtmlHelper html, string id, string label, string type ="submit", string value ="", bool required = false)
        {
            var ctrl = new CtrlInputModel(id, label, type, value, required);//Crear una instancia del objeto

            return new HtmlString(ctrl.GetHtml());
        }

        

    }
}