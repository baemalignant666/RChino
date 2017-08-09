using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RChino.UI.Web.Models.Controls
{
    public class CtrlBaseModel
    {
        public enum CType { CtrlTable = 0, CtrlInput = 1 }//TIPO DE CONTROL ENUM

        [JsonProperty]
        public string Id { get; set; }//ATRIBUTOS COMUNES PARA TODOS LOS CONTROLES

        [JsonProperty]
        public string JsFunctionName { get; set; }

        [JsonProperty]
        public string ContainerId { get; set; }

        [JsonProperty]
        public string EncodedModel { get; set; }

        [JsonProperty]
        public CType CtrlType { get; set; }

        [JsonProperty]
        public bool UpdatedModel { get; set; }

        public CtrlBaseModel()
        {
            UpdatedModel = false;
        }


        protected CtrlBaseModel(string jsFunction, string id, CType ctrlType)
        {
            Id = id;
            JsFunctionName = jsFunction;
            ContainerId = "Ctrl_Container_" + Id;
            CtrlType = ctrlType;
            UpdatedModel = false;
        }

        public virtual string GetJsonModel()
        {
            return "";
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}