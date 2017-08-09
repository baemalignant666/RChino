

function AjaxAction(actionName, uiContainer, validate) {
    
    /// Implementacion de validaciones
    var hayErrores = false;
    var elements = '';

    if(validate){
        $.each(uiContainer.Models, function(index, model) {
            debugger;
            //input=1
            //combo=2
            if (model.CtrlType === 1 && model.Required) {
                //Valida si esta vacio o nulo
                if (!model.Value.trim()) {
                    $('#' + 'dvInput_' + model.Id).addClass("has-error");
                    elements += ',' + model.Label;
                    hayErrores = true;                
                    ShowErrorMessage("Los campos " + elements + " no pueden estar en blanco.");
                }
            }
        });    

        if (hayErrores)
            return;
    }

    var dataToSend = "objUiContainer=" + JSON.stringify(uiContainer);

    $.ajax({
        type: "POST",
        url: actionName,
        data: dataToSend,        
        dataType: "text",
        success: function (response) {
            //Siempre Retorna un UiContainer
            ProcessResponse(response);
        },                
        failure: function (response) {
            ProcessErrorResponse(response);
        }
    });
}


function ProcessResponse(response) {

    debugger;
    
    var uiContainer = JSON.parse(response);

    $.each(uiContainer.Models, function (index, model) {
        //Si el modelo fue actualizado lo repinta
        if (model.UpdatedModel) {
            var buildFunction = model.JsFunctionName + "('" + model.EncodedModel + "')";        
            eval(buildFunction);
        }
    });

    //Muestra mensaje de informacion
    if (uiContainer.InformationMessage) {
        ShowInformationMessage(uiContainer.InformationMessage);
    }


    if (uiContainer.ErrorMessage) {
        ShowErrorMessage(uiContainer.ErrorMessage);
    }

    if (uiContainer.RedirecTo) {

        window.location.href = uiContainer.RedirecTo;
        //window.location.href = "/Cliente/RedirectVwCliente";
    }


}

function ProcessErrorResponse(response) {
    ShowErrorMessage('Error al procesar la acción, intente más tarde.');
}

function ShowInformationMessage(message) {
    $('#msgInformationAlert').addClass("alert-info");
    $('#msgInformationAlert').show(500);
    $('#lblMessage').text(message);
}

function ShowErrorMessage(message) {

    //alert alert-dismissible alert-danger
    $('#msgInformationAlert').addClass("alert-danger");
    $('#msgInformationAlert').show(500);
    $('#lblMessage').text(message);
}

function GetNativeAttributteValue(ctrlId, attId) {

    var val = $('#' + ctrlId).prop(attId);

    return val;
}

function GetAttributteValue(ctrlId, attId) {

    var val = $('#' + ctrlId).attr(attId);

    val = $.base64.decode(val);

    try {
        var json = $.parseJSON(val);
        val = json;
    } catch (e) {
        // not json
    }

    return val;
}

function SetAttributteValue(ctrlId, attId, attValue) {
    
    var val = $.base64.encode(JSON.stringify(attValue));
    $('#' + ctrlId).attr(attId, val);    

}

function SetControlValue(ctrlId, attValue) {
    $('#' + ctrlId).val(attValue);
}

function GetControlValue(ctrlId) {

    var val = $('#' + ctrlId).val();
    return val;

}

function UiContainer() {

    // Add object properties like this
    this.Models = [];    
}

UiContainer.prototype.AddModel = function (model) {
    model.EncodedModel = $.base64.encode(JSON.stringify(model));
    this.Models.push(model);
};