// $(document).ready(function () {
//   let url =
//     "https://webstaging.mediaccess.com.mx/APISASE/HumanResources/GetAllVacantes";
//   let token =
//     "E8HPyEnRK6zo2MMG6VFh3yt4I1sEWZevoxijnqisfmL7mM0D6U5vWqvxT556ewgkIZTGlYTO4qcdtKIIQ3ZeTCNggWORZksABD_gufol00EP2L_N7oiFHQTbKzZsdKHRrrdqXxQMwFX-78ZpTutJAVqBHhDA5hKNCO9NIqsxO-1RJ4cWEBHHMFMqzojMVdbencvmY-otA7oVZmRRxDusrjFWCOYQAi9uwU3zVzNYSKNRTMzkvsy0Y8S0NXNOEso1O3nd4OOQa2mF96mfzNenTcgLt_YmW96qzIijh-0nmdXZroJlL2XOKJ0WOgpiRo0fQFkSpjv-YmdKm37OK9fcTNZ1xBytqI7bEcQseJ4TPMSyCuyxxuAr7RZR9ORrHN3eG_SPfVnl4O8N6_-i_HsArbrG2-Hyns3vnVzBBvhe1pJzwjxnPZ9ZYa329dz3FiniRgU-8tQGnKwsead_0rv3stqeyxPBoql3AxDcS7hh8QFl9k0sjljiTemBRxnDpkvUk3_eXB8-7Z9W30bOTJdMeMnqVDN1gG90nQaSGmtviL0r-Y5oJHMRSNWx2sM17iDqXelXt9PJD_aSbJTEv08a4sbNEnH6D-0ZpLroAu_rixGihIy6gk9UokN32j8xBcwx30Tyo16Fg_A1FjOPmbR1nRKDsnsVWyVf4aFE8wbK-b5YTLLz1Ny9zTZPUZobtN_0WZKGPj3M7GYyE3qql9rTanxK_OMiZsiXKRAKP529BBOqFvWfjj7o10ZjfpFMTzbhXA3T8FA6k20jTlpmPIwiVrIeD1mMOjB2TfqCYZa0UL3o0MZZAHcE3Wq1NKLEJ2Z9GcG2Ew2s_cl03pIIWvFo2OTiO847e3gfkzQ2oqi5XgEZzqaNvCSalx4qD5WMG0wiaG35vtg0Imgt4bu3fNWXqajV2gGOTLoTpXIiUwOsyJpbyUJmwF5w-qp0_bNQQgMDREmtkmwREqV036tnMdgbjgqcm_AlnHgRC4F9kpgg0_0CjNJg7m0K1j0HAukYjFCY6CTII2UiM6LrAj8RVTWtN1_6YYR5sjKeMi327w4wLroG2NTpDp4zdsk0b1XDFYM6nxigA0RompL2Alx4CCXZlsJJau1q699kdxZ-TA51oUAs2oHEHTSQg0hsE9zQcp2Z_SVrq_Y6B8F6uSyC-tJj53N3BaALiien1M-N9O8564kiVL6-qxklBkgJCCFF8gUIUuhj9iw9aA6J3Oe5aVyJveDnQkYJ_HJKl1LrWLtQxKoXOGuAavjKXI1tWYp0SQimzI-auafzoyqZ0bsryCNKhEJn5CxlFODd0a8zJ4kmlvXsSY47k9OehW4q4DCecG7SEb7iO3v8slhDVIw28qg1eHAsoYz1g2mNqArN6PkPZ0_SegrwIqhagMmHRmgvQyf1psgJr3waRLvLv6Jl8vb2yDSLXrbsivp9sG092SveGHqguc5_TjWj8NMc2KYnKQxbc9FCTBfaEd521VRxj4YOnlqrN0mo9b_zeftXwdsBBsXQ6vcpeUzWBWEJTIEm-JpyvxNtGm8tUfDELnOppma4DTm1ARBtQGMFqh8d83SgZCMMC3X6aC21G6JbuAFVcea7I6l598P83b2Hbx_kUDZEqJXin18rlgt5t5mfrCMIJsMWP1dV6svKVIw9gPVIcJpGc2obquPRn_mbrpkgh_B7HfbM1lY2gUVuuMXfOB5VTalBrXTOu90sHozLOqjDK14acoCVktu3rtrmPICaJ1ytfq5AkjEi8aYXLlkJ9s-MV8gh48sy3uJ9Ip1aB9lMDwLQTAFJ2_LHrjUxhek5zeYcAtcYckaAa_gBjjEpFZpA4w8QqD9s88vanW-KGyaeBRIuxZy48U758a0Pq1R66IUo5g";
//   fetch(url, {
//     method: "POST",
//     mode: "cors",
//     ContentType: "application/json",
//     headers: {
//       Authorization: "bearer " + token,
//     },
//     credentials: "omit",
//   })
//     .then((response) => response.json())
//     .then((data) => console.log(data))
//     .catch((error) => console.error(error));
// });

// const url = "https://ejemplo.com/api/endpont";
// const token = "Bearer <token_de_autenticación>";
// const username = "usuario";
// const password = "contraseña";
// const credentials = `${username}:${password}`;
// const base64Credentials = btoa(credentials);

// fetch(url, {
//   method: "POST",
//   headers: {
//     "Content-Type": "application/json",
//     "Authorization": `Basic ${base64Credentials}`,
//     "Authorization": token
//   },
//   body: JSON.stringify({
//     // Aquí iría el contenido del cuerpo de la solicitud
//   })
// })
// .then(response => {
//   // Aquí procesarías la respuesta de la solicitud
// })
// .catch(error => {
//   // Aquí manejarías cualquier error que se produzca
// });
// ----------------------------

// fetch(url, {
//   method: "POST",
//   headers: {
//     "Content-Type": "application/json",
//     "Authorization": token
//   },
// //   body: JSON.stringify({
// //     // Aquí iría el contenido del cuerpo de la solicitud
// //   })
// })
// .then(response => {
//   // Aquí procesarías la respuesta de la solicitud
// })
// .catch(error => {
//     alert(error)
//   // Aquí manejarías cualquier error que se produzca
// });
// -----------------------------------------------------------------------------------
//  // Send a POST request
// let _Token = '';
// var reqData = {
//   username: "ivan.tapia@mediaccess.com.mx",
//   password: "hnl0CLkj",
//   grant_type: "password",
// };
// //var reqData = "username=ganesh&password=123456&grant_type=password";
// axios({
//   method: "POST",
//   url: "https://webstaging.mediaccess.com.mx/APISASE/token",
//   withCredentials: false,
//   // crossdomain: true,
//   data: $.param(reqData),
//   headers: {
//     "Content-Type": "application/x-www-form-urlencoded",
//     "Cache-Control": "no-cache",
//     "Access-Control-Allow-Origin": "*",
//     //   "Access-Control-Allow-Methods": "*",
//     // "Postman-Token": "42e6c291-9a09-c29f-f28f-11872e2490a5",
//   },
// })
//   .then(function (response) {
//     console.log("Heade With Authentication :" + response);
//     _Token = response.data.access_token;
//     const url = "https://webstaging.mediaccess.com.mx/APISASE/HumanResources/GetAllVacantes";
//     const token = 'Bearer token ' + _Token;
//     // const url = "https://ejemplo.com/api/endpont";
// // const token = "Bearer <token_de_autenticación>";
// // const username = "usuario";
// // const password = "contraseña";

// const username= "ivan.tapia@mediaccess.com.mx";
// const password= "hnl0CLkj";
// const credentials = `${username}:${password}`;
// const base64Credentials = btoa(credentials);

// fetch(url, {
//   method: "POST",
//   headers: {
//     'Content-Type': 'application/json',
//     "Authorization": `Basic ${base64Credentials}`,
//     "Authorization": token
//   },
//   credentials: 'omit',
//   body: JSON.stringify({
//     // Aquí iría el contenido del cuerpo de la solicitud
//   })
// })
// .then(response => {
//   // Aquí procesarías la respuesta de la solicitud
// })
// .catch(error => {
//   // Aquí manejarías cualquier error que se produzca
// });

//   })
//   .catch(function (error) {
//     console.log("Post Error : " + error);
//   });
// ---------------------------------------
// Codigo para obtener el consumo del api
// fetch(url, {
//   method: 'POST',
//   ContentType: 'application/json',
//   headers: {
//     "Authorization": "bearer " + token
//   },
//   credentials: 'omit',
// //   body: JSON.stringify({
// //     // Aquí iría el contenido del cuerpo de la solicitud
// //   })
// })
// .then(response => {
//     console.log("Solo falta la data")
//   // Aquí procesarías la respuesta de la solicitud
// })
// .catch(error => {
//   // Aquí manejarías cualquier error que se produzca
// });

// -----------------------REGRESA LA DATA ----------------------------
// $.ajax({
//   url : 'https://webstaging.mediaccess.com.mx/APISASE/HumanResources/GetAllVacantes',
//   data : {},
//   type: 'POST',
//   // Añade un header:
//   headers: {"Authorization": "bearer " + token},
//   // El resto del código
//   success : function(json) {
//      debugger;
//   }
// });
