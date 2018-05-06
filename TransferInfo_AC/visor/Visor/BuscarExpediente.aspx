<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BuscarExpediente.aspx.cs" Inherits="BuscarExpediente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head  >
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content="AC SOLUTIONS"/>
    <link rel="icon" href="../../favicon.ico"/>

    <title>Transfer Info</title>

      

    <style>
        body {
             
        }

        .starter-template {
            padding: 10px 10px;
            text-align: left;
        }

        
        /*menu*/

        ul {
    list-style-type: none;
    margin: 0;
    padding: 0;
    overflow: hidden;
    background-color: #333;
}

li {
    float: left;
    border-right:1px solid #bbb;
}

li:last-child {
    border-right: none;
}

li a {
    display: block;
    color: white;
    text-align: center;
    padding: 14px 16px;
    text-decoration: none;
}

li a:hover:not(.active) {
    background-color: #111;
}

.active {
    background-color: #878aed;
}

        .boton  

             {
  background-color: #878aed;
}
         
    </style>
</head>
<body  style="margin-top:0px;margin-left:0px;margin-right:0px; ">
 <ul>
  <li><a class="active" href="#home">Inicio</a></li>
  <li><a  href="BuscarExpediente.aspx">Consultar Expediente</a></li>
  <!--li><a href="#contact">Configuraciones</a></li-->
  <li style="float:right"><a href="#about">Visor de Expedientes</a></li>
</ul>
<form id="form1" runat="server">
    
 

       <div class="container starter-template">
            <div class="row">
                <div class="col-md-4 col-md-offset-4">
                    <h2>Visor de Expediente</h2>
                </div>
              
            </div>

        <div>Id Expediente</div>
        <asp:TextBox ID="txtExpediente" runat="server"></asp:TextBox>

        <asp:Button ID="Button1" runat="server" Text="Buscar" OnClick="Button1_Click" CssClass="boton" BorderStyle="None" Font-Bold="True" Height="30px" Width="75px" />

        <div>

            <%=tabla %>




        </div>
    </div>
  
    <div>
    



    </div>
    </form>
</body>
</html>
