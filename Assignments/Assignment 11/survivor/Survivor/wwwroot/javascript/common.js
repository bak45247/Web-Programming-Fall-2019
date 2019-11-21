var mainUrl = "api/images";
var apiVersion = document.getElementById(apiVersion).value

function startUpload() {
    var name = document.getElementById("name").value;

    if (!name || name.length < 3) {
        showError("Enter at least three characters for the title.");
        return;
    }

    var file = document.getElementById('fileInput').files[0];
    if (!file) {
        showError("Choose a file.");
        return;
    }

    if (apiVersion == 1.0) {
        $.ajax(mainUrl + "?api-version=" + apiVersion,
            {
                method: "POST",
                success: startUploadSuccess,
                error: showError,
                contentType: "application/json",
                processData: false,
                data: JSON.stringify({
                    Name: name,
                    File: file
                })
            });
    } else {
        $.ajax(mainUrl + "?api-version=" + apiVersion,
        {
            method: "POST",
            success: startUploadSuccess,
            error: showError,
            contentType: "application/json",
            processData: false,
            data: JSON.stringify({
                Name: name,
                File: file,
                Description: document.getElementById("description").value
            })
        });
    }
}

var speedSummary;

function showError(error) {
    document.getElementById("error").style.display = "block";
    document.getElementById("error").innerHTML = error;
    setTimeout(function () {
        document.getElementById("error").style.display = "none";
    }, 3000);
}

function startUploadSuccess(data) {
    var file = document.getElementById('fileInput').files[0];
   
    var blobService = AzureStorage.Blob.createBlobServiceWithSas(data.blobUrl, data.uploadSasToken);
    var customBlockSize = file.size > 1024 * 1024 * 32 ? 1024 * 1024 * 4 : 1024 * 512;
    blobService.singleBlobPutThresholdInBytes = customBlockSize;

    speedSummary = blobService.createBlockBlobFromBrowserFile(data.userName, data.id, file, { blockSize: customBlockSize }, function (error, result, response) {
        if (!error) {
            uploadComplete(data.id);
        }
    });
}

function uploadComplete(id) {
    $.ajax(mainUrl + "/" + id + "/uploadComplete" + "?api-version=" + apiVersion,
    {
        method: "POST",
        success: refreshImages,
        error: showError
    });
}

function refreshImages() {
    $.ajax(mainUrl, {
        method: "GET",
        success: refreshImagesResult
    });
}

function purge() {
    $.ajax(mainUrl, {
        method: "Delete",
        success: purgeResult
    });
}

function purgeResult() {
    document.getElementById("images").innerHTML = "";
}

function refreshImagesResult(data) {
    var imagesDiv = document.getElementById("images");
    imagesDiv.innerHTML = '';

    // data is an array of ImageEntity
    data.forEach(addImage);
}

function addImage(image) {
    var imagesDiv = document.getElementById("images");

    var img = document.createElement("img");
    img.classList.add("photoList");
    img.alt = image.name;
    img.title = image.name;
    img.src = "https://localhost:44361/" + mainUrl + "/" + image.id;
    

    imagesDiv.appendChild(img);
}

window.onload = function () {
    document.getElementById("startUpload").onclick = startUpload;
    document.getElementById("refreshImages").onclick = refreshImages;
    document.getElementById("purge").onclick = purge;

    refreshImages();
};
