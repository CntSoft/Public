

function getDataRestAPI(url, data, callBackFunction) {
    if (data != undefined && data != null) {
        $.ajax({
            url: url,
            type: "POST",
            headers: {
                "accept": "application/json;odata=verbose",
                "content-type": "application/json;odata=verbose",
                "X-RequestDigest": $("#__REQUESTDIGEST").val()
            },
            data: JSON.stringify(data),
            success: function (returnData) {
                if (typeof (callBackFunction) == 'function') {
                    callBackFunction(returnData, url, data);
                }
            },
            error: function (err) {
                alert(JSON.parse(err.responseText).Message);
                console.log(err);
                if (typeof (callBackFunction) == 'function') {
                    callBackFunction(null, url, data);

                }

            }
        });
    }
    else {
        $.ajax({
            url: url,
            type: "get",
            headers: {
                "accept": "application/json;odata=verbose",
            },
            success: function (returnData) {
                if (typeof (callBackFunction) == 'function') {
                    callBackFunction(returnData, url);
                }
            },
            error: function (err) {
                alert(JSON.parse(err.responseText).Message);
                console.log(err);
                if (typeof (callBackFunction) == 'function') {
                    callBackFunction(null, url, data);

                }

            }
        });
    }
}
function insertDataRestAPI(url, item, callBackFunction) {
    $.ajax({
        url: url,
        type: "POST",
        contentType: "application/json;odata=verbose",
        data: JSON.stringify(item),
        headers: {
            "accept": "application/json;odata=verbose",
            "X-RequestDigest": $("#__REQUESTDIGEST").val()
        },
        success: function (returnData, request) {
            if (typeof (callBackFunction) == 'function') {
                callBackFunction(returnData, url, item);

            }
        },
        error: function (err) {
            alert(JSON.parse(err.responseText).Message);
            console.log(err);
            if (typeof (callBackFunction) == 'function') {
                callBackFunction(null, url, data);

            }

        }
    });
}
function updateDataRestAPI(url, item, callBackFunction) {

    $.ajax({
        url: url,
        type: "POST",
        contentType: "application/json;odata=verbose",
        data: JSON.stringify(item),
        headers: {
            "accept": "application/json;odata=verbose",
            "X-RequestDigest": $("#__REQUESTDIGEST").val(),
            "IF-MATCH": "*",
            "X-Http-Method": "PATCH"
        },
        success: function (returnData, request) {
            if (typeof (callBackFunction) == 'function') {
                callBackFunction(returnData, url, item);

            }
        },
        error: function (err) {
            alert(JSON.parse(err.responseText).Message);
            console.log(err);
            if (typeof (callBackFunction) == 'function') {
                callBackFunction(null, url);

            }

        }
    });
}
function deleteDataRestAPI(url, callBackFunction) {
    $.ajax({
        url: url,
        type: "DELETE",
        headers: {
            "accept": "application/json;odata=verbose",
            "X-RequestDigest": $("#__REQUESTDIGEST").val(),
            "IF-MATCH": "*"
        },
        success: function (returnData) {
            if (typeof (callBackFunction) == 'function') {
                callBackFunction(returnData);

            }
        },
        error: function (err) {
            alert(JSON.parse(err.responseText).Message);
            console.log(err);
            if (typeof (callBackFunction) == 'function') {
                callBackFunction(null, url);

            }

        }
    });
}
function requestData(url, data, callBackFunction) {
    $.ajax({
        type: "POST",
        url: url,
        async: true,
        cache: false,
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(data),
        dataType: "json",
        success: function (returnData, request) {
            if (typeof (callBackFunction) == 'function') {
                callBackFunction(returnData, url, data);

            }
        },
        error: function (err) {
            alert(JSON.parse(err.responseText).Message);
            console.log(err);
            if (typeof (callBackFunction) == 'function') {
                callBackFunction(null, url, data);

            }

        }
    });

}
function isNullOrEmpty(value) {
    if (value == undefined || value == null || value == '' || value.toString().trim() == '') {
        return true;

    }
    return false;
}
function AllowOnlyNumber(e) {
    var charCode = (e.which) ? e.which : e.keyCode;
    if (charCode != 45 && charCode != 46 && charCode > 31
      && (charCode < 48 || charCode > 57))
        return false;

    return true;
}
function OnFocusNumber(element) {
    var value = $(element).val();
    if (value != '') {
        value = value.replace(/\,/g, "");
        $(element).val(value);
    }
}
function OnBlurNumber(element) {
    var value = $(element).val();
    if (value != '') {
        value = parseInt(value.replace(/\,/g, ""));
        $(element).val(value.toLocaleString('en-us').split('.')[0]);
    }
    if (value == '') {
        $(element).val(0);
    }
}
function onError(err) {
    alert(JSON.parse(err.responseText).Message);
    console.log(err);
}
function showMessage(control, message) {
    $(control).notify(message, { position: "bottom", className: "error" });
}

function randomText() {
    return Math.floor((1 + Math.random()) * 0x10000).toString(16).substring(1);
}
function newGuid() {

    return randomText() + randomText() + '-' + randomText() + '-' + randomText() + '-' +
      randomText() + '-' + randomText() + randomText() + randomText();

}
