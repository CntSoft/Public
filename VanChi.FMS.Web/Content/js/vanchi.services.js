var vanchi_services = {

    dateFormat: function (date, format) {
        /// <summary>
        /// hàm thực hiện chuyển ngày tháng thành dạng chuỗi theo format
        /// DD: ngày 01 -> 31
        /// MM: tháng 01 -> 12
        /// YYYY: năm 1900 -> ....
        /// hh: giờ 00 -> 23
        /// mm: phút 00 -> 59
        /// ss: giây 00 -> 59
        /// ms: mili giây 0 -> 100
        /// </summary>
        /// <param name="date">thời gian</param>
        /// <param name="format">các dạng format</param>
        if (date == null)
            return "";
        format = format.replace("DD", (date.getDate() < 10 ? '0' : '') + date.getDate()); // Pad with '0' if needed
        format = format.replace("MM", (date.getMonth() < 9 ? '0' : '') + (date.getMonth() + 1)); // Months are zero-based
        format = format.replace("YYYY", date.getFullYear());
        format = format.replace("hh", (date.getHours() < 10 ? '0' : '') + date.getHours()); // Pad with '0' if needed
        format = format.replace("ms", date.getMilliseconds());
        format = format.replace("mm", (date.getMinutes() < 10 ? '0' : '') + date.getMinutes()); // Pad with '0' if needed
        format = format.replace("ss", (date.getSeconds() < 10 ? '0' : '') + date.getSeconds()); // Pad with '0' if needed

        return format;
    },

    addDays: function (days) {
        var date = new Date();
        date.setDate(date.getDate() + days);
        return date;
    },

    getNewGuid: function () {
        var S4 = function () {
            return Math.floor(
                    Math.random() * 0x10000 /* 65536 */
                ).toString(16);
        };

        return (
                S4() + S4() + "-" +
                S4() + "-" +
                S4() + "-" +
                S4() + "-" +
                S4() + S4() + S4()
            );
    },

    get: function (urlMethod, dataString, onGetSuccess, onGetError) {
        /// <summary>
        /// hàm gọi service theo phương thức get
        /// </summary>
        /// <param name="urlMethod"> địa chỉ service +  tên phương thức gọi </param>
        /// <param name="dataString"> dữ liệu đối số theo kiểu json </param>
        /// <param name="onGetSuccess"> hàm call back khi gọi thành công</param>
        /// <param name="onGetError"> hàm call back khi thất bại </param>
        $.ajax({
            type: "GET",
            url: urlMethod,
            cache: false,
            contentType: "application/json; charset=utf-8",
            data: dataString,
            dataType: "json",
            success: onGetSuccess,
            error: onGetError
        });
    },

    post: function (urlMethod, dataString, onPostSuccess, onPostError) {
        /// <summary>
        /// hàm gọi service theo phương thức post
        /// </summary>
        /// <param name="urlMethod"> địa chỉ service +  tên phương thức gọi </param>
        /// <param name="dataString"> dữ liệu đối số theo kiểu json </param>
        /// <param name="onGetSuccess"> hàm call back khi gọi thành công</param>
        /// <param name="onGetError"> hàm call back khi thất bại </param>

        $.ajax({
            type: "POST",
            url: urlMethod,
            async: false,
            cache: false,
            contentType: "application/json; charset=utf-8",
            data: dataString,
            dataType: "json",
            success: onPostSuccess,
            error: onPostError
        });
    },

    postAsync: function (urlMethod, dataString, onPostSuccess, onPostError) {
        /// <summary>
        /// hàm gọi service theo phương thức post
        /// </summary>
        /// <param name="urlMethod"> địa chỉ service +  tên phương thức gọi </param>
        /// <param name="dataString"> dữ liệu đối số theo kiểu json </param>
        /// <param name="onGetSuccess"> hàm call back khi gọi thành công</param>
        /// <param name="onGetError"> hàm call back khi thất bại </param>

        $.ajax({
            type: "POST",
            url: urlMethod,
            async: true,
            cache: false,
            contentType: "application/json; charset=utf-8",
            data: dataString,
            dataType: "json",
            success: onPostSuccess,
            error: onPostError
        });
    },

    postXML: function (urlMethod, dataString, onPostSuccess, onPostError) {
        /// <summary>
        /// hàm gọi service theo phương thức get
        /// </summary>
        /// <param name="urlMethod"> địa chỉ service +  tên phương thức gọi </param>
        /// <param name="dataString"> dữ liệu đối số theo kiểu json </param>
        /// <param name="onGetSuccess"> hàm call back khi gọi thành công</param>
        /// <param name="onGetError"> hàm call back khi thất bại </param>
        $.ajax({
            type: "POST",
            url: urlMethod,
            cache: false,
            contentType: "application/json; charset=utf-8",
            data: dataString,
            dataType: "xml",
            success: onPostSuccess,
            error: onPostError
        });
    },

    postSoap: function (urlMethod, dataString, onPostSuccess, onPostError) {
        /// <summary>
        /// hàm gọi service theo phương thức get theo kieusoap
        /// </summary>
        /// <param name="urlMethod"> địa chỉ service +  tên phương thức gọi </param>
        /// <param name="dataString"> dữ liệu đối số theo kiểu json </param>
        /// <param name="onGetSuccess"> hàm call back khi gọi thành công</param>
        /// <param name="onGetError"> hàm call back khi thất bại </param>
        $.ajax({
            type: "POST",
            url: urlMethod,
            cache: false,
            contentType: "text/xml",
            data: dataString,
            dataType: "xml",
            success: onPostSuccess,
            error: onPostError
        });
    },

    stringify: function stringify(obj) {
        if ("JSON" in window) {
            return JSON.stringify(obj);
        }

        var t = typeof (obj);
        if (t != "object" || obj === null) {
            // simple data type
            if (t == "string") obj = '"' + obj + '"';

            return String(obj);
        } else {
            // recurse array or object
            var n, v, json = [], arr = (obj && obj.constructor == Array);

            for (n in obj) {
                v = obj[n];
                t = typeof (v);
                if (obj.hasOwnProperty(n)) {
                    if (t == "string") {
                        v = '"' + v + '"';
                    } else if (t == "object" && v !== null) {
                        v = jQuery.stringify(v);
                    }

                    json.push((arr ? "" : '"' + n + '":') + String(v));
                }
            }

            return (arr ? "[" : "{") + String(json) + (arr ? "]" : "}");
        }
    },

    replaceCurrentURL: function (queryString, valueOld, valueNew) {
        /// <summary>
        /// hàm thay thế URL
        /// </summary>
        /// <param name="queryString"> tham số </param>
        /// <param name="valueOld"> giá trị cũ </param>
        /// <param name="valueNew"> giá trị mới </param>
        var url = window.location.href;
        var urlNew = '';
        if (url.indexOf("?") != -1) {
            urlNew = (url.indexOf(queryString.toLowerCase()) != -1) ? url.replace(queryString + valueOld, queryString + valueNew) : url + '&' + queryString.toLowerCase() + valueNew;
        }
        else {
            urlNew = url + '?' + queryString.toLowerCase() + valueNew;
        }
        history.pushState('', '', urlNew);
    },

    refreshButton: function (classCheckbox, strButtonId) {
        /// <summary>
        /// hàm ẩn hiện button
        /// </summary>
        /// <param name="classCheckbox"> class của checkbox (chọn tất cả) </param>
        /// <param name="strButtonId"> chuỗi Id của button ("#btnNew,#btnEdit") </param>
        ($('input:checkbox[name="' + classCheckbox.replace('.', '') + '"]:checked').length > 0) ? $(strButtonId).fadeIn() : $(strButtonId).fadeOut();
    },

    checkAll: function (idCheckbox, classCheckbox, strButtonId) {
        /// <summary>
        /// hàm check tất cả checkbox của table
        /// </summary>
        /// <param name="idCheckbox"> id của checkbox (chọn tất cả) </param>
        /// <param name="classCheckbox"> class của các checkbox con </param>
        /// <param name="strButtonId"> chuỗi Id của button ("#btn-rm-edit,#btn-rm-delete") </param>
        ($(idCheckbox).is(":checked")) ? ($(classCheckbox).each(function () { this.checked = true; })) : ($(classCheckbox).each(function () { this.checked = false; }));

        vanchi_services.refreshButton(classCheckbox, strButtonId);
    },

    loadPopup: function (idPopup, isReload) {
        /// <summary>
        /// hàm load Modal/Popup/Dialog
        /// </summary>
        /// <param name="idPopup"> id của Popup </param>
        /// <param name="isReload"> Có reload page ? </param>
        $('body').on('click', '.' + idPopup, function (e) {
            e.preventDefault();
            $(this).attr('data-target', '#' + idPopup);
            $(this).attr('data-toggle', 'modal');
        });
        $('body').on('click', '.modal-close-btn', function () {
            if (isReload == undefined || isReload == true) {
                location.reload();
            }
        });
        $('#' + idPopup).on('hidden.bs.modal', function () {
            if (isReload == undefined || isReload == true) {
                location.reload();
            }
        });
    },

    loadPopupDynamic: function (idControl, idPopup, url) {
        /// <summary>
        /// hàm load Modal/Popup/Dialog động
        /// </summary>
        /// <param name="idControl"> id của Button </param>
        /// <param name="idPopup"> id của Popup </param>
        /// <param name="url"> url </param>
        $('#' + idControl).attr("href", url);
        $('#' + idControl).attr('data-target', '#' + idPopup);
        $('#' + idControl).attr('data-toggle', 'modal');
    },

    getParamValue: function (paramName) {
        /// <summary>
        /// lấy giá trị URL theo paramName
        /// </summary>
        /// <param name="paramName"> tham số </param>
        var pageIndex = 1;
        var param = window.location.search;
        if (param != undefined && param.indexOf(paramName) != -1) {
            pageIndex = parseInt(param.split(paramName)[1]);
        }
        return pageIndex;
    },

    getIdChecked: function (classCheckbox, attr) {
        /// <summary>
        /// hàm ẩn lấy Id checked
        /// </summary>
        /// <param name="classCheckbox"> class của checkbox (chọn tất cả) </param>
        /// <param name="attr"> attr chứa Id </param>
        var lstId = [];
        $('input:checkbox[name="' + classCheckbox.replace('.', '') + '"]:checked').each(function (i, item) {
            lstId[i] = $(this).parent().parent().parent().attr(attr);
        });
        return lstId;
    },

    refreshRegisterTotal: function (url) {

        vanchi_services.postAsync(url, JSON.stringify(),
            function (result) {
                $('#lbl-hp-totalregister').html(result.total);
                $('#lbl-hp-totalregister').parent().addClass('add-basket');
                setTimeout(function () {
                    $('#lbl-hp-totalregister').parent().removeClass('add-basket');
                }, 2000); //waiting 2 seconds
            },
            function (xmlHttpRequest) {
            }
        );
    },

    postAutocomplete: function (idInput, urlMethod, dataString, onPostSuccess, onPostError, onPostSelect) {
        $(idInput).autocomplete({
            source: function (request, response) {
                vanchi_services.postAsync(urlMethod, dataString, onPostSuccess, onPostError);
            },
            change: function (event, ui) {
                if (ui.item == null || ui.item == undefined) {
                    $(this).val("");
                }
            },
            minLength: 2,
            select: onPostSelect,
            open: function () {
                $(this).removeClass("ui-corner-all").addClass("ui-corner-top");
            },
            close: function () {
                $(this).removeClass("ui-corner-top").addClass("ui-corner-all");
            }
        });
    },

    deletePickUser: function (element) {
        var id = $(element).attr("elementId");
        var userName = $(element).attr("userName");
        // delete User
        if ($("#" + id).val().indexOf(";" + userName) > -1)
            $("#" + id).val($("#" + id).val().replace(";" + userName, ""));
        if ($("#" + id).val().indexOf(userName + ";") > -1)
            $("#" + id).val($("#" + id).val().replace(userName + ";", ""));
        else if ($("#" + id).val() == userName)
            $("#" + id).val($("#" + id).val().replace(userName, ""));
        $(element).closest("li").remove();
    },

    checkPickUser: function (element, urlUserInfoGetByUserName, type) {
        var id = $(element).attr("elementId");
        var textUsers = $("#userInput" + id);
        $.getJSON(urlUserInfoGetByUserName, { userNames: textUsers.val() }, function (data) {
            var items = "";
            $.each(data, function (i, user) {
                if ($("#" + id).val().indexOf(user.Value) <= -1 && $("#" + id).val() != user.Value && (type != "single" || (type == "single" && $("#" + id).val() == ''))) {
                    items += "<li class='search-choice'><span>" + user.Text + "</span><a class='search-choice-close' onclick='vanchi_services.deletePickUser(this)' elementId='" + id + "' userName='" + user.Value + "'></a></li>";
                    if ($("#" + id).val() == "")
                        $("#" + id).val(user.Value);
                    else
                        $("#" + id).val($("#" + id).val() + ";" + user.Value);
                }
            });
            $("#userSelect" + id).prepend(items);
            $("#userInput" + id).val("");
        });
    },

};

MenuLeftProgress = function () {

    var pathname = window.location.pathname.replace('/vi-vn', '').replace('/en-us', '').replace('/fr-fr', '').replace('/ja-jp', '').replace('/zh-cn', '').replace('/ru-ru', '');
    if (pathname != undefined && pathname != "" && pathname != "/") {
        var strPathname = pathname.split('/');
        var controller = strPathname[1];
        var action = strPathname[2];
        if (controller != undefined && controller != "" && action != undefined && action != "") {
            //Chọn node cha của URL
            $('#nav-' + controller).addClass('active open');
            $('#nav-' + controller).find('a').append('<span class="selected"></span>');
            //Đổi icon đóng mở
            $('#nav-span-' + controller).addClass('open');
            //Chọn node theo URL 
            $('#nav-' + controller + "-" + action).addClass('active open');
            //Mở node cha của URL
            $('#nav-' + controller + "-" + action).parent().parent().addClass('active open');
            //Đổi icon đóng mở node cha của URL
            $('#nav-' + controller + "-" + action).parent().parent().find('a').children('.arrow').addClass('open');
        }
    }
    else {
        $('#nav-home').find('a').append('<span class="selected"></span>');
        $('#nav-home').addClass('active open');
    }
};

String.format = function () {
    var s = arguments[0];
    for (var i = 0; i < arguments.length - 1; i++) {
        var reg = new RegExp("\\{" + i + "\\}", "gm");
        s = s.replace(reg, arguments[i + 1]);
    }
    return s;
};

ShowLoading = function () {
    $('#element-loading').fadeIn();
};

HideLoading = function () {
    setTimeout(function () {
        $('#element-loading').fadeOut();
    }, 200); //waiting 0.2 seconds
};

ShowProgressBar = function () {
    $('#element-progress').css('display', 'block');
    $('#element-progress-click').click();
}

HideProgressBar = function () {
    $('#element-progress').css('display', 'none');
}

ChangeLanguage = function (langOld, langNew) {
    var langCodeOld = '/' + langOld;
    var langCodeNew = '/' + langNew;
    if (window.location.href.indexOf(langCodeOld) != -1) {
        window.location.href = window.location.href.replace(langCodeOld, langCodeNew);
    }
    else {
        window.location.href = window.location.protocol + '//' + window.location.host + '/' + langNew + window.location.pathname + window.location.search;
    }
};

if (App.isAngularJsApp() === false) {
    jQuery(document).ready(function () {
        MenuLeftProgress();
    });
}