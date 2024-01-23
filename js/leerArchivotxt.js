$(document).ready(function () {
  //   let _Path = "\\CursoHtml\\Configu
  var loc = window.location.pathname;
  var dir = loc.substring(0, loc.lastIndexOf("/"));

  readDirectory("./Configuracion.txt");
});

function readTextFile(file) {
  var reader = new FileReader(); // Crea un objeto FileReader
  reader.onload = function (e) {
    var lines = e.target.result.split("\n"); // Divide el contenido del archivo en líneas
    for (var line of lines) {
      console.log(line); // Imprime cada línea en la consola
    }
  };
  reader.readAsText(file); // Lee el archivo como texto
}

function readDirectory(directory) {
  var reader = new FileReader(); // Crea un objeto FileReader
  reader.onload = function (e) {
    var files = e.target.result.split("\n"); // Divide la lista de archivos en líneas
    for (var file of files) {
      var filename = file.trim();
      if (filename !== "") {
        // Ignora líneas en blanco
        var filepath = directory + "/" + filename;
        fetch(filepath) // Carga el archivo utilizando la API Fetch
          .then((response) => response.blob()) // Convierte la respuesta en un objeto Blob
          .then((blob) => readTextFile(blob)) // Lee el archivo como texto
          .catch((error) => console.log(error)); // Maneja errores
      }
    }
  };
  reader.readAsText(directory); // Lee la lista de archivos como texto
}
