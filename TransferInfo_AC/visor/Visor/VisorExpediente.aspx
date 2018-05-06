<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VisorExpediente.aspx.cs" Inherits="VisorExpediente" %>

<html >
<head  >
    <title></title>
      <meta charset='utf-8'>
            
            
        
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="AC SOLUTIONS">



            <link rel="stylesheet" href="css4/styles.css">
            <script src="js/jquery-latest.min.js" type="text/javascript"></script>
            <script src="script.js"></script>
            <script type="text/javascript" src="js/jquery.js" ></script>
            <script type="text/javascript" src="js/jqueryui.js" ></script>
            <script type="text/javascript" src="js/jquery.mousewheel.min.js" ></script>
            <script type="text/javascript" src="js/jquery.iviewer.js" ></script>
            <script type="text/javascript">

                var $ = jQuery;
                $(document).ready(function () {
                    $("#viewer").hide();
                });
                function leer(doc, ext) {
                    if (ext == "imagen") {
                        mostrar(doc);
                    }
                    if (ext == "pdf") {
                        frame(doc);
                    }
                    if (ext == "") {
                        frame(doc);
                    }
                }
                function frame(pdf) {
                    document.getElementById("frame1").src = pdf;
                    $("#frame1").show();
                    $("#viewer").hide();
                }
                function mostrar(imagen) {
                    $("#frame1").hide();
                    $("#viewer").show();
                    $("#viewer").iviewer('loadImage', imagen);
                    var iv1 = $("#viewer").iviewer({
                        src: imagen//,
                        //update_on_resize: false,
                        //zoom_animation: true,
                        //mousewheel: true,
                        //onMouseMove: function (ev, coords) { },
                        //onStartDrag: function (ev, coords) { return false; }, //this image will not be dragged
                        //onDrag: function (ev, coords) { }
                    });
                    document.title = imagen;
                }
        </script>
        <link rel="stylesheet" href="css/jquery.iviewer.css" />
        <style>
            .viewer
            {
                width: 900px;  /*95%*/
                height: 469px;
                border: 1px solid black;
                position: relative;
                background-color:white;
                overflow: auto;
            }
            .frame1
            {
                background-color:white;
                width:900px;  /*95%*/
                height:467px;
               /* position: relative;*/
                border: 1px solid black; 
            }
            .wrapper
            {
                overflow: hidden;
            }
        </style>
  
      <link rel="stylesheet" href="css/styles.css">
      
      <style type="text/css">

           table#mitabla {
               border-collapse: collapse;
               border: 1px solid #CCC;
               font-size: 12px;
          }
            
           table#mitabla th {
               font-weight: bold;
               background-color: #E1E1E1;
               padding:5px;
          }
            
           table#mitabla tbody tr:hover td {
               background-color: #F3F3F3;
          }

          table#mitabla td
          {
              padding: 5px 10px;
          }

        .newStyle1
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12pt;
            font-weight: normal;
            color:#6c6d71;
        }
      
        .auto-style2
        {
            height: 100px;
            width: 1000px;
        }
        .auto-style3
        {
            height: 80px;
            width: 320px;
        }
          .newStyle2
          {
              font-family: Arial, Helvetica, sans-serif;
              font-size: small;
              border-style:solid;
              border-width:0px;
              border-bottom-width:1px;
                height:20px;
                cursor:hand;      
                vertical-align:middle;        

          }
          .newStyle3
          {
              font-family: Arial, Helvetica, sans-serif;
              font-size: 12px;
              font-weight: bold;
          }
      
             body {
           
        }

        .starter-template {
              padding: 10px 10px;
            text-align: left;
        }

        /*menu*/
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
          </style>
   
</head>
<body  style="margin-top:0px;margin-left:0px;margin-right:0px; ">
 <ul>
  <li><a href="BuscarExpediente.aspx">Inicio</a></li>
  <li><a class="active" href="#">Consultar Expediente</a></li>
  <!--li><a href="#contact">Configuraciones</a></li-->
  <li style="float:right"><a href="#about">Visor de Expedientes</a></li>
</ul>
      <form id="form1" runat="server">
  
   <div class="container starter-template">
            <div class="row">
             
               <div class="col-md-4 col-md-offset-4">
                    <h2><%=archivoZIP %></h2>
                </div>
            </div>
    </div>
  
        <div style="align-content:center;vertical-align:central;text-align:center; grid-row-align:center;">
          <table border="0">
                <tr>
 
                     <td style="vertical-align:top;border-color:#006600;"   class="auto-style2">
                         <strong>&nbsp;
                         Archivos:
                                    </strong>
                                    <table style="width:100%; font-size:smaller;border-color:#006600;" border="0" >
                                            <tr>
                                                  <td style="background-color:white;" ><!-- aqui inicia -->
                                                          <table border="0">
                                                                  <tr>
                                                                        <td  style="vertical-align:top;text-align:left;margin-left:0px;background-color:white" class="auto-style3" >  
                                                                                  <div style="border: 1px solid #006600; overflow:auto; width:420px; height:468px;  background-color:white;">
                                                                                          <div  id='cssmenu2'  >
                                                                                                <div style="font-size:2px; font-weight:bold;text-wrap:none;color:black;">
                                                                                                    <%=html %>
                                                                                                </div>
                                                                                          </div>
                                                                                   </div>
                                                                          </td>
                                                                          <td style="width:1300px;margin-left:0px;vertical-align:top; text-align:left;"  >
                                                                                <div class="wrapper">
                                                                                      <div id="viewer" class="viewer"> </div>
                                                                                      <iframe id="frame1"  class="frame1"></iframe>
                                                                                </div>
                                                                          </td>
                                                                  </tr>
                                                           </table>
                                                    </td>
                                            </tr>
                                       </table>             
                     </td>
                </tr>
          </table>  
            
            
      </div>        
    </form>
    <%=java %>
    </body>
</html>