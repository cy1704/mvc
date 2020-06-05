/// <reference path="../../../Scripts/jquery-1.10.2.min.js" />
/// <reference path="../../../Views/Shared/Error.cshtml" />
$(function () {
    var jzmm = false;
    $(".pyd_jzmm").click(function () {
        jzmm = !jzmm;
        $(this).css("pointer-events", "none");
        $(this).css(jzmm ? { "background": "#2bff08" } : { "background": "red" });
        $(this).children("span").animate(jzmm ? { "left": "65%", } : { "left": "1%", }, 600, function () { $(".pyd_jzmm").css("pointer-events", "auto"); });
    });
})

//function setCookie(name,value,day,isbase) {
//    var data = new Date();
//    data.setDate(data.getDate() + day);
//    if (isbase) {
//        value = hex_sha1(value);
//    }
//    document.cookie = name + "=" + value + ";expires=" + data;
//}
//function getCookie(name) {
//    var arr = document.cookie.match(new RegExp(name + "=([^;]+)"));
//    if (arr) {
//        return arr[1];
//    }
//    else {
//        return "";
//    }
//}
//function delCookie(name) {
//    document.cookie = "expires=-1";
//}