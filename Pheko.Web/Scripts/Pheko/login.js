function BeginLogin() {

}

function UpdateLogin(response) {

    if (response.errors) {

        for (var i = 0; i < response.errors.length ; i++) {
            show_message(response.errors[i].FieldName, response.errors[i].Message);
        }

    }
}


function show_message(fieldname, errormessage) {
    //add the validation message to the form

    if (fieldname != null && fieldname != '') {
        var validation_holder = $('#divLoginContainer').find("[data-valmsg-for=" + fieldname + "]");
        
        validation_holder.removeClass('field-validation-valid');
        validation_holder.addClass('field-validation-error');

        validation_holder.append('<span for="' + fieldname + '" generated="true">' + errormessage + '</span>');

        //.append('<span for="' + fieldname + '" generated="true">' + errormessage + '</span>')
    }
    //else {
    //    var validationSummaryMessageTmpl = kendo.template($("#validationSummary").html());
    //    var error_messages = '';
    //    for (var error in errors) {
    //        error_messages += '<div style="text-align:left;"><span class="k-icon k-warning"> </span>' + errors[error] + '<div class="k-callout k-callout-n"></div></div>';
    //    }
    //    container.find("[data-valmsg-summary=true]").replaceWith($(validationSummaryMessageTmpl({ message: error_messages })));
    //}
}