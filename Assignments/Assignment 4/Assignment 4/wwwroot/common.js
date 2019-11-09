var mainUrl = "/api/characters"
var index

window.onload = function() {
    // These are for form 1
    document.getElementById("forcePush").onclick = postCharacter;
    document.getElementById("forcePull").onclick = getCharacter;
    document.getElementById("forceRead").onclick = getRandomCharacter;
    // These are for form 2
    document.getElementById("watchMovies").onclick = postView;
    document.getElementById("forceInsight").onclick = getView;
}

function simpleSuccess(data){
    document.getElementById("error").innerHTML = ""
    document.getElementById("results").innerHTML = JSON.stringify(data);
}

function simpleError(data){
    document.getElementById("results").innerHTML
    document.getElementById("error").innerHTML = JSON.stringify(data);
}

// post character
function postCharacter() {
    $.ajax(mainUrl,
        {
            method: "POST",
            success: simpleSuccess,
            error: simpleError,
            processData: false,
            contentType: "application/json",
            data: JSON.stringify({
                FirstName: document.getElementById("firstName").value,
                LastName: document.getElementById("lastName").value,
                Character: document.getElementById("favoriteCharacter").value
            })
        });
}

// get all characters
function getCharacter() {
    $.ajax(mainUrl,
        {
            method: "GET",
            success: simpleSuccess,
            error: simpleError
        });
}

//first step, gets all characters and sends them to the second step method
function getRandomCharacter() {
    $.ajax(mainUrl,
        {
            method: "GET",
            success: getRandomCharacterSecondStep,
            error: simpleError
        });
}
// second step, grabs the list of characters and grabs a random one based on the length of the array
function getRandomCharacterSecondStep(data) {
    if(!Array.isArray(data)){
        return simpleError("Data must be an array");
    }

    index = Math.floor(Math.random() * data.length)

    $.ajax(mainUrl + "/" + index,
        {
            method: "GET",
            success: simpleSuccess,
            error: simpleError
        });
}

// post view date to the last force read character
function postView() {
    if(!index) {
        return simpleError("You must force read before you can post View Date")
    }

    $.ajax(mainUrl + "/" + index + "/views",
        {
            method: "POST",
            success: simpleSuccess,
            error: simpleError,
            processData: false,
            contentType: "application/json",
            data: JSON.stringify({
                ViewDate: document.getElementById("viewDate").value
            })
        });
}

function getView() {
    $.ajax(mainUrl + "/" + index + "/views",
        {
            method: "GET",
            success: simpleSuccess,
            error: simpleError
        });
}