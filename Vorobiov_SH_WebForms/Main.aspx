<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Vorobiov_SH_WebForms.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap_2.css" rel="stylesheet">
    <link href="css/MyCSS.css" rel="stylesheet">
    <style type="text/css">
       
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div class="container-fluid">
            <header class="row-fluid">
                <div class="span2 myy">
                    Smart Home
                </div>
                <div class="span5 myg">
                    Weather
                </div>
                <div class="span5 myr">
                    Date and Time
                </div>
            </header>
            <div class="row-fluid">
                <!--Sidebar content-->
                <div class="span2 myf">
                    <div>
                        <asp:Button CssClass="btn btn-primary" ID="ClimatDevicesButton" runat="server" Height="29px" Text="Climat devices" Width="157px" />
                        <br />
                        <br />
                        <asp:Button CssClass="btn btn-primary" ID="LightingButton" runat="server" Height="29px" Text="Lighting" Width="157px" />
                        <br />
                        <br />
                        <asp:Button CssClass="btn btn-primary" ID="WindowsButton" runat="server" Height="29px" Text="Windows" Width="157px" />
                        <br />
                        <br />
                        <asp:Button CssClass="btn btn-primary" ID="SaunaButton" runat="server" Height="29px" Text="Sauna" Width="157px" />
                        <br />
                        <br />
                        <asp:Button CssClass="btn btn-primary" ID="SecurityButton" runat="server" Height="29px" Text="Security" Width="157px" />
                    </div>
                </div>
                <!--Body content-->
                <div id ="body_content" runat ="server" class="span10 myb">
                 
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    <br />
                    
                </div>
            </div>
        </div>
    </form>
    <%--<script src="http://code.jquery.com/jquery-latest.js"></script>
    <script src="js/bootstrap.min.js"></script>--%>
</body>
</html>
