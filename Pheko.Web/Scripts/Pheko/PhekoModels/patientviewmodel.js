
function Patient() {
}

function PatientMedicalAidDependancy() {
    var self = this;

    self.Title = ko.observable();
    self.FirstFullName = ko.observable();
    self.LastName = ko.observable();
    self.PrincipalInd = ko.observable();
    self.PatientId = ko.observable();
    self.MedicalAidCode = ko.observable();
    self.BirthDate = ko.observable();
    self.Relationship = ko.observable();
    self.isNew = ko.observable(true);

    self.fullName = ko.computed(function () { return self.Title() + " " + self.FirstFullName() + " " + self.LastName(); }, self);
    self.isPrincipalMember = ko.computed(function () { if (self.PrincipalInd()) { return 'YES' } else { return 'NO' }; }, self);
}

function PatientViewModel() {
    var self = this;
    self.patient = new Patient();
    self.patientmedicaldependancies = ko.observableArray();
    self.currentpatientmedicaldependancy = ko.observable();

    self.save = function (target, event, url, form_id, main_element) {

        if ($('form#' + form_id).valid() && self.saveCheck(main_element)) {

            $.ajax({
                type: "POST",
                url: url,
                async: false,
                cache: false,
                data: JSON.stringify(ko.mapping.toJS({ model: self.patient })),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.errors) {
                        $('#' + main_element).displayerrors({ errors: response.errors });
                    }
                    else if (response.ok) {
                        ko.mapping.fromJS(response.data, {}, self.patient);

                        if (self.patient.MedicalAidInd() == false) {
                            self.patientmedicaldependancies.removeAll();
                        }
                    }
                },
                error: function (error) {
                    alert(error.status + "<--and--> " + error.statusText);
                }
            });
        }
    };

    self.print = function (target, event, url, saveurl, form_id, main_element) {

        if ($('form#' + form_id).valid() && self.saveCheck(main_element)) {

            $.ajax({
                type: "POST",
                url: saveurl,
                async: false,
                cache: false,
                data: JSON.stringify(ko.mapping.toJS({ model: self.patient })),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.errors) {
                        $('#' + main_element).displayerrors({ errors: response.errors });
                    }
                    else if (response.ok) {
                        ko.mapping.fromJS(response.data, {}, self.patient);

                        if (self.patient.MedicalAidInd() == false) {
                            self.patientmedicaldependancies.removeAll();
                        }
                        window.location = url + "?patientId=" + self.patient.PatientId();
                    }
                },
                error: function (error) {
                    alert(error.status + "<--and--> " + error.statusText);
                }
            });
        }
    };

    self.createconsultation = function (target, event, url, saveurl, form_id, main_element) {

        if ($('form#' + form_id).valid() && self.saveCheck(main_element)) {

            $.ajax({
                type: "POST",
                url: saveurl,
                async: false,
                cache: false,
                data: JSON.stringify(ko.mapping.toJS({ model: self.patient })),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.errors) {
                        $('#' + main_element).displayerrors({ errors: response.errors });
                    }
                    else if (response.ok) {
                        ko.mapping.fromJS(response.data, {}, self.patient);

                        if (self.patient.MedicalAidInd() == false) {
                            self.patientmedicaldependancies.removeAll();
                        }

                        window.location = url;
                    }
                },
                error: function (error) {
                    alert(error.status + "<--and--> " + error.statusText);
                }
            });
        }
    };

    self.initialise = function (url) {
        $.ajax({
            type: "GET",
            url: url,
            async: false,
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                ko.mapping.fromJS(response.data, {}, self.patient);

                if (response.patientmedicalaiddepandancies && response.patientmedicalaiddepandancies.length > 0) {
                    $.each(response.patientmedicalaiddepandancies, function (index, item) {
                        var dependancy = new PatientMedicalAidDependancy();
                        ko.mapping.fromJS(item, {}, dependancy);
                        dependancy.isNew(false);
                        self.patientmedicaldependancies.push(dependancy);
                    })
                }
            },
            error: function (error) {
                alert(error.status + "<--and--> " + error.statusText);
            }
        });
    };

    self.displayMedicalDetails = function (data, event) {
        if (!event.target.checked) {
            self.patient.MedicalAidName('');
            self.patient.MedicalAidScheme('');
            self.patient.MedicalAidNumber('');
            self.patient.PrincipalMemberInd(false);
        }

        return true;
    };

    self.saveCheck = function (main_element) {
        var errors = new Array();

        address_save_check(errors, self.patient.PhysicalAddress, 'PhysicalAddress', 'Physical Address');
        address_save_check(errors, self.patient.PostalAddress, 'PostalAddress', 'Postal Address');

        if (errors.length > 0) {
            $('#' + main_element).displayerrors({ errors: errors });

            return false;
        }

        return true;
    };

    self.addmedicalaiddependancy = function (data, event, patient_medical_aid_dependancy_holder, url) {
        var newPatientMedicalDependacy = new PatientMedicalAidDependancy();

        newPatientMedicalDependacy.FirstFullName('Qinisela Elvis');
        newPatientMedicalDependacy.PatientId(self.patient.PatientId());

        self.currentpatientmedicaldependancy(newPatientMedicalDependacy);

        get_patient_medical_aid_dependancy_view(url, patient_medical_aid_dependancy_holder)

        ko.applyBindings(self, $('#' + patient_medical_aid_dependancy_holder)[0]);



        $('#' + patient_medical_aid_dependancy_holder).modal({
            keyboard: false,
            show: true,
            backdrop: 'static'
        });
    }

    self.editmedicalaiddependancy = function (data, event, patient_medical_aid_dependancy_holder, url) {
        self.currentpatientmedicaldependancy(data);

        get_patient_medical_aid_dependancy_view(url, patient_medical_aid_dependancy_holder)

        ko.applyBindings(self, $('#' + patient_medical_aid_dependancy_holder)[0]);

        $('#' + patient_medical_aid_dependancy_holder).modal({
            keyboard: false,
            show: true,
            backdrop: 'static'
        });
    }

    self.savemedicalaiddependancy = function (data, event, url, form_id, patient_medical_aid_dependancy_holder) {
        var form = $('#frmSavePatientMedicalAidDependancy');

        if (form.valid()) {

            $.ajax({
                type: "POST",
                url: url,
                async: false,
                cache: false,
                data: JSON.stringify(ko.mapping.toJS({ model: self.currentpatientmedicaldependancy })),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.errors) {
                        $('#' + main_element).displayerrors({ errors: response.errors });
                    }
                    else if (response.ok) {
                        ko.mapping.fromJS(response.data, {}, self.currentpatientmedicaldependancy);
                        if (data.isNew() == true) {
                            self.patientmedicaldependancies.push(self.currentpatientmedicaldependancy());
                        }
                        self.currentpatientmedicaldependancy(null);
                        $('#' + patient_medical_aid_dependancy_holder).modal('hide');
                        $('#' + patient_medical_aid_dependancy_holder).empty();

                    }
                },
                error: function (error) {
                    alert(error.status + "<--and--> " + error.statusText);
                }
            });

        }

        return true;
    }

    self.deletemedicalaiddependancy = function (data, event, patient_medical_aid_dependancy_holder, url) {
        alert('Are you sure you want to remove the medical aid dependancy.');
        self.currentpatientmedicaldependancy(data)

        $.ajax({
            type: "POST",
            url: url,
            cache: false,
            async: false,
            data: { patientMedicalAidDependancyId: data.PatientMedicalAidDependanciesId() },
            success: function (response) {
                self.patientmedicaldependancies.remove(data);
            },
            error: function (error) {
                alert(error.status + "<--and--> " + error.statusText);
            }
        });
    }

    function address_save_check(errors, address, address_type, address_name) {

        if (address.Line1() || address.Line2() || address.Suburb() || address.City() ||
            address.PostalCode() || address.ProvinceId() || address.CountryId()) {

            if (!address.Line1()) {
                errors.push(new FieldError(address_type + '.Line1', 'If one of ' + address_name + ' fields is filled then address line 1 is required.'));
            }

            if (!address.Suburb()) {
                errors.push(new FieldError(address_type + '.Suburb', 'If one of ' + address_name + ' fields is filled then suburb is required.'));
            }

            if (!address.City()) {
                errors.push(new FieldError(address_type + '.City', 'If one of ' + address_name + ' fields is filled then city is required.'));
            }

            if (!address.ProvinceId()) {
                errors.push(new FieldError(address_type + '.ProvinceId', 'If one of ' + address_name + ' fields is filled then province is required.'));
            }
        }

    }

    function get_patient_medical_aid_dependancy_view(url, view_holder) {
        $.ajax({
            type: "POST",
            url: url,
            cache: false,
            async: false,
            data: {},
            success: function (response) {
                $('#' + view_holder).empty();
                $('#' + view_holder).html(response);

                $('#frmSavePatientMedicalAidDependancy').removeData('validator');
                $('#frmSavePatientMedicalAidDependancy').removeData('unobtrusiveValidation');
                $.validator.unobtrusive.parse('#frmSavePatientMedicalAidDependancy');
            },
            error: function (error) {
                alert(error.status + "<--and--> " + error.statusText);
            }
        });
    }
};