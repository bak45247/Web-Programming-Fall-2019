 var mainUrl = "api/marioLevels";
var moves = ["walk", "jump", "run", "wait"]; // 5, 5, 10, 0
var choice = 0;
var left = 0;

window.onload = function(){
    this.document.getElementById("start").onclick = startLevel;
}

function startLevel(){
    left = 0;
    document.getElementById("mario").style.left = "0%";
    document.getElementById("start").value = "Restart";
    document.getElementById("start").style.visibility = "hidden";
    runGet();
}

function restartLevel(){
    location.reload();
}

function runGet(){
    choice = Math.floor((Math.random() * 3));
    $.ajax(mainUrl + "/" + moves[choice],
        {
            method: "GET",
            success: simpleResult,
            error: simpleError
        });
}

 function simpleResult(data) {
     if(left < 100){
        if(choice == 0 || choice == 1){
            left += 5;
            document.getElementById("mario").style.left = left + "%";
        }else if(choice == 2){
            left += 10;
            document.getElementById("mario").style.left = left + "%";
        }

        document.getElementById("success").innerHTML = JSON.stringify(data.message);
        runGet();
     }else{
         document.getElementById("success").innerHTML = "Mario passed the level!";
         document.getElementById("start").style.visibility = "visible";
         document.getElementById("start").onclick = restartLevel;
     }    
}

function simpleError(data) {
    document.getElementById("success").innerHTML = "";

	if(data.status == 500){
        document.getElementById("error").innerHTML = "Mario Died.";
    }else{
        document.getElementById("error").innerHTML = data;
    }
}