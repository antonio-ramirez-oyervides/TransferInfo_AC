<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Buscar.aspx.cs" Inherits="Buscar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div ><h3>Descargar Expediente</h3></div>
    <br />

        <div>Id Expediente</div>
        <asp:TextBox ID="txtExpediente" runat="server"></asp:TextBox>

        <asp:Button ID="Button1" runat="server" Text="Buscar" OnClick="Button1_Click" />

        <div>

            <%=tabla %>




        </div>

    </div>
    <p>
        <h3>Visualizar log</h3></p>
    
        Fecha (DDMMAAAA)<br />
     <asp:TextBox ID="txtfecha" runat="server"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Ver log" />
        <br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Height="333px" TextMode="MultiLine" Width="749px"></asp:TextBox>
    </form>
    <br />
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</body>
</html>
