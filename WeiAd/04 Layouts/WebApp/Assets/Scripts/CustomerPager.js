document.write("<script src='/JavaScript/bootstrap-paginator.js' type='text/javascript'></script>");

function CustomerPage(pagecount,divid,currentpage) {
    var options = {
        currentPage: currentpage,
        totalPages: pagecount,
        pageUrl: function (type, page, current) {
            var path = location.pathname;
            var pname = path.substr(path.lastIndexOf("/"));
            var pf = pname.substr(0, pname.indexOf("_"));
            var url = path.replace(pname, pf + "_" + page + ".html");
            return url;
        },
        itemTexts: function (type, page, current) {
            switch (type) {
                case "first":
                    return "首页";
                case "prev":
                    return "上一页";
                case "next":
                    return "下一页";
                case "last":
                    return "未页";
                case "page":
                    return " " + page +" ";
            }
        }, shouldShowPage: true,
        itemContainerClass: function (type, page, current) {
            switch (type) {
                case "first":
                    return "";
                case "prev":
                    return "";
                case "next":
                    return "";
                case "last":
                    return "";
                case "page":
                    if (page == current)
                    {
                        return "active";
                    } else {
                        return "";
                    }
                
            }
        }
    }

    $('#' + divid).bootstrapPaginator(options);
}