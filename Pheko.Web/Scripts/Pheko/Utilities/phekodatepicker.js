
$(function () {
    //var datepicker = $.fn.datepicker.noConflict();
    //$.fn.bootstrapDP = datepicker;
    $('.input-group.date').datepicker({
        format: "dd/mm/yyyy",
        todayBtn: "linked",
        autoclose: true,
        calendarWeeks: true,
        todayHighlight: true
    });
});