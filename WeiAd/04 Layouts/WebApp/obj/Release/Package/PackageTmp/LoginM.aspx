<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginM.aspx.cs" Inherits="WebApp.LoginM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>登录</title>
    <!-- Vendor styles -->
    <link rel="stylesheet" href="/Assets/Manager1/vendor/fontawesome/css/font-awesome.css" />
    <link rel="stylesheet" href="/Assets/Manager1/vendor/metisMenu/dist/metisMenu.css" />
    <link rel="stylesheet" href="/Assets/Manager1/vendor/animate.css/animate.css" />
    <link rel="stylesheet" href="/Assets/Manager1/vendor/bootstrap/dist/css/bootstrap.css" />

    <!-- App styles -->
    <link rel="stylesheet" href="/Assets/Manager1/fonts/pe-icon-7-stroke/css/pe-icon-7-stroke.css" />
    <link rel="stylesheet" href="/Assets/Manager1/fonts/pe-icon-7-stroke/css/helper.css" />
    <link rel="stylesheet" href="/Assets/Manager1/styles/style.css">

    <style type="text/css">
        .lblmsg {
            text-align: center;
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div class="login-container">
            <div class="row">
                <div class="col-md-12">
                    <div class="text-center m-b-md">
                        <h3>PLEASE LOGIN TO APP</h3>
                        <small>This is the best app ever!</small>
                    </div>
                    <div class="hpanel">
                        <div class="panel-body">
                            <div id="loginForm">
                                <div class="form-group">
                                    <label class="control-label" for="username">用户名</label>
                                    <input name="user" type="text" id="txtUserName" runat="server" class="form-control" placeholder="请输入用户名" />
                                    <span class="help-block small">请输入用户名...p</span>
                                </div>
                                <div class="form-group">
                                    <label class="control-label" for="password">密码</label>
                                    <input type="password" id="txtUserPwd" placeholder="请输入密码" runat="server" class="form-control" />
                                    <span class="help-block small">请输入密码...</span>
                                </div>
                                <input runat="server" type="button" class="btn btn-success btn-block" data-loading-text="正在登录..." value="登录" id="login" onserverclick="login_ServerClick" />

                                <asp:Label runat="server" ID="ltMsg" CssClass="lblmsg"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 text-center">
                    <strong>HOMER</strong> - 版权所有 Responsive WebApp
                    <br />
                    2017 Copyright Company Name
                </div>
            </div>
        </div>
    </form>
</body>
</html>
