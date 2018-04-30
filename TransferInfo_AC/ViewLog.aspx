<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewLog.aspx.cs" Inherits="TransferInfo_AC.ViewLog" %>


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
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/moment.js/2.9.0/moment-with-locales.js"></script>
    <script src="//cdn.rawgit.com/Eonasdan/bootstrap-datetimepicker/e8bddc60e73c1ec2475f827be36e1957af72e2ea/src/js/bootstrap-datetimepicker.js"></script>

    <link href="Content/bootstrap.min.css" rel="stylesheet">

    <script type="text/javascript">
        $(function () {
            $('#datetimepicker1').datetimepicker({ format: 'DD/MM/YYYY' });

            if ($('#fechaSel').val() == "") {
                var today = new Date();
                var dd = today.getDate();
                var mm = today.getMonth() + 1; //January is 0!

                var yyyy = today.getFullYear();
                if (dd < 10) {
                    dd = '0' + dd;
                }
                if (mm < 10) {
                    mm = '0' + mm;
                }
                var today = dd + '' + mm + '' + yyyy;
                $('#fechaSel').val(today);
            }
        });

        function send() {
            if ($('#fechaSel').val() == "") {
                return;
            }

            $('#txtfecha').val($('#fechaSel').val());
            $('#btnVerLog').click();
        }

    </script>
    <style>
        body {
            padding-top: 50px;
        }

        .starter-template {
            padding: 40px 15px;
            text-align: center;
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
                    <li><a href="SendInfo.aspx">Puente Imagenes</a></li>
                    <li class="active"><a href="ViewLog.aspx">Visor Log Puente Imagenes</a></li>
                    <li><a href="RecibeImagenes.aspx">Recibe Imagenes</a></li>
                    <li><a href="ViewLogRecibeImagenes.aspx">Visor Log Recibe Imagenes</a></li>
                </ul>
            </div>
            <!--/.nav-collapse -->
        </div>
    </nav>
    <form id="form1" runat="server" autocomplete="off">
        <div class="container starter-template">
            <div class="row">
                <h4>Log de "Puente Imagenes"</h4>
            </div>
        </div>

        <div class="container">
            <div class="row">
                <div class="col-md-8 col-md-offset-2">
                    <div>
                        <h3>Descargar Expediente</h3>
                    </div>
                    <br />

                    <div>Id Expediente</div>
                    <asp:TextBox ID="txtExpediente" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Button ID="btnConsultaExp" runat="server" Text="Buscar" CssClass="btn btn-info" OnClick="btnConsultaExp_Click" />

                    <div>
                        <%=tabla %>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-8 col-md-offset-2">
                    <div>
                        <h3>Visualizar log</h3>
                    </div>
                    Fecha (DDMMAAAA)<br />
                    <div class="input-group date" id="datetimepicker1">
                        <input type='text' id="fechaSel" class="form-control" placeholder="Issue Date" />
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                    <div class="btn btn-info" onclick="send();">Ver Log</div>

                    <br />
                    <asp:TextBox ID="txtlog" runat="server" Height="333px" Width="100%" TextMode="MultiLine"></asp:TextBox>
                    <div class="label-info">
                        <asp:Literal runat="server" ID="txtCuenta"></asp:Literal>
                    </div>
                    <div style="display: none; visibility: hidden">
                        <asp:TextBox ID="txtfecha" runat="server" />
                        <asp:Button ID="btnVerLog" runat="server" CssClass="btn btn-info" OnClick="btnVerLog_Click" Text="Ver log" />
                    </div>
                </div>
            </div>
        </div>
    </form>
    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->

    <script src="Scripts/bootstrap.min.js"></script>

</body>
</html>
