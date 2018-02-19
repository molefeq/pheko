$(document).ready(function () {
    var str = location.href.toLowerCase();

    $("ul#menu li a").each(function (index, item) {

        if (str.indexOf(item.href.toLowerCase()) > -1) {
            $(".current").removeClass("current");
            $(item).addClass("current");
            return;
        }
    });

    var selectedControl;
    $("ul#menu li a").hover(function (e) {
        selectedControl = $('.current');
        $(".current").removeClass("current");
        $(this).children('a').addClass("current");
    },
    function (e) {
        $(".current").removeClass("current");
        $(selectedControl).addClass("current");
    });

});
