
function _htmlactive() {
    var url = document.location.pathname;
    if (url == "")
        return;

    var list = $(".nav > li");
    for (var i = 0; i < list.length; i++) {
        
        if ($(list[i]).html().indexOf(url) != -1)
        {
            $(list[i]).addClass("active cur");
        }
    }

    var actice = $(".title_nav li");

    if (url.indexOf("_") != -1 && url.indexOf("/Channels/") != -1) {
        url = url.substr(0, url.indexOf("_"));
        url += "_1.html";
    } else {
        var cid = url.substr(url.indexOf("/WebSite/") + 9);
        cid = cid.substr(0, cid.indexOf("/"));
        
        var curl = "/WebSite/Channels/" + cid + "_1.html";
        for (var i = 0; i < list.length; i++) {

            if ($(list[i]).html().indexOf(curl) != -1) {
                $(list[i]).addClass("active cur");
            }
        }

        for (var i = 0; i < actice.length; i++) {

            if ($(actice[i]).html().indexOf(curl) != -1) {
                $(actice[i]).addClass("active cur");
            }
        }
    }
    
    for (var i = 0; i < actice.length; i++) {

        if ($(actice[i]).html().indexOf(url) != -1) {
            $(actice[i]).addClass("active cur");
        }
    }
}

$(function () {
    _htmlactive();
})