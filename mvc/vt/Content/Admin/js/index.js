$(document).ready(function () {
    if ($(".yf_login_input").val() != "") {
        $(".yf_login_input").parent().addClass("layui-input-active");
    } else {
        $(".yf_login_input").parent().removeClass("layui-input-active");
    }
    $(".yf_login_input").click(function (e) {
        e.stopPropagation();
        $(this).parent().addClass("layui-input-focus").find(".yf_login_input").focus();
    });
    $(".yf_login_input").focus(function () {
        $(this).parent().addClass("layui-input-focus");
    });
    $(".yf_login_input").blur(function () {
        $(this).parent().removeClass("layui-input-focus");
        if ($(this).val() != "") {
            $(this).parent().addClass("layui-input-active");
        } else {
            $(this).parent().removeClass("layui-input-active");
        }
    })
    var index1=true;
    $("#index_i").click(function () {
        if (index1) {
            $(this).attr("class", "fa fa-chevron-up");
            $(".index_ul").slideToggle(300);
            index1 = !index1;
        } else {
            $(this).attr("class", "fa fa-chevron-down");
            $(".index_ul").slideToggle(300);
            index1 = !index1;
        }
            
    })
    $(".index_ul").children().click(function () {
        $(".index_ul").children().each(function () {
            $(this).removeClass();
        })
        $(".index_head").removeClass("index_on");
        $(this).addClass("index_on");
    })
    //$(".index_head").click(function () {
    //    $(".index_ul").children().each(function () {
    //        $(this).removeClass();
    //    })
    //    $(this).addClass("index_on");
    //    var bb = (this).find("a").text();
    //    $(".index_right_nav_ul li").each(function () {
    //        if (bb == $(this).find("a").text()) {
    //            $(this).addClass("index_right_nav_on");
    //        } else {
    //            $(this).removeClass("index_right_nav_on");
    //        }
    //    })
    //})
    $(".index_ul").children().click(function () {
        var ss = 0, aa = $(this).find("a").text();
        $(".index_head").click(function () {
            $(".index_ul").children().each(function () {
                $(this).removeClass();
            })
            $(this).addClass("index_on");
            var bb = $(this).find("a").text();
            $(".index_right_nav_ul li").each(function () {
                if (bb == $(this).find("a").text()) {
                    $(this).addClass("index_right_nav_on");
                } else {
                    $(this).removeClass("index_right_nav_on");
                }
            })
        })
        $(".index_right_nav_ul li").each(function () {
            $(this).removeClass("index_right_nav_on");
        })
        $(".index_right_nav_ul li").each(function () {
            if (aa == $(this).find("a").text()) {
                ss = 1;
                $(this).addClass("index_right_nav_on");
            }
        })
        $(".index_right_head_right_ss_ul_li").click(function () {
            var div = $("<li class='index_right_nav_on'><i class='fa fa-desktop'></i><a href=" + $(this).find("a").attr("href") + " target='rightmain'>" + $(this).find("a").text() + "</a><i class='fa fa-close'></i></li>");
            $(".index_right_nav_ul").append(div);
        })
        if (ss==0) {
            var div = $("<li class='index_right_nav_on'><i class='fa fa-desktop'></i><a href=" + $(this).find("a").attr("href") + " target='rightmain'>" + $(this).find("a").text() + "</a><i class='fa fa-close'></i></li>");
            $(".index_right_nav_ul").append(div);
            $(".fa-close").click(function () {
                $(this).parent().remove();
                $(".index_head").click();
            })
            $(".index_right_nav_ul li").click(function () {
                var cc = $(this).find("a").text();
                console.log(cc);
                $(".index_right_nav_ul li").each(function () {
                    $(this).removeClass("index_right_nav_on");
                })
                $(this).addClass("index_right_nav_on");
                $(".index_ul").children().each(function () {
                    if (cc == $(this).find("a").text()) {
                        $(this).addClass("index_on");
                    } else {
                        $(this).removeClass();
                    }
                })
                if (cc == "首页") {
                    $(".index_head").addClass("index_on");
                } else {
                    $(".index_head").removeClass("index_on");
                }
            })
        }
    })
    

    var index2 = true;
    $(".index_right_head_left").click(function () {
        if (index2) {
            $(this).children(":eq(0)").attr("class", "fa fa-indent");
            $(".index_left").animate({ "left": "-15%" }, 800);
            $(".index_right").animate({ "left": "0" ,"width":"100%"}, 800);
            index2 = !index2;
        } else {
            $(this).children(":eq(0)").attr("class", "fa fa-outdent");
            $(".index_left").animate({ "left": "0" }, 800);
            $(".index_right").animate({"left":"15%" , "width": "85%" }, 800);
            index2 = !index2;
        }
    })

    //$(".index_right_nav_ul li a").click(function () {
    //    $(".index_right_nav_ul li").each(function () {
    //        $(this).removeClass("index_right_nav_on");
    //    })
    //    $(this).addClass("index_right_nav_on");
    //})
    //$(".fa-close").click(function () {
    //    alert(1);
    //    $(this).parent().remove();
    //})
    $(".index_right_head_right_ss").mouseenter(function () {
        $(".index_right_head_right_ss ul").slideToggle(300);
        $(this).children("i").removeClass("fa-caret-down").addClass("fa-caret-up");
    })
    $(".index_right_head_right_ss").mouseleave(function () {
        $(".index_right_head_right_ss ul").slideToggle(300);
        $(this).children("i").removeClass("fa-caret-up").addClass("fa-caret-down");
    })

    $(".qx").click(function () {
        $(".checkbox,#qx").prop("checked", true);
    })
    $(".qc").click(function () {
        $(".checkbox,#qx").prop("checked", false);
    })
    $("#qx").click(function () {
        $(".checkbox").prop("checked", $(this).is(":checked"));
    })
    $(".fx").click(function () {
        $(".checkbox").each(function () {
            $(this).prop("checked", !$(this).is(":checked"));
        })
        if ($(".checkbox:checked").length == $(".checkbox").length) {
            $("#qx").prop("checked", true);
        } else {
            $("#qx").prop("checked",false);
        }
    })
    $(".checkbox").click(function () {
        $("#qx")[0].checked = $(".checkbox:checked").length == $(".checkbox").length;
    })
    $(".contentdelete").click(function () {
        var ids = new Array();
        for (var i = 0; i < $(".checkbox").length; i++) {
            if ($(".checkbox:eq(" + i + ")").is(":checked"))
                ids.push($(".checkbox:eq(" + i + ")").attr("value"));
        }
        var ids2 = ids.toString();
        if (confirm("是否批量删除？")) {
            $.post("/Admin/User_Deletes", { ids: ids2 }, function (msg) {
                alert(msg);
                location.reload();
            })
        }
    })



})