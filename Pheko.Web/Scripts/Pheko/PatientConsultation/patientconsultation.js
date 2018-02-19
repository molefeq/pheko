$(document).ready(function () {
    $('body').on('click', '#btnCreateConsultation', function (e) {
        e.preventDefault();

        $.ajax({
            type: "POST",
            url: $('#patientdconsultationdialog').attr('data-url'),
            data: {},
            success: function (response) {
                $('#patientdconsultationdialog').empty();
                $('#patientdconsultationdialog').html(response)
                $('#patientdconsultationdialog').modal({
                    keyboard: false,
                    show: true,
                    backdrop: 'static'
                });
            },
            error: function (error) {
                alert(error.status + "<--and--> " + error.statusText);
            }
        });
    });


});


function SavePatientConsultationSuccess(response) {

    if (response.errors) {
        $('#frmSavePatientMedicalAidDependancy').displayerrors({ errors: response.errors });
    }
    else {

        $('#SearchGridContanier').empty();
        $('#SearchGridContanier').html(response);

        //var columns = [
        //  { title: "Title", field: "Title", minWidth: 150, maxWidth: 200 },
        //  { title: "FirstName", field: "FirstName", minWidth: 150, maxWidth: 200 },
        //  { title: "LastName", field: "LastName", minWidth: 150, maxWidth: 200 },
        //  { title: "IDNumber", field: "IDNumber", minWidth: 150, maxWidth: 200 },
        //  {
        //      title: "", field: "PatientId", value: "Edit", type: 'custombutton', url: $('#divEditPatientUrl').attr('data-url'),
        //      httpverb: 'get', modelid: "PatientId"
        //  }
        //];

        //$('#grid').grid({
        //    columns: columns,
        //    async: false,
        //    data: response.data
        //});
    }
}