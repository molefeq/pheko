$(document).ready(function () {
    var patient_view_model = new PatientViewModel();

    patient_view_model.initialise($('#divGetPatientViewModelUrl').attr('data-url'));
    ko.applyBindings(patient_view_model, $('#divPatientDetails')[0]);
});
