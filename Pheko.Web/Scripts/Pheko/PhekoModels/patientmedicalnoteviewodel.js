function PatientMedicalNote() {
    var self = this;

    self.PatientMedicalNoteId = ko.observable();
    self.PatientConsultationId = ko.observable();
    self.MedicalNote_Id = ko.observable();
    self.MedicalNote_Name = ko.observable();
    self.MedicalNoteValue = ko.observable();
}

function PatientChronicDesease() {
    var self = this;

    self.PatientChronicDeseaseId = ko.observable();
    self.PatientId = ko.observable();
    self.ChronicDesease_Id = ko.observable();
    self.ChronicDesease_Name = ko.observable();
    self.ChronicDeseaseValue = ko.observable();
    self.YearOfDiagnoses = ko.observable();
    self.SelectedInd = ko.observable(false);
}

function PatientPastMedicalHistory() {
    var self = this;

    self.PatientPastMedicalHistoryId = ko.observable();
    self.PatientId = ko.observable();
    self.PastMedicalHistory_Id = ko.observable();
    self.PastMedicalHistory_Name = ko.observable();
    self.PastMedicalHistoryValue = ko.observable();
}

function PatientDeseaseScreening() {
    var self = this;

    self.PatientDeseaseScreeningId = ko.observable();
    self.PatientId = ko.observable();
    self.DeseaseScreening_Id = ko.observable();
    self.DeseaseScreening_Name = ko.observable();
    self.DeseaseScreeningValue = ko.observable();
    self.YearOfScreening = ko.observable();
    self.SelectedInd = ko.observable(false);
}

function PatientClinicalExamination() {
    var self = this;

    self.PatientClinicalExaminationId = ko.observable();
    self.PatientConsultationId = ko.observable();
    self.ClinicalExamination_Id = ko.observable();
    self.ClinicalExamination_Name = ko.observable();
    self.ClinicalExaminationValue = ko.observable();
}

function PatientMedicalMonitoring() {
    var self = this;

    self.PatientMedicalMonitoringId = ko.observable();
    self.PatientConsultationId = ko.observable();
    self.MedicalMonitoring_Id = ko.observable();
    self.MedicalMonitoring_Name = ko.observable();
    self.MedicalMonitoringValue = ko.observable();
}

function PatientConsultationSickNote() {
    var self = this;

    self.PatientConsultationSickNoteId = ko.observable();
    self.PatientConsultationId = ko.observable();
    self.PatientId = ko.observable();
    self.SicknessReason = ko.observable();
    self.Diagnoses = ko.observable();
    self.StartDate = ko.observable();
    self.EndDate = ko.observable();
}

function PatientMedicalNoteViewModel() {
    var self = this;

    self.patientmedicalnotes = ko.observableArray();
    self.patientchronicdeseases = ko.observableArray();
    self.patientpastmedicalhistories = ko.observableArray();
    self.patientdeseasescreenings = ko.observableArray();
    self.patientclinicalexaminations = ko.observableArray();
    self.patientmedicalmonitorings = ko.observableArray();
    self.patientconsultationsicknote = ko.observable();

    self.initialise = function (url) {
        $.ajax({
            type: "GET",
            url: url,
            async: false,
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {

                if (response.patientmedicalnotes && response.patientmedicalnotes.length > 0) {
                    $.each(response.patientmedicalnotes, function (index, item) {
                        var patientmedicalnote = new PatientMedicalNote();

                        ko.mapping.fromJS(item, {}, patientmedicalnote);
                        self.patientmedicalnotes.push(patientmedicalnote);
                    })
                }

                if (response.patientchronicdeseases && response.patientchronicdeseases.length > 0) {
                    $.each(response.patientchronicdeseases, function (index, item) {
                        var patientchronicdesease = new PatientChronicDesease();

                        ko.mapping.fromJS(item, {}, patientchronicdesease);
                        self.patientchronicdeseases.push(patientchronicdesease);
                    })
                }

                if (response.patientpastmedicalhistories && response.patientpastmedicalhistories.length > 0) {
                    $.each(response.patientpastmedicalhistories, function (index, item) {
                        var patientpastmedicalhistory = new PatientPastMedicalHistory();

                        ko.mapping.fromJS(item, {}, patientpastmedicalhistory);
                        self.patientpastmedicalhistories.push(patientpastmedicalhistory);
                    })
                }

                if (response.patientdeseasescreenings && response.patientdeseasescreenings.length > 0) {
                    $.each(response.patientdeseasescreenings, function (index, item) {
                        var patientdeseasescreening = new PatientDeseaseScreening();

                        ko.mapping.fromJS(item, {}, patientdeseasescreening);
                        self.patientdeseasescreenings.push(patientdeseasescreening);
                    })
                }

                if (response.patientclinicalexaminations && response.patientclinicalexaminations.length > 0) {
                    $.each(response.patientclinicalexaminations, function (index, item) {
                        var patientclinicalexamination = new PatientClinicalExamination();

                        ko.mapping.fromJS(item, {}, patientclinicalexamination);
                        self.patientclinicalexaminations.push(patientclinicalexamination);
                    })
                }

                if (response.patientmedicalmonitorings && response.patientmedicalmonitorings.length > 0) {
                    $.each(response.patientmedicalmonitorings, function (index, item) {
                        var patientmedicalmonitoring = new PatientMedicalMonitoring();

                        ko.mapping.fromJS(item, {}, patientmedicalmonitoring);
                        self.patientmedicalmonitorings.push(patientmedicalmonitoring);
                    })
                }

                if (response.patientconsultationsicknote) {
                    var patientconsultationsicknote = new PatientConsultationSickNote();

                    ko.mapping.fromJS(response.patientconsultationsicknote, {}, patientconsultationsicknote);
                    self.patientconsultationsicknote(patientconsultationsicknote);
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
                data: JSON.stringify(ko.mapping.toJS({
                    patientMedicalNoteViewModels: self.patientmedicalnotes,
                    patientChronicDeseaseViewModels: self.patientchronicdeseases,
                    patientPastMedicalHistoryViewModels: self.patientpastmedicalhistories,
                    patientDeseaseScreeningViewModels: self.patientdeseasescreenings,
                    patientClinicalExaminationViewModels: self.patientclinicalexaminations,
                    patientMedicalMonitoringViewModels: self.patientmedicalmonitorings,
                    patientConsultationSickNoteViewModel: self.patientconsultationsicknote
                })),
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
                data: JSON.stringify(ko.mapping.toJS({
                    patientMedicalNoteViewModels: self.patientmedicalnotes,
                    patientChronicDeseaseViewModels: self.patientchronicdeseases,
                    patientPastMedicalHistoryViewModels: self.patientpastmedicalhistories,
                    patientDeseaseScreeningViewModels: self.patientdeseasescreenings,
                    patientClinicalExaminationViewModels: self.patientclinicalexaminations,
                    patientMedicalMonitoringViewModels: self.patientmedicalmonitorings,
                    patientConsultationSickNoteViewModel: self.patientconsultationsicknote
                })),
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

    self.printsicknote = function (target, event, url, saveurl) {

        $.ajax({
            type: "POST",
            url: saveurl,
            async: false,
            cache: false,
            data: JSON.stringify(ko.mapping.toJS({
                patientConsultationSickNoteViewModel: self.patientconsultationsicknote
            })),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response.errors) {
                    $('#' + main_element).displayerrors({ errors: response.errors });
                }
                else if (response.ok) {
                    window.location = url + '?patientConsultationId=' + response.patientConsultationId;
                }
            },
            error: function (error) {
                alert(error.status + "<--and--> " + error.statusText);
            }
        });
    };
}