window.onload = function() {
    document.getElementById("parseButton").onclick = jsonParse;
}

function jsonParse() {
    var userInput = document.getElementById("userInput").value;
	
	try {
		var userJson = JSON.parse(userInput);
	} catch (error) {
		displayError(error);
		return;
	}
	
    displayError("");
    
    // Now we know its JSON
    if(!userJson.buttons && !userJson.fields){
        displayError("You're Missing the Correct JSON keys")
    }

    if(userJson.buttons){
        buttons(userJson);
    }

    if(userJson.fields){
        fields(userJson);
    }

    // to keep the page a little cleaner
    var breakTag = document.createElement("br");
    document.getElementById("results").appendChild(breakTag);
}

function buttons(userJson) {
    if(!Array.isArray(userJson.buttons)){
        displayError("The Buttons Key Must Contain an Array");
        return;
    }

    var results = document.getElementById('results');

    // Buttons is for sure an array
    userJson.buttons.forEach(function(arrayElement) {
        // Create the button
        var button = document.createElement("input");
        button.type = "button";

        //check if our element is a string
        if(!typeof arrayElement === "string"){
            displayError("Button Array Must Contain Only Strings");
        }else{
            button.value = arrayElement;
            results.appendChild(button);
        }
    });
}

function fields(userJson) {
    // do the fields stuff here
    if(!Array.isArray(userJson.fields)){
        displayError("The Fields Key Must Contain an Array");
        return;
    }

    var results = document.getElementById("results");

    // fields is now an array
    userJson.fields.forEach(function(arrayElement) {
        // create text field
        var textField = document.createElement("input");
        textField.type = "text";
        var label = document.createElement("label");
        label.labelfor = textField;

        if(typeof arrayElement === "string"){
            label.textContent = arrayElement;
            results.appendChild(label);
            results.appendChild(textField);
        }else if(typeof arrayElement === "object"){
            if(!arrayElement.name){
                displayError("Missing a name attribute");
                return;
            }else if(!arrayElement.default){
                displayError("Missing a default attribute");
                return;
            }else{
            label.textContent = arrayElement.name;
            textField.value = arrayElement.default;
            results.appendChild(label);
            results.appendChild(textField);
            }
        }else{
            displayError("Fields can only contain strings");
        }
    });
}

function displayError(errorMessage) {
	var error = document.getElementById("error");
    error.innerHTML = errorMessage;
    return;
}