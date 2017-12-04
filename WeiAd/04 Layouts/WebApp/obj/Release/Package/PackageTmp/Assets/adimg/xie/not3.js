
function postcheck() {

    try {
        var ys = "";
        var yanse = document.getElementsByName("chanpin1");
        if (yanse.length != 0) {
            var numa = 0;
            for (var i = 0; i < yanse.length; i++) {
                if (yanse[i].checked) {
                    numa++;
                    ys += yanse[i].value + ",";
                }
            }
            $("#hidColor").val(ys);
            if (numa == 0) {
                alert("还未选择【" + shuxing[0] + "】，请选择后再提交");
                return false;
            }
        }
    }
    catch (ex) {
    }

    try {
        var cc = "";
        var chicun = document.getElementsByName("chanpin2");
        if (chicun.length != 0) {
            var numb = 0;
            for (var i = 0; i < chicun.length; i++) {
                if (chicun[i].checked) {
                    numb++;
                    cc += chicun[i].value + ",";
                }
            }
            $("#hidSize").val(cc);
            if (numb == 0) {
                alert("还未选择【" + shuxing[1] + "】，请选择后再提交");
                return false;
            }
        }
    }
    catch (ex) {
    }

    try {
        var chicun = document.getElementsByName("chanpin3");
        if (chicun.length != 0) {
            var numb = 0;
            for (var i = 0; i < chicun.length; i++) {
                if (chicun[i].checked) {
                    numb++;
                }
            }
            if (numb == 0) {
                alert("还未选择【" + shuxing[2] + "】，请选择后再提交");
                return false;
            }
        }
    }
    catch (ex) {
    }

    if (document.getElementById("zsid").value == "1") {
        try {
            var chicun = document.getElementsByName("zengsong1");
            if (chicun.length != 0) {
                var numb = 0;
                for (var i = 0; i < chicun.length; i++) {
                    if (chicun[i].checked) {
                        numb++;
                    }
                }
                if (numb == 0) {
                    alert("还未选择【" + zsshuxing[0] + "】，请选择后再提交");
                    return false;
                }
            }
        }
        catch (ex) {
        }
        try {
            var chicun = document.getElementsByName("zengsong2");
            if (chicun.length != 0) {
                var numb = 0;
                for (var i = 0; i < chicun.length; i++) {
                    if (chicun[i].checked) {
                        numb++;
                    }
                }
                if (numb == 0) {
                    alert("还未选择【" + zsshuxing[1] + "】，请选择后再提交");
                    return false;
                }
            }
        }
        catch (ex) {
        }
        try {
            var chicun = document.getElementsByName("zengsong3");
            if (chicun.length != 0) {
                var numb = 0;
                for (var i = 0; i < chicun.length; i++) {
                    if (chicun[i].checked) {
                        numb++;
                    }
                }
                if (numb == 0) {
                    alert("还未选择【" + zsshuxing[2] + "】，请选择后再提交");
                    return false;
                }
            }
        }
        catch (ex) {
        }
    }



    try {
        var cname = $("input[name='name']").val();
        if (cname == "") {
            alert('请填写姓名！');
            //$("input[name='name']").focus();
            return false;
        }
        var name = /^[\u4e00-\u9fa5]{2,6}$/;
        if (!name.test(cname)) {
            alert('姓名格式不正确，请重新填写！');
            //document.form[0].name.focus();
            return false;
        }
    }
    catch (ex) {
    }
    try {
        var cmob = $("input[name='mob']").val();

        if (cmob == "") {
            alert('请填写手机号码！');
            //document.form[0].mob.focus();
            return false;
        }
        var form = /^1[3,4,5,6,7,8]\d{9}$/;
        if (!form.test(cmob)) {
            alert('手机号码格式不正确，请重新填写！');
            //document.form[0].mob.focus();
            return false;
        }
    }
    catch (ex) {
    }
    try {
        var cprovince = $("input[name='province']").val();
        if (cprovince == "") {
            alert('请选择所在地区！');
            //document.form[0].province.focus();
            return false;
        }
    }
    catch (ex) {
    }
    try {
        var caddress = $("input[name='address']").val();
        if (caddress == "") {
            alert('请填写详细地址！');
            //document.form[0].address.focus();
            return false;
        }
    }
    catch (ex) {
    }
    // document.form.submit.disabled = true;
    // document.form.submit.value="正在提交，请稍等 >>";
    __addcus();
    return true;
}
try {
    new PCAS("province", "city", "area");
}
catch (ex) {
}
try {
    var thissrc = document.getElementById("yzm").src;
    function refreshCode() {
        document.getElementById("yzm").src = thissrc + "?" + Math.random();
    }
}
catch (ex) {
}
/*///////////////////////////////////////// ORDERJSFGX /////////////////////////////////////////*/
function pricea() {
    //var product = document.form.product.alt;
    //for (var i = 0; i < document.form.product.length; i++) {
    //    if (document.form.product[i].checked == true) {
    //        var product = document.form.product[i].alt;
    //        break;
    //    }
    //}

    var product = 99;
    var num = document.getElementById("mun").value;
    var price = product * parseInt(num);
    document.getElementById("b1").checked = 'checked';
    $("#txtprice").val(price);
    $("#zfbprice").val(price);
    //document.form.price.value = price;
    //document.form.zfbprice.value = price;
    //document.getElementById("showprice").innerHTML=price;
    document.getElementById("zfbyh").innerHTML = '';
}
function priceb() {
    var cpxljg = document.getElementById("product");
    var product = cpxljg.options[document.getElementById("product").options.selectedIndex].title;
    if (document.form.mun.value == "" || document.form.mun.value == 0) {
        var mun = 1;
    }
    else {
        var mun = document.form.mun.value;
    }
    var price = product * mun;
    document.getElementById("b1").checked = 'checked';
    document.form.price.value = price;
    document.form.zfbprice.value = price;
    //document.getElementById("showprice").innerHTML=price;
    document.getElementById("zfbyh").innerHTML = '';
}

//***************************  支付宝价格  ***************************
function zfbprize() {
    sprice = document.form.zfbprice.value;
    // alert(sprice);
    document.form.price.value = (sprice * notzfbzk * 0.1).toFixed(0)
}
/*///////////////////////////////////////// ORDERJSFGX /////////////////////////////////////////*/
function changeItem(i) {

    if (i == 1) {
        //document.getElementById("paydiv1").style.display = "block";
        //document.getElementById("paydiv0").style.display = "none";
        if (notzfbzk != 0) {
            zfbprize();
            document.getElementById("zfbyh").innerHTML = '<font color=red><b><s>&nbsp;原价：' + document.form.zfbprice.value + '元&nbsp;</s>&nbsp;' + notzfbzk + '折</b></font>';
        }
    } else {
        //oprize1();
        //document.getElementById("paydiv0").style.display = "block";
        //document.getElementById("paydiv1").style.display = "none";
        document.getElementById("zfbyh").innerHTML = '';
        document.form.price.value = document.form.zfbprice.value;
    }
}

function addnumber() {
    $('#mun').val(parseInt($('#mun').val()) + 1);
    pricea();
}

function minnumber() {
    if ($('#mun').val() > 1) {
        $('#mun').val(parseInt($('#mun').val()) - 1);
        pricea();
    }
}
function inputnumber() {
    var number = parseInt($('#mun').val());
    if (isNaN(number) || number < 1) {
        $('#mun').val('1');
        pricea();
    } else {
        $('#mun').val(number);
        pricea();
    }
}


$(document).ready(function () {
    $(".not3chanpin0 label").bind("click", function () {
        var o = $(this);
        if (!o.hasClass("now")) {
            $(".not3chanpin0 label").removeClass("now");
            o.addClass("now");
        }
    });
})
$(document).ready(function () {
    $(".not3chanpin1 label").bind("click", function () {
        var o = $(this);
        if (!o.hasClass("now")) {
            $(".not3chanpin1 label").removeClass("now");
            o.addClass("now");
        }
    });
})
$(document).ready(function () {
    $(".not3chanpin2 label").bind("click", function () {
        var o = $(this);
        if (!o.hasClass("now")) {
            $(".not3chanpin2 label").removeClass("now");
            o.addClass("now");
        }
    });
})
$(document).ready(function () {
    $(".not3chanpin3 label").bind("click", function () {
        var o = $(this);
        if (!o.hasClass("now")) {
            $(".not3chanpin3 label").removeClass("now");
            o.addClass("now");
        }
    });
})
$(document).ready(function () {
    $(".zengsong1 label").bind("click", function () {
        var o = $(this);
        if (!o.hasClass("now")) {
            $(".zengsong1 label").removeClass("now");
            o.addClass("now");
        }
    });
})
$(document).ready(function () {
    $(".zengsong2 label").bind("click", function () {
        var o = $(this);
        if (!o.hasClass("now")) {
            $(".zengsong2 label").removeClass("now");
            o.addClass("now");
        }
    });
})
$(document).ready(function () {
    $(".zengsong3 label").bind("click", function () {
        var o = $(this);
        if (!o.hasClass("now")) {
            $(".zengsong3 label").removeClass("now");
            o.addClass("now");
        }
    });
})
/*///////////////////////////////////////// ORDERJSFGX /////////////////////////////////////////*/
var llref = '';
if (document.referrer.length > 0) {
    llref = document.referrer;
}
try {
    if (llref.length == 0 && opener.location.href.length > 0) {
        llref = opener.location.href;
    }
}
catch (e) { }

/*///////////////////////////////////////// ORDERJSEND /////////////////////////////////////////*/