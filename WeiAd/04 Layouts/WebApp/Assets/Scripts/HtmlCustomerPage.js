/*自定义界面*/

///提交数据
function SubmitCustomerPage(divid,formid) {
    var list = $("#" + divid + " :input ");

    var o = {};
    o.FormId = formid;
    o.Data = [];

    for (var i = 0; i < list.length; i++) {
        var name = $(list[i]).attr("dbColumn");
        var val = $(list[i]).val();
        var isNot = $(list[i]).attr("isNot"); 
        var cnName = $(list[i]).attr("cnName");
        if (isNot == "1")
        {
            if (val == "")
            {
                alert("【" + cnName + "】不允许为空。");
                return;
            }
        }
        o.Data.push({ Name: name, Value: val });
    }

    var data = $.toJSON(o);

    var url = "/Services/CustomerPage.ashx?t=" + new Date();
    var p = document.location.pathname;
    $.ajax({
        url: url,
        data: { data:  data },
        success: function (data) {
            alert(data);
            for (var i = 0; i < list.length; i++) {
                $(list[i]).val("");
            }
        },
        error: function (xhr) {
        }
    });
}
