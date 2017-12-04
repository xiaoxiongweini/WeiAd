﻿//创建和初始化地图函数：
function initMap() {
    createMap();//创建地图
    setMapEvent();//设置地图事件
    addMapControl();//向地图添加控件
    addMarker();//向地图中添加marker
    addRemark();//向地图中添加文字标注
}

//创建地图函数：
function createMap() {
    var map = new BMap.Map("dituContent");//在百度地图容器中创建一个地图
    var point = new BMap.Point(116.299698, 40.157693);//定义一个中心点坐标
    map.centerAndZoom(point, 16);//设定地图的中心点和坐标并将地图显示在地图容器中
    window.map = map;//将map变量存储在全局
}

//地图事件设置函数：
function setMapEvent() {
    map.enableDragging();//启用地图拖拽事件，默认启用(可不写)
    map.enableScrollWheelZoom();//启用地图滚轮放大缩小
    map.enableDoubleClickZoom();//启用鼠标双击放大，默认启用(可不写)
    map.enableKeyboard();//启用键盘上下左右键移动地图
}

//地图控件添加函数：
function addMapControl() {
    //向地图中添加缩放控件
    var ctrl_nav = new BMap.NavigationControl({ anchor: BMAP_ANCHOR_TOP_LEFT, type: BMAP_NAVIGATION_CONTROL_LARGE });
    map.addControl(ctrl_nav);
    //向地图中添加缩略图控件
    var ctrl_ove = new BMap.OverviewMapControl({ anchor: BMAP_ANCHOR_BOTTOM_RIGHT, isOpen: 1 });
    map.addControl(ctrl_ove);
    //向地图中添加比例尺控件
    var ctrl_sca = new BMap.ScaleControl({ anchor: BMAP_ANCHOR_BOTTOM_LEFT });
    map.addControl(ctrl_sca);
}

//标注点数组
var markerArr = [{ title: "中宇互联（北京）科技发展有限公司", content: "地　　址&nbsp;：北京市昌平区沙河青年创业大厦B座1203室 <br/>服务热线&nbsp;：010&nbsp;-&nbsp;69739771 <br/>手　　机&nbsp;：15810332292 <br/>客服&nbsp;QQ：79507401 <br/>邮　　箱&nbsp;：chenxbwin@yeah.com", point: "116.298297|40.156176", isOpen: 1, icon: { w: 21, h: 21, l: 0, t: 0, x: 6, lb: 5 } }
];
//创建marker
function addMarker() {
    for (var i = 0; i < markerArr.length; i++) {
        var json = markerArr[i];
        var p0 = json.point.split("|")[0];
        var p1 = json.point.split("|")[1];
        var point = new BMap.Point(p0, p1);
        var iconImg = createIcon(json.icon);
        var marker = new BMap.Marker(point, { icon: iconImg });
        var iw = createInfoWindow(i);
        var label = new BMap.Label(json.title, { "offset": new BMap.Size(json.icon.lb - json.icon.x + 10, -20) });
        marker.setLabel(label);
        map.addOverlay(marker);
        label.setStyle({
            borderColor: "#808080",
            color: "#333",
            cursor: "pointer"
        });

        (function () {
            var index = i;
            var _iw = createInfoWindow(i);
            var _marker = marker;
            _marker.addEventListener("click", function () {
                this.openInfoWindow(_iw);
            });
            _iw.addEventListener("open", function () {
                _marker.getLabel().hide();
            })
            _iw.addEventListener("close", function () {
                _marker.getLabel().show();
            })
            label.addEventListener("click", function () {
                _marker.openInfoWindow(_iw);
            })
            if (!!json.isOpen) {
                label.hide();
                _marker.openInfoWindow(_iw);
            }
        })()
    }
}
//创建InfoWindow
function createInfoWindow(i) {
    var json = markerArr[i];
    var iw = new BMap.InfoWindow(" <b class='iw_poi_title' title='" + json.title + "'>" + json.title + " </b> <div class='iw_poi_content'>" + json.content + " </div>");
    return iw;
}
//创建一个Icon
function createIcon(json) {
    var icon = new BMap.Icon("http://app.baidu.com/map/images/us_mk_icon.png", new BMap.Size(json.w, json.h), { imageOffset: new BMap.Size(-json.l, -json.t), infoWindowOffset: new BMap.Size(json.lb + 5, 1), offset: new BMap.Size(json.x, json.h) })
    return icon;
}
//文字标注数组
var lbPoints = [{ point: "116.300084|40.15619", content: "我的标记" }
];
//向地图中添加文字标注函数
function addRemark() {
    for (var i = 0; i < lbPoints.length; i++) {
        var json = lbPoints[i];
        var p1 = json.point.split("|")[0];
        var p2 = json.point.split("|")[1];
        var label = new BMap.Label(" <div style='padding:2px;'>" + json.content + " </div>", { point: new BMap.Point(p1, p2), offset: new BMap.Size(3, -6) });
        map.addOverlay(label);
        label.setStyle({ borderColor: "#999" });
    }
}
$(function () {
    initMap();//创建和初始化地图
})
