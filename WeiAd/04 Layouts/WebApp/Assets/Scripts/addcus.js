function __addcus()
{
    var url = "http://app.1hangye.com/Services/AddCus.ashx";
    //var url = "/Services/AddCus.ashx";
    var p = document.location.pathname + document.location.search;
    var hp = document.referrer;
    var purl = document.URL;

    var realname = $("#txtRealName").val();
    var phone = $("#txtPhone").val();
    var wxname = $("#txtWxName").val();
    var address = $("#txtAddress").val();
    var remark = $("#txtRemark").val();
    var province =$("#ddlprovince").val();
    var city = $("#ddlcity").val();
    var area = $("#ddlarea").val();
    var adid = $("#__hidAdId").val();
    var aduserid = $("#__hidAdUserId").val();
    
    var num = $("#mun").val();
    var price = $("#txtprice").val();
    
    var productname = $("#a0").val();
    var color = $("#hidColor").val();
    var size = $("#hidSize").val();

    var obj = {};
    obj.rname = realname;
    obj.phone = phone;
    obj.wxname = wxname;
    obj.address = address;
    obj.__url = purl;
    obj.refurl = hp;
    obj.remark = remark;
    obj.province = province;
    obj.city = city;
    obj.area = area;
    obj.size = size;
    obj.color = color;
    obj.productname = productname;
    obj.num = num;
    obj.price = price;
    obj.adid = adid;
    obj.aduserid = aduserid;

    $.ajax({
        type: "POST",
        url: url,
        data: obj,
        success: function (result) {
            alert(result.msg);
        },
        error: function (xhr) {
        }
    });
}