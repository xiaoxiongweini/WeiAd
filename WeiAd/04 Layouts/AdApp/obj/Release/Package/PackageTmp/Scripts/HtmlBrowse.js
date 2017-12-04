
$(function () {
    var url = "/Services/GetLog.ashx?t=v";
    var p = document.location.pathname + document.location.search;
    var hp = document.referrer;
    var purl = document.URL;

    var adid = $("#__hidAdId").val();
    var aduserid = $("#__hidAdUserId").val();

    $.ajax({
        url: url,
        data: { _pname: p, _curl: purl, _hisurl: hp, adid: adid, aduserid: aduserid },
        success: function (data) {
            //alert(data);
        },
        error: function (xhr) {
        }
    });
});
