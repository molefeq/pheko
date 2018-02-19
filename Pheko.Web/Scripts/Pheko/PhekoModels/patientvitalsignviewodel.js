function PatientVitalSign() {
    var self = this;

    self.PatientVitalSignId = ko.observable();
    self.PatientConsultationId = ko.observable();
    self.VitalSign_Id = ko.observable();
    self.VitalSign_Name = ko.observable();
    self.VitalSignValue = ko.observable();
}

function PatientVitalSignViewModel() {
    var self = this;

    self.patientvitalsigns = ko.observableArray();

    self.initialise = function (url) {
        $.ajax({
            type: "GET",
            url: url,
            async: false,
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {

                if (response.patientvitalsigns && response.patientvitalsigns.length > 0) {
                    $.each(response.patientvitalsigns, function (index, item) {
                        var patientvitalsign = new PatientVitalSign();

                        ko.mapping.fromJS(item, {}, patientvitalsign);
                        self.patientvitalsigns.push(patientvitalsign);
                    })
                }
            },
            error: function (error) {
                alert(error.status + "<--and--> " + error.statusText);
            }
        });
    };

    self.save = function (target, event, url, form_id, main_element) {

        if ($('form#' + form_id).valid()) {

            $.ajax({
                type: "POST",
                url: url,
                async: false,
                cache: false,
                data: JSON.stringify(ko.mapping.toJS({ models: self.patientvitalsigns })),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.errors) {
                        $('#' + main_element).displayerrors({ errors: response.errors });
                    }
                    else if (response.ok) {
                    }
                },
                error: function (error) {
                    alert(error.status + "<--and--> " + error.statusText);
                }
            });
        }
    };

    self.print = function (target, event, url, saveurl, form_id, main_element) {

        if ($('form#' + form_id).valid()) {

            $.ajax({
                type: "POST",
                url: saveurl,
                async: false,
                cache: false,
                data: JSON.stringify(ko.mapping.toJS({ models: self.patientvitalsigns })),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.errors) {
                        $('#' + main_element).displayerrors({ errors: response.errors });
                    }
                    else if (response.ok) {
                        window.location = url + "?patientId=" + response.patientId;
                    }
                },
                error: function (error) {
                    alert(error.status + "<--and--> " + error.statusText);
                }
            });
        }
    };
};