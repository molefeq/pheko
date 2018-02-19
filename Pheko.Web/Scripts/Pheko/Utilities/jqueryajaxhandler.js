function ajaxpost(async, cache, data, data_type, onsuccess, onerror) {
    $.ajax({
        type: "POST",
        url: self,
        async: false,
        cache: false,
        data: JSON.stringify(ko.mapping.toJS({ model: url })),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.errors) {
                $('#divPatientDetails').displayerrors({ errors: response.errors });
            }
            else if (response.ok) {
                ko.mapping.fromJS(response.data, {}, patient);
            }
        },
        error: function (error) {
            alert(error.status + "<--and--> " + error.statusText);
        }
    });
}