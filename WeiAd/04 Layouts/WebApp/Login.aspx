<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApp.Login" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="user-scalable=0" />
    <title>登录</title>
    <link href="/Assets/Manager/css/login.css" rel="stylesheet" />
    <style type="text/css">
        .lblmsg {
            text-align: center;
            color: red;
        }
    </style>
</head>
<body style="background-color: #ededed; background-repeat: no-repeat; background-position: center top; overflow: hidden;">
    <form id="form1" runat="server">
        <div class="logintop">
            <p>CMS系统V1.0</p>
            <ul>
                <li><a href="#">帮助</a></li>
                <li><a href="#">关于</a></li>
            </ul>
        </div>
        <div class="loginbody">
            <div class="loginbox">
                <p>用户登录</p>
                <ul>
                    <li class="loginuser">
                        <label for="user_Name">用户名</label>
                        <input name="user" type="text" id="txtUserName" runat="server" placeholder="请输入用户名" />
                    </li>
                    <li class="loginpwd">
                        <label for="user_Pwd">密&nbsp;&nbsp;&nbsp;码</label>
                        <input type="password" id="txtUserPwd" placeholder="请输入密码" runat="server" />
                    </li>
                    <li><span class="loginerror" id="login_error" style="display: none">用户名或密码错误！</span></li>
                    <li>
                        <input runat="server" type="button" class="loginbtn" data-loading-text="正在登录..." value="登录" id="login" onserverclick="login_ServerClick" />
                        <label style="display: none">
                            <input name="" type="checkbox" value="" id="chkRememberPass" />记住密码</label>
                        <asp:Label runat="server" ID="ltMsg" CssClass="lblmsg"></asp:Label>
                    </li>
                </ul>
            </div>
        </div>
        <div class="loginbm">版权所有  © 2005-2017   <a href="#">XXX公司版权所有</a>  </div>
    </form>
</body>
</html>
