<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendInfo.aspx.cs" Inherits="TransferInfo_AC.SendInfo" %>
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="AC SOLUTIONS">
    <link rel="icon" href="../../favicon.ico">

    <title>Transfer Info</title>

    <link href="Content/bootstrap.min.css" rel="stylesheet">
    <style>
        body {
            padding-top: 50px;
        }

        .starter-template {
            padding: 40px 15px;
        }
        .auto-style1 {
            width: 430px;
            border-collapse: collapse;
            border: 1px solid #000000;
        }
        .labelright{
            text-align:right;
        }
        .labelcenter{
            text-align:center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <nav class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#">TransferInfo</a>
            </div>
            <div id="navbar" class="collapse navbar-collapse">
                <ul class="nav navbar-nav">
                    <li><a href="Default.aspx">Inicio</a></li>
                    <li  class="active"><a href="SendInfo.aspx">Descarga Test</a></li>
                    <li><a href="ViewLog.aspx">Visor Log</a></li>
                </ul>
            </div>
            <!--/.nav-collapse -->
        </div>
    </nav>

    <div class="container">
        <div class="starter-template">

              <table cellpadding="2" cellspacing="3" class="auto-style1">
                <tr>
                    <td class="labelright">Usuario Win:</td>
                    <td><asp:TextBox ID="txtUsuario" runat="server" Text="capturista"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="labelright">Contraseña Win:</td>
                    <td><asp:TextBox ID="txtContrasena" runat="server" Text="capturista"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="labelright">Id Tramite:</td>
                    <td>
                        <asp:TextBox ID="txtIdTramite" runat="server" Text="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labelright">Id Expedientes:</td>
                    <td>
                        <asp:TextBox ID="txtIdExpedientes" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labelright">NSS:</td>
                    <td>
                        <asp:TextBox ID="txtNSS" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labelright">Archivo:</td>
                    <td>
                        <asp:FileUpload ID="fuArchivo" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="labelcenter" >
                        <asp:Button ID="btnTestWS" runat="server" Text="Test WS" OnClick="btnTestWS_Click" />
                    </td>
                </tr>
            </table>

        </div>
    </div>
    
    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    </form>
</body>
</html>
