// Write your JavaScript code.

// Función para actualizar la variable añoIngresado cuando se modifica el campo de texto
function actualizarAñoIngresado() {
    var añoInput = document.getElementById("año");
    var añoIngresado = añoInput.value;

    var añoBusqueda = document.getElementById("año-busqueda");
    añoBusqueda.textContent = añoIngresado;
}


