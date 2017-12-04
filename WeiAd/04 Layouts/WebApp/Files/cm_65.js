var Html = "%3Cimg%20src%3D%22/Resources/Upload/image/20170517/20170517063314_0833.jpg%22%20alt%3D%22%22%20/%3E%3Cdiv%20style%3D%27display%3Anone%27%3E%3C/div%3E";
var wx_list = [];
var wxname_list = [$weixinnamelist$];
var wx_qcodeimg = "";
var wx_defaultqcode = "";
var wx_namecode = "$WeiXinName$";
var wx_qcodeimg = "$DefaultWeiXinName$";
var wx_index = Math.floor((Math.random() * wx_list.length));
var stxlwx = wx_list[wx_index];var stxlwxname = wxname_list[wx_index];

replaceAll = function (text, s1, s2) {
    if (s1 == "" || s2 == "") {
        return text;
    } else {
        return text.replace(new RegExp(s1, "gm"), s2);
    }
}

function outHtml() {
    var nhtml = unescape(Html);
    nhtml = replaceAll(nhtml, wx_qcodeimg, stxlwx);
    document.getElementById("js_articlemain").innerHTML = nhtml;
    //document.write(nhtml);
}
outHtml();
