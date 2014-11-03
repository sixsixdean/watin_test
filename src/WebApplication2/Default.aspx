<%@ Page Title="主页" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApplication2._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script type="text/javascript">
        function $(id) {
            return document.getElementById(id);
        }

        function LoginSystem(pwdId, pwd, frmId) {
            $(pwdId).value = pwd;
            var f = $("form[0]");
            if (f != null) {
                f.submit();
            }
        }


        function openURL() {
            var newWin = window.open("http://szzyfax/iworks/enter");
            newWin.opener = null;
        }

    </script>
    <h2>
        欢迎使用 ASP.NET!
    </h2>
    <p>
        若要了解关于 ASP.NET 的详细信息，请访问 <a href="http://www.asp.net/cn" title="ASP.NET 网站">www.asp.net/cn</a>。<asp:Button
            ID="Button1" runat="server" Text="Button" OnClick="Button1_Click1" />
    </p>
    <p>
        您还可以找到 <a href="http://go.microsoft.com/fwlink/?LinkID=152368" title="MSDN ASP.NET 文档">
            MSDN 上有关 ASP.NET 的文档</a>。
    </p>
</asp:Content>
