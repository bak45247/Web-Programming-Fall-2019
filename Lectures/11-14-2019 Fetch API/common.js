var mainUrl = "https://www.google.com"

async function forcePullAsync(){
    var response = await fetch(mainUrl);

    if(!response.ok){
        document.getElementById("error") = "The response wasn't ok";
        return
    }

    var jsonResult = await response.json();

    // use the fields as normal or length if it is an array
}

async function forcePushAsync(){
    let data = {
        firstName: "Boston",
        lastName: "KJ"
    }

    let fetchData = {
        method: "Post",
        body: JSON.stringify(data),
        headers: {
            "Content-Type": "application/json"
        }
    }

    var response = await(mainUrl, fetchData);
}