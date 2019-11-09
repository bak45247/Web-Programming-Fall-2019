function doStuff() {
    alert("This is a horrible way to do this");
}

window.onload = function() {
    // DOM
    // Document Obejct Model
    document.getElementById("doStuffButton").onclick = doStuff;
}