var Html = "$Content$";
var wx_list = [$weixinlist$];
var wxname_list = [$weixinnamelist$];
var wx_qcodeimg = "$QcodeImg$";
var wx_defaultqcode = "$DefaultQcodeImg$";
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
