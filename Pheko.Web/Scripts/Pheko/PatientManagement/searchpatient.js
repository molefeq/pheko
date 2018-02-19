

function SearchPatientBegin() {
    $('#SearchGridContanier').show();
    $('#grid').empty();
}

function SearchPatientSuccess(response) {

    if (response.errors) {
        $('#divPatientSearch').displayerrors({ errors: response.errors });
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