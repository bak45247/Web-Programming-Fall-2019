var mainUrl = "api/values";

document.onload = function () {
    document.getElementById("roar").onclick = doPost;
}

function doPost() {
    $.ajax(mainUrl,
        {
            method: "POST",
            success: simpleResult,
            error: simpleError,
            contentType: "application/json",
            processData: false,
            data: JSON.stringify(
                {
                    WorkCount: 5
                })
        });
}

function simpleResult(data) {
    document.getElementById("results").innerHTML = JSON.stringify(data);
}

function simpleError(data) {
    document.getElementById("error").innerHTML = JSON.stringify(data);
}