$(function () {

    var url = "http://app.1hangye.com/Services/ClientView.ashx?t=vvv";    
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
})