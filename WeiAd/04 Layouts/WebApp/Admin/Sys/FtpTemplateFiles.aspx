<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Web.Master" AutoEventWireup="true" CodeBehind="FtpTemplateFiles.aspx.cs" Inherits="WebApp.Admin.Sys.FtpTemplateFiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    上传模板文件
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">上传模板文件</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-xs-2">
                                <input type="file" class="upload"  runat="server" id="FUFile" />  
                            </div>
                            <div class="col-xs-2">
                               <asp:Button ID="Button1" runat="server" Text="上传" OnClick="Button1_Click" />
                            </div>
                             <div class="col-xs-2">
                               <asp:Label  ID="message" runat="server"  Text=""/>
                            </div>
                        </div>
                        <br />
                <table  class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <th>FileName</th>
                            <th>FCreattime</th>
                            <th>Size</th>
                            <th>FilePath</th>
                            <th>Extension</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptTables">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%#Eval("filename") %>
                                    </td>
                                    <td>
                                        <%#Eval("fcreattime") %>
                                    </td>
                                    <td>
                                        <%#Math.Round((double)Eval("filesize"),2)%> KB
                                    </td>
                                    <td>
                                        <%#Eval("filepath") %>
                                    </td>
                                    <td>
                                        <%#Eval("Extension") %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                 
                    </div>
                    <!-- /.box-body -->
                </div>
                <!-- /.box -->
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->
    </section>

</asp:Content>
