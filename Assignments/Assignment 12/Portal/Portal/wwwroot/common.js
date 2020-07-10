var loginUrl = "api/Login";
var quoteUrl = "api/Glados";
var token = "";

function simpleSuccess(data) {
    document.getElementById("success").innerHTML = JSON.stringify(data);
}

function simpleError(data) {
    document.getElementById("error").innerHTML = JSON.stringify(data);
}

window.onload = function () {
    document.getElementById("login").onclick = login;
    document.getElementById("getQuote").onclick = getQuote;
}

async function login() {
    let data = {
        Username: document.getElementById("username").value,
        Password: document.getElementById("password").value
    }

    let fetchData = {
        method: "POST",
        body: JSON.stringify(data),
        headers: {
            "Content-Type": "application/json"
        }
    }

    var response = await fetch(loginUrl, fetchData);

    if (!response.ok) {
        document.getElementById("error").innerHTML = JSON.stringify(response.status);
        return;
    }

    var result = await response.headers
    token = result.get("authorization");
    document.getElementById("logVisual").innerHTML = "Logged In"
}

async function getQuote() {
    let fetchData = {
        method: "GET",
        headers: {
            "authorization": token
        }
    }

    var response = await fetch(quoteUrl, fetchData);

    if (!response.ok) {
        debugger;
        document.getElementById("error").innerHTML = JSON.stringify(response.status);
            return;
    }

    var result = await response.json();
    document.getElementById("success").innerHTML = JSON.stringify(result);
}
