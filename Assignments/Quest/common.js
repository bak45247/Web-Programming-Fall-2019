function doPost(){
  debugger;

  $.ajax("https://webprogrammingthequest.azurewebsites.net/theTunnel",
    {
        method: "GET",
        async: false,
        success: simpleSuccess,
        headers: {
          name: "Boston"
        }
    });

  // var settings = {
  //     "async": true,
  //     "crossDomain": true,
  //     "url": "https://webprogrammingthequest.azurewebsites.net/theTunnel",
  //     "method": "GET",
  //     "headers": {
  //       "name": "Boston",
  //       "cache-control": "no-cache",
  //       "postman-token": "da7c49f6-7b66-7893-ab21-c6a1f7e2c81e"
  //     }
  //   }

  //   debugger;
    
  //   $.ajax(settings).done(function (response) {
  //     console.log(response);
  //   });
}

function simpleSuccess(data) {
  console.log(data);
}

window.onload = function() {
  document.getElementById("post").onclick = doPost;
}