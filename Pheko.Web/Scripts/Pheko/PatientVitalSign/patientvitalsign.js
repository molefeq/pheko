$(document).ready(function () {
    var patient_vital_sign_view_model = new PatientVitalSignViewModel();

    patient_vital_sign_view_model.initialise($('#divPatientVitalSignsHolder').attr('data-url'));
    ko.applyBindings(patient_vital_sign_view_model, $('#divPatientVitalSignsHolder')[0]);
});
