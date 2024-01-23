$(document).ready(function () {
  $("#formularioContacto").on("submit", function (e) {
    e.preventDefault();
    console.log(recaptchaValidate());
    if (!$(this).valid() || !recaptchaValidate()) {
      return;
    }

    // generarToken();
    let mail = {
      Subject:
        "NUEVO CLIENTE " + $("#name").val() + " " + $("#last").val() + " ",

      Body:
        "<div -ms-text-size-adjust:100%;margin-top:0;margin-bottom:0;margin-right:0;margin-left:0;padding-top:0;padding-bottom:0;padding-right:0;padding-left:0;font-family:Arial, Helvetica, sans-serif;font-size:14px;color:#000000;-webkit-text-size-adjust:none;><span display:none!important;visibility:hidden;mso-hide:all;font-size:1px;color:#ffffff;line-height:1px;max-height:0px;max-width:0px;opacity:0;overflow:hidden ></span><table width='100%' cellpadding='0' cellspacing='0' bgcolor='#30373f' background-color:#D9E5E7><tr><td><br/></td></tr><tr><td><table width='400'bgcolor='#ffffff' cellpadding='0' cellspacing='0' align='center'><tr><td><center><table width='600' cellpadding='0' cellspacing='0' align='center'><tr><td align='left'><p style='margin:0;padding:0; background-color: white'><a><img src='mages/logo-retina.svg' width='300'  style='display:block' /></a></p></td></tr></table></center><table width='100%' cellpadding='0' cellspacing='0' align='center' bgcolor='#1c5aa1' style='background-color: #1c5aa1;'><tr><td width='20'></td><td align='left' style='padding: 9px 4px'><a style='font-size: 15px; line-height: 1; text-decoration: none; color: #FFFFFF;'><strong style='color:white;'>NUEVO CLIENTE " +
        $("#name").val() +
        " " +
        $("#last").val() +
        "</strong></a></td> </tr></table><center><table width='600' cellpadding='0' cellspacing='0' align='center'><tr><td height='14' width='30' style='font-size:0;height:12px'></td> <td height='14' style='font-size:0;height:12px'></td><td height='14' width='30' style='font-size:0;height:12px></td></tr><tr><td height='15' width='30' style='font-size:0;height:15px'></td><td height='15' style='font-size:0;height:0px'></td><td height='15' width='30' style='font-size:0;height:15px'></td></tr></table></center><center><table width='520' cellpadding='0' cellspacing='0' align='center><tr><td height='10' width='30' style='font-size:0;height:10px;'></td></tr></table></center><center><table width='600' cellpadding='0' cellspacing='0' align='center'><tr><td width='40'></td><td width='520' style='color: #474646; text-align:left' valign='top'>Un nuevo cliente requiere información: <br>Nombre: " +
        $("#name").val() +
        " " +
        $("#last").val() +
        " <br>Teléfono: " +
        $("#phone").val() +
        " <br>Correo: " +
        $("#mail").val() +
        " <br><br><br> <p style='text-align: center;' >ATTE.<br><br>Página Web de Seguros Mediaccess.</p> </td><td width='40'></td></tr></table></center><center><table width='520' cellpadding='0' cellspacing='0'align='center'> <tr><td height='15' width='30' style='font-size:0;height:15px;'</td></tr></table></center><br /><center><table width='520' cellpadding='0' cellspacing='0' align='center'><tr><td height='10' style='font-size:0;height:10px;'></td></tr></center><center><table width='100%' cellpadding='0' cellspacing='0' align='center' bgcolor='#efefef' style='background-color: #efefef;'><tr><td width='20'></td><td align='justify' style='padding: 9px 4px'><a style='font-size: 10px; line-height: 1; text-decoration: none; color: #3d3d3d'>AVISO DE CONFIDENCIALIDAD, ALCANCE DE CONTENIDO Y PRIVACIDAD La informacion contenida en este mensaje de correo electronico, incluyendo, en su caso, los archivos adjuntos, se encuentra protegida por la Ley y tiene el carácter de confidencial y restringida, y esta destinada unicamente para el uso de la o las personas a que esta dirigido, por lo que se notifica que esta estrictamente prohibida cualquier difusion,distribucion o copia del mismo. Si ha recibido este mensaje de correo electronico por error,debe destruirlo y notificar al remitente por esta misma via.Todas las precauciones razonables han sido tomadas para asegurar que ningun virus o malware esten presentes en este correo electronico. Medi Access S.A.P.I. o cualquiera de sus empresas relacionadas no acepta responsabilidad por cualquier perdida o daño derivado del uso de este correo o sus archivos adjuntos y usted es responsable por asegu rar que sus propios procedimientos de escaneo de virus esten actualizados y cumplan con el propósito.Los Datos Personales y sensibles que deriven de subsecuentes comunicaciones seran tratados en el marco de la Ley de Proteccion de Datos Personales en Posesion de Particulares. Para conocer nuestro Aviso de Privacidad Integral favor de acudir a nuestrapágina www.mediaccess.com.mx donde podra encontrar la forma y el proceso para ejercer los derechos que por Ley le asisten. Los acentos y caracteres especiales han sido intencionalmente  removidos de este mensaje para facilitar su lectura en cualquier programa de correo electronico.©Mediacces Seguros De Salud, Boulevard Adolfo Ruiz Cortines No 3642, Piso 9 Oficina 901-B, Colonia Jardines del Pedregal Alcaldia Álvaro Obregón, C.P. 01900, Ciudad de México. Tel.(55) 1085 2000. Todos los derechos reservados.</a></td><td width='20'></td></tr></table></center></td></tr> </table></td></tr><tr><td><br/><br/></td></tr></table></div>",

      IsBodyHtml: true,
      EncodedResponse: response,
    };
    console.log("resp mail ==>", mail);
    ValidatorCapturaDatos.resetForm();
    console.log(JSON.stringify(mail));
  });
});
function SendMail() {
  let _Id = document.getElementById("email").value;
  let _Email = ["ivan.tapia@mediacces.com.mx"];

  let _Req = {
    Subject: "Prueba",
    Body: "prueba",
    IsBodyHtml: false,
    To: _Email,
  };

  $.ajax({
    // beforeSend: function (/*xhr*/) {
    //   $.blockUI({
    //     theme: true,
    //     title: "Enviando Correo...",
    //     message:
    //       '<div class="row"><div class="col-lg-10"><br /><p><img src="images/loading/loading.gif" style="width: 35px;" /></p><p> Espere un momento por favor...</p><br /></div></div>',
    //     baseZ: 10000,
    //   });
    // },

    url: "https://webstaging.mediaccess.com.mx/IdentityAPI/ManagerEmail/SendEmail",

    type: "POST",
    dataType: "json",
    data: _Req,
    async: true,
    xhrFields: {
      withCredentials: true,
    },
    crossDomain: true,
    success: function (data) {
      console.log("Respuesta de data =>", data);
    },
    error: function (jqXHR, status, error) {
      console.log("Ocurrio un error =>", error + " " + jqXHR);
    },
  });
}

// function mail() {
//   var xmlhttp = new XMLHttpRequest(); // new HttpRequest instance
//   var theUrl =
//     "https://webstaging.mediaccess.com.mx/IdentityAPI/ManagerEmail/SendEmail";
//   xmlhttp.open("POST", theUrl);
//   xmlhttp.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
//   xmlhttp.ser;
//   xmlhttp.send(
//     JSON.stringify)
//   );

//   xmlhttp.onload = function () {
//     if (xmlhttp.status >= 200 && xmlhttp.status < 400) {
//       const data = JSON.parse(this.response);
//       //   data.forEach((pelicula) => {
//       //     console.log(pelicula.title);
//       //     console.log(pelicula.descripcion);
//       //   });
//     } else {
//       console.log("Ha ocurrido un error conc ódigo " + xmlhttp.status);
//     }
//   };
// }

// function mails() {
//   // POST request using fetch with set headers
//   const element = document.querySelector(
//     "#post-request-set-headers .article-id"
//   );
//   const requestOptions = {
//     method: "POST",
//     headers: {
//       "Content-Type": "application/json",
//       Authorization: "Bearer my-token",
//       "My-Custom-Header": "foobar",
//     },
//     body: JSON.stringify(
//         ({
//             Subject: "Prueba",
//             Body: "prueba",
//             IsBodyHtml: false,
//             To: "ivan.tapia@mediaccess.com.mx",
//           }
//         ),
//   },
//   fetch("https://reqres.in/api/articles", requestOptions,mode: 'cors',
//   headers: {
//     'Access-Control-Allow-Origin':'*'
//   })
//     .then((response) => response.json())
//     .then((data) ));
// }
