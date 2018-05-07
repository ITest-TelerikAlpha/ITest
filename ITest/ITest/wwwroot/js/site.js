// Write your JavaScript code.

var makePost = function (url, data, success, error) {
    var token = $("input[name=__RequestVerificationToken]").val() || null;

    var headers = {
        "RequestVerificationToken": token,
    };


    console.log("-".repeat(50))
    console.log(data);
    console.log(JSON.stringify(data));
    console.log(headers);
    console.log("-".repeat(50))

    $.ajax({
        url: url,
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(data),
        headers: headers,
        success: success,
        error: error
    });
};