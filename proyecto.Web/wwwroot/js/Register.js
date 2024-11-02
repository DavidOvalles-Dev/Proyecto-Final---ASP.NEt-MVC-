// Validación completa del formulario
function validateForm() {

    console.log("Ejecutando javascript")
    const emailInput = document.getElementById("email");
    const nombreInput = document.getElementById("NombreInput");
    const apellidoInput = document.getElementById("ApellidoInput");
    const telefonoInput = document.getElementById("TelefonoInput");

    const emailAlert = document.getElementById("emailAlert");
    const nameAlert = document.getElementById("nameAlert");
    const apellidoAlert = document.getElementById("apellidoAlert");
    const telefonoAlert = document.getElementById("telefonoAlert");

    const emailValid = validateEmail(emailInput.value);
    const nameValid = validateName(nombreInput);
    const apellidoValid = validateApellido(apellidoInput);
    const telefonoValid = validateTelefono(telefonoInput);

    let isValid = true; // Bandera para verificar si el formulario es válido

    // Validar email
    if (!emailValid) {
        showAlert(emailAlert, "El email no es válido.");
        isValid = false; // Marcamos como no válido
    } else {
        emailAlert.style.display = "none";
    }

    // Validar nombre
    if (!nameValid) {
        showAlert(nameAlert, "El Nombre no es válido.");
        isValid = false; // Marcamos como no válido
    } else {
        nameAlert.style.display = "none";
    }

    // Validar apellido
    if (!apellidoValid) {
        showAlert(apellidoAlert, "El Apellido es requerido.");
        isValid = false; // Marcamos como no válido
    } else {
        apellidoAlert.style.display = "none";
    }

    // Validar teléfono
    if (!telefonoValid) {
        showAlert(telefonoAlert, "El Teléfono es requerido.");
        isValid = false; // Marcamos como no válido
    } else {
        telefonoAlert.style.display = "none";
    }

    return isValid; // Retornamos si el formulario es válido
}

function validateEmail(email) {
    const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/; // Patrón simple para validación de correo
    return emailPattern.test(email);
}

function validateName(input) {
    return input.value.trim() !== "";
}

function validateApellido(input) {
    return input.value.trim() !== "";
}

function validateTelefono(input) {
    return input.value.trim() !== "";
}

function showAlert(alertElement, message) {
    alertElement.textContent = message;
    alertElement.style.display = "block";
}
