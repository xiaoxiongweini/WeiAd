//编码
function html_encode(str)
{
    var s = "";
    if (str.length == 0 ) return "";
    s = str.replace(/</g, "&lt;");
    s = s.replace(/>/g, "&gt;");
    //s = s.replace(/    /g, "&nbsp;");
    s = s.replace(/\'/g, "'");
    s = s.replace(/\"/g, "&quot;");
    //s = s.replace(/\n/g, "<br>");
    return s;
}

//解码
function html_decode(str)
{
    var s = "";
    if (str.length == 0) return "";
    s = str.replace(/&lt;/g, " <");
    s = s.replace(/&gt;/g, ">");
    //s = s.replace(/&nbsp;/g, "    ");
    s = s.replace(/'/g, "\'");
    s = s.replace(/&quot;/g, "\"");
    //s = s.replace(/<br>/g, "\n");
    return s;
}

//设置控件选中项
function setSelect(id, val)
{
    $("#" + id).val(val);
}

//消息提示, ->JavaScript/Plugs/Confirm/dist
function zyhl_alter(content, url) {
    $.alert({
        title: '消息提示',
        content: content,
        confirmButton: '确定',
        confirmButtonClass: 'btn-primary',
        icon: 'fa fa-info',
        animation: 'zoom',
        confirm: function () {
            if (url != "") {
                document.location.href = url;
            }
        }
    });
}


//手机号码的校验
function checkTel(value) {
    var isPhone = /^([0-9]{3,4}-)?[0-9]{7,8}$/;
    var isMob = /^((\+?86)|(\(\+86\)))?(13[0123456789][0-9]{8}|15[012356789][0-9]{8}|1[78][02356789][0-9]{8}|147[0-9]{8}|1349[0-9]{7})$/;
    if (isMob.test(value) || isPhone.test(value)) {
        return true;
    } else {
        return false;
    }
}

/* 
用途：检查输入的Email信箱格式是否正确 
输入： 
strEmail：字符串 
返回： 
如果通过验证返回true,否则返回false 

*/
function checkEmail(strEmail) {
    //var emailReg = /^[_a-z0-9]+@([_a-z0-9]+\.)+[a-z0-9]{2,3}$/; 
    var emailReg = /^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$/;
    if (emailReg.test(strEmail)) {
        return true;
    } else {
        alert("您输入的Email地址格式不正确！");
        return false;
    }
}

function showopen(obj) {
    var src = $(obj).attr("src");
    window.open(src, null, null, null);
}


/**
 * 获取当前URL参数值
 * @param name	参数名称
 * @return	参数值
 */
function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null)
        return unescape(r[2]);
    return null;

}