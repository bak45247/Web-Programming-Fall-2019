var mainUrl = "https://webrequestsserverbethel.azurewebsites.net/api/favoritecharacters"
var index

window.onload = function() {
    // These are for form 1
    document.getElementById("forcePush").onclick = postCharacter;
    document.getElementById("forcePull").onclick = getCharacter;
    document.getElementById("forceRead").onclick = forceReadAsync;
    // These are for form 2
    document.getElementById("watchMovies").onclick = postView;
    document.getElementById("forceInsight").onclick = getView;
    document.getElementById("forceDelete").onclick = deleteCharacter;
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

async function forceReadAsync() {
    var response = await fetch(mainUrl);
    var jsonResult = await response.json();
    console.log(jsonResult);

    var index = Math.floor(Math.random() * jsonResult.length)
    console.log(index);

    response = await fetch(mainUrl + "/" + index);
    jsonResult = await response.json();

    simpleSuccess(jsonResult);
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

function deleteCharacter() {
    if(index){
        $.ajax(mainUrl,
            {
                method: "GET",
                success: deleteWithIndex,
                error: simpleError
            });
    }else{
        $.ajax(mainUrl,
            {
                method: "GET",
                success: deleteNoIndex,
                error: simpleError
            });
    }
}

function deleteWithIndex(data) {
    if(index < data.length){
        $.ajax(mainUrl + "/" + index,
        {
            method: "DELETE",
            success: simpleSuccess,
            error: simpleError
        });
    }else{
        deleteNoIndex(data);
    }
}

function deleteNoIndex(data) {
    var deleteIndex = Math.floor(Math.random() * data.length);

    $.ajax(mainUrl + "/" + deleteIndex,
        {
            method: "DELETE",
            success: simpleSuccess,
            error: simpleError
        });
}