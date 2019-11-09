function changeColors() {
    // toggle split rev class
    document.getElementById("background").classList.toggle("splitRev");
}

window.onload = function() {
    document.getElementById("colors").onclick = changeColors;
}