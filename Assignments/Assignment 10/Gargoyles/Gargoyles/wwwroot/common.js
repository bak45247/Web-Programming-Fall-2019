var mainUrl = "/api/gargoyles";

function getFunc() {
	var requestUrl = mainUrl;
	if (document.getElementById('name').value) {
		requestUrl = mainUrl + "/" + document.getElementById('name').value;
	}
	$.ajax(requestUrl,
		{
			method: "GET",
            success: simpleResponse,
			error: simpleError
		}
	);	
}

function simpleResponse(data) {
	document.getElementById('result').innerHTML = JSON.stringify(data);
}

function simpleError(response, status, error) {
	document.getElementById('result').innerHTML = response.status + ": " + error + " " + response.responseText;
}

function putFunc() {
    var dataToSend = {};

    var name = document.getElementById("name").value;
    if (name) {
        dataToSend.name = name;
    }

    var color = document.getElementById("color").value;
    if (color) {
        dataToSend.color = color;
    }

	$.ajax(mainUrl + "/" + name,
		{method: "PUT",
		success: simpleResponse,
		error: simpleError,
		contentType: 'application/json',
            processData: false,
            data: JSON.stringify(dataToSend)
		}
	);
}

window.onload = function () {
    document.getElementById("getButton").onclick = getFunc;
    document.getElementById("putButton").onclick = putFunc;
}