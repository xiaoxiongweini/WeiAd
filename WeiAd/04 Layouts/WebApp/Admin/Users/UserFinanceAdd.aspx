<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/WebEmp.Master" AutoEventWireup="true" CodeBehind="UserFinanceAdd.aspx.cs" Inherits="WebApp.Admin.Users.UserFinanceAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    编辑频道信息
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .row {
            padding-top: 20px;
        }

            .row label {
                padding-top: 5px;
                text-align: right;
            }

        .imgprive {
            width: 100px;
            height: 100px;
        }
    </style>
    <script type="text/javascript">
        $(function () {
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <asp:HiddenField runat="server" ID="hidId" />
    <section class="content">
        <!-- SELECT2 EXAMPLE -->
        <div class="box " >
            <!-- /.box-header -->
            <div class="box-body ">
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">操作方式</label>
                        <div class="col-xs-6">
                            <asp:DropDownList runat="server" ID="ddlRechargeType" CssClass="form-control"></asp:DropDownList>

                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">金额(元)</label>
                        <div class="col-xs-6">
                            <input type="text" runat="server" id="txtMoney" value="0" class="form-control" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2"></label>
                        <div class="col-xs-4">
                            <asp:Button runat="server" ID="btnSave" CssClass="btn btn-info form-control" Text="保存" OnClick="btnSave_Click" />
                        </div>
                    </div>
                </div>
                <!-- /.row -->
            </div>
        </div>
        <!-- /.box -->
    </section>
    <!-- /.content -->
</asp:Content>
