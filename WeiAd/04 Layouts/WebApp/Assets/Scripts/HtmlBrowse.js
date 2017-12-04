
$(function () {
    var url = "/Services/LogBrowseSer.ashx?t=v";
    var p = document.location.pathname + document.location.search;
    var hp = document.referrer;
    var purl = document.URL;
    $.ajax({
        url: url,
        data: { _pname: p, _curl: purl, _hisurl: hp },
        success: function (data) {
            //alert(data);
        },
        error: function (xhr) {
        }
    });
});
