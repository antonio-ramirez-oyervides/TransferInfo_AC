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

        .labelright {
            text-align: right;
        }

        .labelcenter {
            text-align: center;
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
                        <li class="active"><a href="SendInfo.aspx">Descarga Test</a></li>
                        <li><a href="ViewLog.aspx">Visor Log</a></li>
                    </ul>
                </div>
                <!--/.nav-collapse -->
            </div>
        </nav>

        <div class="container starter-template">
            <div class="row">
                <div class="col-md-4 col-md-offset-4">
                    <div class="form-group">
                        <label>Usuario Win:</label>
                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" Text="capturista"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="pwd">Contraseña Win:</label>
                        <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control" Text="capturista"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="pwd">Id Tramite:</label>
                        <asp:TextBox ID="txtIdTramite" runat="server" CssClass="form-control" Text="100"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="pwd">Id Expedientes:</label>
                        <asp:TextBox ID="txtIdExpedientes" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="pwd">NSS:</label>
                        <asp:TextBox ID="txtNSS" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="pwd">Archivo:</label>
                        <asp:FileUpload ID="fuArchivo" CssClass="form-control" runat="server" />
                    </div>

                    <div class="checkbox">
                        <asp:Label runat="server" ID="lblResultado" Text=""></asp:Label>
                    </div>
                    <asp:Button ID="btnTestWS" runat="server" Text="Test WS" class="btn btn-info" OnClick="btnTestWS_Click" />
                &nbsp;&nbsp;
                     <asp:Button ID="btnNewInfo" runat="server" Text="Nuevos Datos" class="btn btn-info" OnClick="btnNewInfo_Click" />
                </div>
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
