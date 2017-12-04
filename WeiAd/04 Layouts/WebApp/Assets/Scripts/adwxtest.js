$(function () {

    function is_weixn() {
        var ua = navigator.userAgent.toLowerCase();
        if (ua.match(/MicroMessenger/i) == "micromessenger") {
            return true;
        } else {
            return false;
        }
    }



    function IsPC() {
        var userAgentInfo = navigator.userAgent;
        var Agents = ["Android", "iPhone",
                    "SymbianOS", "Windows Phone",
                    "iPad", "iPod"];
        var flag = true;
        for (var v = 0; v < Agents.length; v++) {
            if (userAgentInfo.indexOf(Agents[v]) > 0) {
                flag = false;
                break;
            }
        }
        return flag;
    }

    function isdebugger() {
        var purl = document.location.search;
        if (purl.indexOf("__isdebugger=1") != -1) {
            return true;
        }
        return false;
    }

    function onBridgeReady() {
        WeixinJSBridge.call('hideOptionMenu');        
    }

    $("#articletitle").hide();

    var isweixin = is_weixn();
    var result = IsPC(); //true为PC端，false为手机端
    var isbug = isdebugger();
    if (isweixin || (!result) || isbug) {
        if (typeof WeixinJSBridge == "undefined") {
            if (document.addEventListener) {
                document.addEventListener('WeixinJSBridgeReady', onBridgeReady, false);
            } else if (document.attachEvent) {
                document.attachEvent('WeixinJSBridgeReady', onBridgeReady);
                document.attachEvent('onWeixinJSBridgeReady', onBridgeReady);
            }
        } else {
            onBridgeReady();
        }

        var url = "/Services/GetAdView.ashx?t=vvv";
        var p = document.location.pathname + document.location.search;
        var hp = document.referrer;
        var purl = document.URL;
        var id = $("#spanidarticle").text();
        $.ajax({
            type: "POST",
            url: url,
            data: { _pname: p, _curl: purl, _hisurl: hp, id: id },
            success: function (data) {
                var info = eval(data);
                $("#js_articlecontent").hide();
                $("#activity-name").hide();
                $("#articletitle").show();
                $("#js_articlemain").html(info.content);
                $("#articletitle").html(info.title);
                document.title = info.title;
            },
            error: function (xhr) {
            }
        });
    }
})