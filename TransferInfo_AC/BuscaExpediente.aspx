<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuscaExpediente.aspx.cs" Inherits="TransferInfo_AC.BuscaExpediente" %>

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
            text-align: center;
        }

        .auto-style1 {
            width: 550px;
            border-collapse: collapse;
            border: 1px solid #000000;
        }
    </style>
</head>
<body>
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
                    <li><a href="#">Home</a></li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">Puente Imagenes<b class="caret"></b></a>
                        <ul class="dropdown-menu">
                            <li><a href="SendInfo.aspx">Test Puente Imagenes</a></li>
                            <li><a href="ViewLog.aspx">Visor Log Puente Imagenes</a></li>
                        </ul>
                    </li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">Recibe Imagenes<b class="caret"></b></a>
                        <ul class="dropdown-menu">
                            <li><a href="RecibeImagenes.aspx">Test Recibe Imagenes</a></li>
                            <li><a href="ViewLogRecibeImagenes.aspx">Visor Log Recibe Imagenes</a></li>
                        </ul>
                    </li>
                    <li><a href="AdminValidaciones.aspx">Validaciones</a></li>
                    <li class="active"><a href="BuscaExpediente.aspx">Visor de Expedientes</a></li>
                </ul>
            </div>
            <!--/.nav-collapse -->
        </div>
    </nav>

    <div class="container">

        <div class="starter-template">
            <form id="form1" runat="server">
                <div class="container starter-template">
                    <div class="row">
                        <div class="col-lg-12">
                            <h2>Visor de Expediente</h2>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6 col-lg-offset-3">
                            <div class="h3">Id Expediente</div>
                            <asp:TextBox ID="txtExpediente" runat="server" CssClass="form-control" autocomplete="off"></asp:TextBox>
                            <asp:Button ID="btnBuscaExpediente" runat="server" Text="Buscar" CssClass="btn btn-info" OnClick="btnBuscaExpediente_Click" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                                <%=tabla %>
                        </div>
                    </div>
                </div>
                <div>
                </div>
            </form>
        </div>
    </div>
    <!-- /.container -->


    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>
