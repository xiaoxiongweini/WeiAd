
function randomString(len) {
    len = len || 32;
    var $chars = 'ABCDEFGHJKMNPQRSTWXYZabcdefhijkmnprstwxyz2345678';
    var maxPos = $chars.length;
    var pwd = '';
    for (i = 0; i < len; i++) {
        pwd += $chars.charAt(Math.floor(Math.random() * maxPos));
    }
    return pwd;
}


function fRandomBy(under, over) {
    switch (arguments.length) {
        case 1: return parseInt(Math.random() * under + 1);
        case 2: return parseInt(Math.random() * (over - under + 1) + under);
        default: return 0;
    }
}


var randomnum = fRandomBy(1, 4);
var btndivid = randomString(8);
var btnid = randomString(8);

function getRandom(min, max) {
    //x上限，y下限  
    var x = max;
    var y = min;
    if (x < y) {
        x = min;
        y = max;
    }
    var rand = parseInt(Math.random() * (x - y + 1) + y);
    return rand;
}

var r_Color = getRandom(210, 255);
var g_Color = getRandom(210, 255);
var b_Color = getRandom(210, 255);
var rgb_string = "rgb(" + r_Color + "," + g_Color + ", " + b_Color + ")";


var r2_Color = getRandom(210, 228);
var g2_Color = getRandom(70, 85);
var b2_Color = getRandom(50, 75);
var rgb2_string = "rgb(" + r2_Color + "," + g2_Color + ", " + b2_Color + ")";
var maxheight = document.body.scrollHeight;

document.write("<div style=\"text-align:center;top:600px; position:fixed;width:100%;height:" + maxheight + "px;\" id=\"" + btndivid + "\" class=\"1" + btndivid + "1\" >  ");
document.write("<div style='background: url(http://douzhuan.oss-cn-qingdao.aliyuncs.com/jscss/dfcssimg/hide_content_bg.png) repeat-x 0 0;width: 100%;height: " + maxheight + "px;margin: -3rem 0 2rem;z-index: 1;position: relative;background-color:white;' id=\"" + btndivid + "\">");
document.write("	<span href=\"javascript:void(0);\" style=\"color: " + rgb_string + ";background-color: " + rgb2_string + "; margin-top: 1rem;padding-top: 1rem;font-size: 1rem;padding: .5rem 0;display: inline-block;width: 50%;border-radius: 2px; text-decoration: none;\" id=\"" + btnid + "\">");
document.write("	展开全文");
document.write("	</span>");
document.write("</div>");
document.write("</div>");

//alert(maxheight);