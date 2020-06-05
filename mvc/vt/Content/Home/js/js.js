$(function () {
    var sh = $(".header").height();
    $(document).scroll(function () {
        if ($(".h_top").height() <= $(this).scrollTop()) {
            $("body").css({ "padding-top": sh });
            $(".header").css({ "position": "fixed", "top": "0", "box-shadow": "#000 0 -20px 50px" });
            $(".h_top").css({ "padding": "5px 10px 5px", "border-bottom": "none" });
            $(".logo").css({ "display": "none" });
            $("nav").css({ "position": "absolute", "top": "0", "left": "50%", "transform": "translateX(-50%)" });
        }
        else {
            $(".header").css({ "position": "", "box-shadow": "none" });
            $(".h_top").css({ "padding": "35px 10px 10px", "border-bottom": "1px solid #ddd" });
            $(".logo").css({ "display": "block" });
            $("nav").css({ "position": "","transform": "translateX(0)" });
            $("body").css({ "padding-top": 0 });
        }
    })

    //banner轮播图
    //自运行 三秒一次
    var width = parseInt($(".banner .sli").css("width"));
    var maxwidth = width * $(".banner .sli").length;
    var bannertime = null;
    var bannerkg = true;
    $(".banner .sli").css({ "width": width, "float": "left" });
    $(".banner .ban_bd").css({ "width": maxwidth, position: "relative" });
    var i = 0;
    $(".banner .prev").click(function () {
        bannerkg = false;
        $(this).attr("disabled", "disabled");
        if (i <= 0) {
            $(".banner .ban_bd").animate({ right: -50 }, 200, function () {
                $(this).animate({ right: 0 }, 200, function () { $(".banner .prev").prop("disabled", ""); });
            });
        }
        else {
            i -= width;
            $(".banner .ban_bd").animate({ right: i }, 600, function () { $(".banner .prev").prop("disabled", ""); });
        }
    })
    $(".banner .next").click(function () {
        bannerkg = true;
        $(this).attr("disabled", "disabled");
        if (i >= maxwidth - width) {
            $(".banner .ban_bd").animate({ right: maxwidth - width + 50 }, 200, function () {
                $(this).animate({ right: maxwidth - width }, 200, function () { $(".banner .next").prop("disabled", ""); });
            });
        }
        else {
            i += width;
            $(".banner .ban_bd").animate({ right: i }, 600, function () { $(".banner .next").prop("disabled", ""); });
        }
    });
    bannertime = setInterval(function() {
        if (i <= 0) {
            bannerkg = true;
        }
        if (i >= maxwidth - width) {
            bannerkg = false;
        }
        if (bannerkg) {
            $(".banner .next").click();
        }
        else {
            $(".banner .prev").click();
        }
    }, 3000);
    



    //品牌拖动
    //块鼠标拖动
    //自动停在最近的div
    let startX = 0;     //移动距离，用来检测拖动还是点击
    let isclick = true;
    let pp_liWidth = parseInt($(".pyd_pp_ul ul li").css("width"));//品牌的每个li宽度
    let pp_liLength = $(".pyd_pp_ul ul li").length;//品牌的总个数
    let PP_VisLength = $(".pyd_pp_ul").width() / pp_liWidth;//品牌的可见个数
    $(".pyd_pp_ul ul").css("width", pp_liLength * pp_liWidth);
    $(".pyd_pp_ul").mousedown(function (e) {
        var Left = 0;
        startX = e.clientX;
        var dqLeft = parseInt($(".pyd_pp_ul ul").css("left"));//当前距离左边的距离
        var wz = e.clientX - $(".pyd_pp_ul ul").offset().left;//鼠标位置 
        $(document).mousemove(function (e) {
            Left = (e.clientX - $(".pyd_pp_ul").offset().left) - wz;
            $(".pyd_pp_ul ul").css({ left: Left });
        });
        $(document).mouseup(function (e) {
            $(document).unbind();

            var pp_left = parseInt($(".pyd_pp_ul ul").css("left"));
            if (pp_left <= 0 && pp_left > -(pp_liWidth * (pp_liLength - PP_VisLength))) {
                $(".pyd_pp_ul ul").animate({ "left": Math.round(pp_left / pp_liWidth) * pp_liWidth }, 100);
            }
            if (pp_left > 0) {
                $(".pyd_pp_ul ul").animate({ "left": 0 });
            }
            if (pp_left <= -(pp_liWidth * (pp_liLength - PP_VisLength))) {
                $(".pyd_pp_ul ul").animate({ "left": -pp_liWidth * (pp_liLength - PP_VisLength) });
            }
        });
    });
    $(".pyd_pp_ul").mouseup(function (e) {
        if (startX != e.clientX) {
            isclick = false;
        }
        else {
            isclick = true;
        }
        $(".pyd_pp_ul a").click(function () { return isclick; });
    });


    //产品详细
    $(".search").click(function () {
        $.get("/Home/getpro", { id: $(this).parents(".yf_Clxp_bj").children(".id").val() }, function (mag) {
            $(".yf_body_right .title").text(mag.title);
            $(".yf_body_right .amount").text(mag.amount);
            $(".yf_body_right .sketch").text(mag.sketch);
            $(".yf_body .id").val(mag.ID);
            $(".yf_body_right .ckxx").attr("href", "/Home/proinfo?id=" + mag.ID);
            var pictures = mag.Picture.split(",");
            $(".yf_body_left .xxk_img").prop("src", "/Content/Home/image/" + pictures[0]);
            $(".yf_body_left ul li").remove();

            for (var i = 0; i < pictures.length; i++) {
                var li = document.createElement("li");
                var img = document.createElement("img");

                li.className = "xxk_li";
                img.src = "/Content/Home/image/" + pictures[i];
                li.appendChild(img);
                li.onmouseover = function () {
                    $(".xxk_img").attr("src", $(this).children().scroll().attr("src"));
                    $(this).css("border-color", "#ff6a00");
                };
                li.onmouseout = function () {
                    $(this).css("border-color", "#fff");
                };
                $(".yf_body_left ul").append(li);
            }
            $(".yf_body_bj").css("display", "block");
        })
        
    })
    $(".close").click(function () {
        $(".yf_body_bj").css("display", "none");
    })
    $(".xxk_li").mouseover(function () {
        $(".xxk_img").attr("src", $(this).children().scroll().attr("src"));
        $(this).css("border-color", "#ff6a00");
    })
    $(".xxk_li").mouseout(function () {
        $(this).css("border-color", "#fff");
    })
    $(".h1").mouseover(function () {
        $(".yf_man_nav_right").css("display", "block");
    });
    $(".h1").mouseout(function () {
        $(".yf_man_nav_right").css("display", "none");
    })




    cart();
    $(".gwclink").click(function () {
        console.log($(this).parent().parent().children(".id").val());
        $.get("/Shop/addCart", { id: $(this).parent().parent().children(".id").val() }, function () {
            cart();
        })
    })
    console.log($(".top-gwc"));
});

function cart() {
    $.get("/Shop/Cart", {}, function (mag) {
        $(".top-gwc").html(mag);
        $(".top-gwc .remove").click(function () {
            console.log($(this).parents().children(".id").val());
            $.get("/Shop/deleteCart", { id: $(this).parents().children(".id").val() }, function () { cart(); })
        })
    })
}