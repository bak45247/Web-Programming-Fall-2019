var mainUrl = "api/kuzcotopia";

window.onload = function() {
    document.getElementById("addWork").onclick = doWork;
}

function doWork() {
    $.ajax(mainUrl + "/" + document.getElementById("workCount").value,
        {
            method: "POST",
            success: simpleSuccess,
            error: simpleError,
            processData: false,
            contentType: "application/json"
        });
}

function simpleSuccess(data){
    document.getElementById("error").textContent = "";
    document.getElementById("results").innerHTML = JSON.stringify(data);
}

function simpleError(data){
    document.getElementById("results").textContent = "";
    document.getElementById("error").innerHTML = JSON.stringify(data);
}
