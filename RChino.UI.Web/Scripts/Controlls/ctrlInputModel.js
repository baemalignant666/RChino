function BuildCtrlInput(encodedModel) { //

    var classInput = 'form-group';
    var requiredText = '';

    var model = jQuery.parseJSON($.base64.decode(encodedModel));//decodificacion del mismo y retorna

    var id = model.Id;
    var label = model.Label;

    if(model.Required) {//si el atriburo requerido esta en true
        requiredText = "required";
        label = '* ' + model.Label; //le agrega un * para indicar que es requerido
    }
     
    //pinta el html del lado del cliente 
    var htmlText = '<div class="'+ classInput + '" id="dvInput_'+ id + '"> ' +
        '<label class="col-lg-2 control-label" for="inputDefault">' + label + '</label> ' +
        '<div class="col-lg-10">' +
            '<input type="text" class="form-control" id="' + id + '" value="' + model.Value + '" ' + requiredText + '> ' +
        '</div>' +
    '</div>';

    $('#' + model.ContainerId).html(htmlText);

    //Setea los atributos custom postPintado
    SetAttributteValue(id, "Label", model.Label);
    SetAttributteValue(id, "ContainerId", model.ContainerId);
    SetAttributteValue(id, "JsFunctionName", model.JsFunctionName);
    SetAttributteValue(id, "CtrlType", model.CtrlType);    
    SetControlValue(id, model.Value);
}


function CtrlInputModel(id) {// crear un objeto a nivel de js
    this.Id = id;
    this.Label = GetAttributteValue(id, "Label");
    this.Value = GetControlValue(id);
    this.ContainerId = GetAttributteValue(id, "ContainerId");
    this.JsFunctionName = GetAttributteValue(id, "JsFunctionName");
    this.CtrlType = GetAttributteValue(id, "CtrlType");
    this.Required = GetNativeAttributteValue(id, "required");
}
