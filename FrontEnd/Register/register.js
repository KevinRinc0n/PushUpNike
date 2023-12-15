const registrar = document.getElementById("form");

registrar.addEventListener('submit',async (e) => {
    e.preventDefault();

let data = Object.fromEntries(new FormData(e.target));

if (data.Password !== data.PasswordConfirm)
{
    alert("Las contraseñas no coincide. Vuelve a intentarlo")
}
else
{
    const url = 'http://localhost:5141/Nike/User/register';


    var empleado = {
        "Nombre": data.Nombre,
        "Email": data.Email,
        "Password": data.Password
    };

    var informacion = JSON.stringify(empleado)

    const post = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: informacion
        };


        fetch(url, post)
        .then(response => {
        if (!response.ok) {
            throw new Error(`La solicitud no se cumplio. (${response.status})`);
        }
        return response.text(); 
        })
        .then(result => {
        
        if (result === "Empleado ya existente"){
            alert("Ya existe un empleado con ese nombre. Intenta con otro")
        }

        if (result === "Empleado registrado correctamente"){
            alert("Registro completado")
            window.location.replace("../JWT/Login/Login.html");
        }
        console.log("Resultado:", result);
        })
        .catch(error => {
        console.error("Error:", error);
        });
}
});