<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Descarga.aspx.cs" Inherits="TransferInfo_AC.Descarga" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>
          .boton  

             {
  background-color: #878aed;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        El archivo seleccionado no se puede visualizar en este visor, opcionalmente puede realizar su descarga.</div>
        <asp:TextBox ID="archivo" runat="server" Width="691px" Height="177px" TextMode="MultiLine"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="BtnDescarga" runat="server"  CssClass="boton"  Text="Descargar archivo"  BorderStyle="None" Font-Bold="True" Height="30px" Width="136px" OnClick="BtnDescarga_Click"  />
    </form>
</body>
</html>
