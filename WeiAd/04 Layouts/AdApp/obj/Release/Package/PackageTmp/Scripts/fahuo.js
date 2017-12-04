function getfahuo() {
    var json = document.getElementById("__divProductJson").innerText;
    var not3str = "";
    var jdata = eval(json);
    for (var i = 0; i < jdata.length; i++) {
        var tlist = jdata[i].value;
        not3str = not3str + tlist[Math.floor((Math.random() * tlist.length))] + " "
    }
    //if (not3chanpin.length != 0) { not3str = not3str + not3chanpin[Math.floor((Math.random() * not3chanpin.length))] + " "; }
    //if (chanpin1.length != 0) { not3str = not3str + chanpin1[Math.floor((Math.random() * chanpin1.length))] + " "; }
    //if (chanpin2.length != 0) { not3str = not3str + chanpin2[Math.floor((Math.random() * chanpin2.length))] + " "; }
    //if (chanpin3.length != 0) { not3str = not3str + chanpin3[Math.floor((Math.random() * chanpin3.length))] + " "; }
    return not3str;
}
document.writeln("<ul>");
document.writeln("<li><span>[最新购买]：<\/span>张**（130****3260）在1分钟前订购了 " + getfahuo() + " <font color=\'#FF0000\'>√<\/font><\/li>");
document.writeln("<li><span>[最新购买]：<\/span>李**（136****7163）在3分钟前订购了 " + getfahuo() + " <font color=\'#FF0000\'>√<\/font><\/li>");
document.writeln("<li><span>[最新购买]：<\/span>赵**（139****1955）在7分钟前订购了 " + getfahuo() + " <font color=\'#FF0000\'>√<\/font><\/li>");
document.writeln("<li><span>[最新购买]：<\/span>刘**（180****6999）在9分钟前订购了 " + getfahuo() + " <font color=\'#FF0000\'>√<\/font><\/li>");
document.writeln("<li><span>[最新购买]：<\/span>周**（151****2588）在4分钟前订购了 " + getfahuo() + " <font color=\'#FF0000\'>√<\/font><\/li>");
document.writeln("<li><span>[最新购买]：<\/span>王**（133****4096）在10分钟前订购了 " + getfahuo() + " <font color=\'#FF0000\'>√<\/font><\/li>");
document.writeln("<li><span>[最新购买]：<\/span>秦**（139****1955）在15分钟前订购了 " + getfahuo() + " <font color=\'#FF0000\'>√<\/font><\/li>");
document.writeln("<li><span>[最新购买]：<\/span>朱**（180****6999）在20分钟前订购了 " + getfahuo() + " <font color=\'#FF0000\'>√<\/font><\/li>");
document.writeln("<li><span>[最新购买]：<\/span>吴**（151****2588）在12分钟前订购了 " + getfahuo() + " <font color=\'#FF0000\'>√<\/font><\/li>");
document.writeln("<li><span>[最新购买]：<\/span>谭**（133****4096）在18分钟前订购了 " + getfahuo() + " <font color=\'#FF0000\'>√<\/font><\/li>");
document.writeln("<\/ul>");