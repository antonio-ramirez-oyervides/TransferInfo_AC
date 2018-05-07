<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminValidaciones.aspx.cs" Inherits="TransferInfo_AC.AdminValidaciones" %>

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
    <script type="text/javascript">
        function activarValidacion(id,e) {
            e.preventDefault();
            var valorOriginal = $('#ckActivo'+id)[0].checked;
            var valorNuevo=false;
            
            if (valorOriginal==true){
                valorNuevo=false;
            }
            else{
                valorNuevo=true;
            }

            $.ajax({
                type: "POST",
                url: "AdminValidaciones.aspx/ActivarValidacion",
                data: '{id: "' + id + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response) {
                        $('#ckActivo'+id)[0].disabled=false;
                        $('#ckActivo'+id)[0].checked=valorNuevo;
                        $('#ckActivo'+id)[0].disabled=true;
                    }
                },
                failure: function (response) {
                    alert('falla');
                }
            });
        }

    </script>
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
                    <li class="active"><a href="AdminValidaciones.aspx">Validaciones</a></li>
                    <li><a href="BuscaExpediente.aspx">Visor de Expedientes</a></li>
                </ul>
            </div>
            <!--/.nav-collapse -->
        </div>
    </nav>

    <div class="container">
        <div class="starter-template">

            <%if (dtValidaciones.Rows.Count > 0)
                {%>
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th scope="col" class="text-center">Validación</th>
                        <th scope="col" class="text-center">Descripción</th>
                        <th scope="col" class="text-center">Ultima Modificación</th>
                        <th scope="col" class="text-center">Estado</th>
                        <th scope="col" class="text-center">Activar</th>
                    </tr>
                </thead>
                <tbody>

                    <%foreach (System.Data.DataRow row in dtValidaciones.Rows)
                        {%>
                    <tr>
                        <th class="text-left" scope="row"><%= row["nombreValidacion"].ToString()%></th>
                        <td class="text-left"><%= row["descripcion"].ToString()%></td>
                        <td><%= row["fechaModificacion"].ToString()%></td>
                        <td class="text-center">
                            <% if (bool.Parse(row["bitActivo"].ToString()))
                                {%>
                            <input type="checkbox" id="ckActivo<%= row["idValidacion"].ToString()%>" checked="checked" disabled />
                            <%}
                                else
                                {%>
                            <input type="checkbox" id="ckActivo<%= row["idValidacion"].ToString()%>" disabled />
                            <%} %>
                        </td>
                        <td class="text-center">
                            <input type="button" id="btnActiva<%= row["idValidacion"].ToString()%>" onclick='activarValidacion(<%= row["idValidacion"].ToString()%>,event)' class="btn btn-info" value="Activar" />
                        </td>
                    </tr>

                    <%}%>
                </tbody>
            </table>
            <%}%>
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
