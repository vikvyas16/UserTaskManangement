var commonUtility = {}

commonUtility.baseUrl = "http://localhost:63349/api/";

commonUtility.test = function () {
    
}

commonUtility.ajaxGetCall = function (uri, callback) {

    $.ajax({
        type: "GET",
        url: uri,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: {
            "Access-Control-Allow-Origin": "http://localhost:63281",
            "Access-Control-Allow-Methods": "DELETE, POST, GET, OPTIONS"
        },
        crossDomain: true,
        success: callback,
        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function

    });

}
commonUtility.ajaxPostCall = function (uri, data, callback) {

    $.ajax({
        type: "POST",
        url: uri,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        headers: {
            "Access-Control-Allow-Origin": "http://localhost:63281/",
            "Access-Control-Allow-Methods": "DELETE, POST, GET, OPTIONS"
        },
        crossDomain: true,
        success: callback,
        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function

    });

}