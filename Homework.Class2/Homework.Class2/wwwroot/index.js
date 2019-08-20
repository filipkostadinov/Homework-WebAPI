let firstName = document.getElementById("firstName");
let lastName = document.getElementById("lastName");
let age = document.getElementById("age");
let button = document.getElementById("btn1");

let url = "http://localhost:64490/api/users";

let createNewUser = async () => {
    let user = {
        firstName: firstName.value,
        lastName: lastName.value,
        age: age.value
    };
    await fetch(url, {
        method: "POST",
        headers: {
            "Content-Type":"application/json"
        },
        body: JSON.stringify(user)
    });
}

button.addEventListener("click", createNewUser);