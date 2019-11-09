function runPost() {
	
	$.ajax(azureUrl,
	{
		method: "GET",
		success: runPostSecondStep,
		error: simpleError
	});
}

function runPostSecondStep(data) {
	if (Array.isArray(data)) {
		
		var randomIndex = Math.random(0, data.length);
		// make the second request to the server here
		// that one can use simpleResult
	} else {
		
		// display some error message here
	}
}

