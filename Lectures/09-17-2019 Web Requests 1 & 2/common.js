window.onload = function() {
    document.getElementById("getButton").onclick = runGet;
    document.getElementById("postButton").onclick = runPost;
    document.getElementById("putButton").onclick = runPut;
    document.getElementById("deleteButton").onclick = runDelete;
}

/*
REST - 
1. Convention over configuration
2. Stateless - doesn't keep track of any one client

CRUD - Create, Read, Update, Delete

Http Verbs/Methods
GET - Read Data from the server
POST - Send data to the server
PUT - replace data on the server, or create if not already there
PATCH - Update (merge) data on the server
DELETE - deletes data from the server

How we talk to the server
1. URL - Where we want to go; which entity to we want to CRUD
2. The body of the request, the payload, request data - anything a user typed into a form
3. Headers - Metadata of the request; not editable by the user - edited in code

How the server talks to us
1. StatusCode - an integer indicating how the reqeust went
2. Body - the data requested or created
3. Headers - Metadata of the response, edited by code, contentType, contentlength, etc

Status Codes - More specific is better (example: 200 is 'less specific' than 202)
100 - HTTP continuation, big requests (won't use these)
200 - Ok
    201 - Created (Useful for when we create data (POST or PUT))
    202 - Accepted (The server has taken your request and is now going to process it in the background)
    204 - No Content (The server didnt send a body (usually used in DELETE requests))   
300 - Redirects
    301 - Moved Permanently (the client will cache this for a long time)
    307 - Temporary Redirect (revisit the original site whenever you need a URL)
400 - Bad Request (your fault)
    401 - Unauthorized (Credentials were not accepted)
    403 - Forbidden (Credentials were accepted, but you dont have access to that area)
    404 - Not Found (Page doesn't exist on the server)
500 - Internal Server Error (our fault)
    503 - Service Unavailable (Server is overloaded with requests; usually temporary, try again in a little bit)

Headers
    Content Type - The MIME type of the request or response
    Content Length - The size in bytes of the request or response
    Authorization - Sending your credentials to the server; ONLY a request header
    Location - Used with 300 level response; URL of where to go next
*/

var mainUrl = "https://simpleserverbethel.azurewebsites.net/api/values"

function runGet() {
    $.ajax(mainUrl,
        {
            method: "GET",
            success: simpleSuccess,
            error: simpleError
        });
}

function runDelete() {
    $.ajax(mainUrl + "/" + document.getElementById("userIndex").value,
        {
            method: "DELETE",
            success: simpleSuccess,
            error: simpleError
        });
}

function runPost() {
    $.ajax(mainUrl,
        {
            method: "POST",
            success: simpleSuccess,
            error: simpleError,
            processData: false,
            contentType: "application/json",
            data: JSON.stringify({
                Value: document.getElementById("userValue").value
            })
        });
}

function runPut() {
    $.ajax(mainUrl + "/" + document.getElementById("userIndex").value,
        {
            method: "PUT",
            success: simpleSuccess,
            error: simpleError,
            processData: false,
            contentType: "application/json",
            data: JSON.stringify({
                Value: document.getElementById("userValue").value
            })
        });
}

function simpleSuccess(data){
    document.getElementById("results").innerHTML = JSON.stringify(data);
}

function simpleError(data){
    document.getElementById("error").innerHTML = JSON.stringify(data);
}