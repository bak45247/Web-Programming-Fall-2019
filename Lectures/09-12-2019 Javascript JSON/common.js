
function doStuff() {
	var userInput = document.getElementById("userInput").value;
	var results = document.getElementById("results");
	results.innerHTML = "";

	// Covnerts a string into an object (throws exceptions)
	try{
		var userJson = JSON.parse(userInput);
	}catch (error){
		displayError(error);
		return;
	}
	displayError("");

	var ul = document.createElement("ul");
	results.appendChild(ul);

	if(!userJson.userArray){ // Check for the error and leave the error message as close to the check as possible
		displayError("userArray key was not found");
		return;
	}
	if(!Array.isArray(userJson.userArray)){
		displayError("userArray if not an array");
		return;
	}
	userJson.userArray.forEach(function(arrayElement) {
		// cannot return from here, not in the dostuff function anymore
		var li = document.createElement("li");
		
		if (typeof(arrayElement === "string")){
			var textNode = document.createTextNode(arrayElement);
		} else if(typeof(arrayElement === "number")){
			var textNode = document.createTextNode("number: " + arrayElement);
		}else if(typeof(arrayElement === "object")){
			if(arrayElement.name){
				var textNode = document.createTextNode("It was an object: " + arrayElement.name);
			}
			var textNode = document.createTextNode("It was an object!");
		}
		
		li.appendChild(textNode);
		ul.appendChild(li);
	});
}

function displayError(errorMessage){
	var error = document.getElementById("error");
	error.innerHTML = errorMessage;
}

window.onload = function() {
	// DOM
	// Document Object Model
	document.getElementById("doStuffButton").onclick = doStuff;
	
}
