using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace RChino.UI.Web.Models.Controls
{
    public class CtrlInputModel : CtrlBaseModel
    {
        private const string JS_FUNCTION_NAME = "BuildCtrlInput";

        [JsonProperty]//PROPIEDADES DEL CONTROL
        public string Label { get; set; }

        [JsonProperty]
        public string Value { get; set; }

        [JsonProperty]
        public string IType { get; set; }

        [JsonProperty]
        public bool Required { get; set; }


        public CtrlInputModel()
        {
            JsFunctionName = JS_FUNCTION_NAME;
        }

        public CtrlInputModel(string id, string label, string type, string value, bool required) : base(JS_FUNCTION_NAME, id, CType.CtrlInput)
        {
            JsFunctionName = JS_FUNCTION_NAME;
            Label = label;
            Id = id;
            IType = type;
            Value = value;
            Required = required;
        }

        public string GetHtml()
        {
            var html = "<div id='{0}'>" +
                        "<script>{1}('{2}')</script>" +
                     "</div>";
            //1 la funcion js
            //2 devuelve el jsonmodel
            return string.Format(html, ContainerId, JS_FUNCTION_NAME,
                GetJsonModel());
        }

        public override string GetJsonModel()
        {
            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(this);

            var jsonBase64 = Base64Encode(json);

            return jsonBase64;
        }

        public override string ToString()
        {
            var result = JsonConvert.SerializeObject(this);
            return result;
        }

        public void Clear()
        {
            Value = "";
        }
    }
}