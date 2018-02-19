$(document).ready(function () {
    var patient_medical_note_view_model = new PatientMedicalNoteViewModel();

    patient_medical_note_view_model.initialise($('#PatientMedicalNoteHolder').attr('data-url'));
    ko.applyBindings(patient_medical_note_view_model, $('#PatientMedicalNoteHolder')[0]);
});
