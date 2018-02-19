(function ($) {

    $.fn.displayerrors = function (options) {
        var settings = $.extend({
            width: '100%',
        }, options);

        if (settings.errors) {

            for (var i = 0; i < settings.errors.length ; i++) {
                show_message(this, settings.errors[i].FieldName, settings.errors[i].Message);
            }
        }

        return this;
    }

    function show_message(main_container, fieldname, errormessage) {
        if (fieldname != null && fieldname != '') {
            var validation_holder = $(main_container).find("[data-valmsg-for=" + fieldname + "]");

            validation_holder.removeClass('field-validation-valid');
            validation_holder.addClass('field-validation-error');
            validation_holder.empty();
            validation_holder.append('<span for="' + fieldname + '" generated="true">' + errormessage + '</span>');
        }
        else {
            var validation_holder = $(main_container).find("div[data-valmsg-summary=true] > ul");
            $(main_container).find("div[data-valmsg-summary=true]").removeClass('validation-summary-valid');
            $(main_container).find("div[data-valmsg-summary=true]").addClass('validation-summary-errors');

            validation_holder.append('<li>' + errormessage + '</li>');
        }
    }
    
}(jQuery));