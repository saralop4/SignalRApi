const connection = new signalR.HubConnectionBuilder()
    .withUrl("/imchub")
    .build();

connection.on("ReceiveImc", function (imc) {
    console.log("Tu IMC es: ", imc);
});

// Ejemplo de cómo enviar datos al controlador
function enviarDatosIMC(peso, estatura) {
    fetch('/api/imcapi', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ peso: peso, estatura: estatura })
    });
}

connection.start().catch(function (err) {
    return console.error(err.toString());
});
