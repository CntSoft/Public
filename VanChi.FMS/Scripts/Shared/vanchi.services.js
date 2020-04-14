/// <reference path="js.modaldialog.js" />
/*
    vanchi.js.services
    Thư viện gọi hàm 
*/

if (!Array.prototype.indexOf) {

    Array.prototype.indexOf = function (obj, start) {
        for (var i = (start || 0), j = this.length; i < j; i++) {
            if (this[i] === obj) { return i; }
        }
        return -1;
    }
}

if (!Array.prototype.clean) {

    Array.prototype.clean = function (deleteValue) {
        for (var i = 0; i < this.length; i++) {
            if (this[i] == deleteValue) {
                this.splice(i, 1);
                i--;
            }
        }
        return this;
    };
}

if (!Array.prototype.filter) {
    Array.prototype.filter = function (fun /*, thisArg */) {
        //"use strict";

        if (this === void 0 || this === null)
            throw new TypeError();

        var t = Object(this);
        var len = t.length >>> 0;
        if (typeof fun !== "function")
            throw new TypeError();

        var res = [];
        var thisArg = arguments.length >= 2 ? arguments[1] : void 0;
        for (var i = 0; i < len; i++) {
            if (i in t) {
                var val = t[i];

                // NOTE: Technically this should Object.defineProperty at
                //       the next index, as push can be affected by
                //       properties on Object.prototype and Array.prototype.
                //       But that method's new, and collisions should be
                //       rare, so use the more-compatible alternative.
                if (fun.call(thisArg, val, i, t))
                    res.push(val);
            }
        }

        return res;
    };
}

if (!String.prototype.splice) {
    String.prototype.splice = function (idx, rem, s) {
        return (this.slice(0, idx) + s + this.slice(idx + Math.vanchi(rem)));
    };
}

var lacviet_js_services = {

    validateNullOrEmpty: function (IdControl, IdControlError, IdContentError) {
        //IdControl:control chưa noi dung can kiem tra
        //IdControlError: control hien thi thong bao loi
        //IdContentError: nội dung thong bao hien thi

        if ($.trim($(IdControl).val()) == '') {
            $(IdControl).addClass('value-empty');
            $(IdControlError).html(IdContentError);
            return true;
        }
        else {
            $(IdControl).removeClass('value-empty');
            $(IdControlError).empty();
            return false;
        }
    }
    ,
    parseDateTime: function (jsondate) {
        /// <summary>
        /// hàm thực hiện parse thời gian trả từ services về
        /// </summary>
        /// <param name="jsondate">thời gian dạng json</param>
        if (jsondate == null)
            return null;
        var milli = jsondate.replace(/\/Date\((-?\d+)\)\//, '$1');
        var d = new Date(parseInt(milli));
        return d;
    }
    ,
    parseJsonDateWithOffset: function (jsonDate) {
        var offset = new Date().getTimezoneOffset() * 60000;
        var parts = /\/Date\((-?\d+)([+-]\d{2})?(\d{2})?.*/.exec(jsonDate);

        if (parts[2] == undefined)
            parts[2] = 0;

        if (parts[3] == undefined)
            parts[3] = 0;

        return new Date(+parts[1] + offset + parts[2] * 3600000 + parts[3] * 60000);
    }
    ,
    parseJonStringDateTime: function (jsondate) {
        /// <summary>
        /// hàm thực hiện parse thời gian trả từ services về
        /// </summary>
        /// <param name="jsondate">thời gian dạng json</param>
        if (jsondate == null)
            return null;
        var milli = jsondate.replace(/\/Date\((-?\d+)\)\//, '$1');
        var d = new Date(parseInt(milli));
        return d;
    }
    ,
    parseJsonDateToDateTimeString: function (jsondate) {
        /// <summary>
        /// hàm thực hiện parse thời gian trả từ services về chuyển thành dạng YYYY/MM/DD hh:mm:ss
        /// </summary>
        /// <param name="jsondate">thời gian dạng json</param>
        if (jsondate == null || jsondate == '')
            return '';
        var milli = jsondate.replace(/\/Date\((-?\d+)\)\//, '$1');
        var d = new Date(parseInt(milli));
        return lacviet_js_services.dateFormat(d, 'YYYY/MM/DD hh:mm:ss');
    }
    ,
    parseJsonDateToStringFormat: function (jsondate, dateFormat) {
        /// <summary>
        /// hàm thực hiện parse thời gian trả từ services về chuyển thành dạng dateFormat
        /// </summary>
        /// <param name="jsondate">thời gian dạng json</param>
        if (jsondate == null || jsondate == '')
            return '';
        var milli = jsondate.replace(/\/Date\((-?\d+)\)\//, '$1');
        var d = new Date(parseInt(milli));
        return lacviet_js_services.dateFormat(d, dateFormat);
    }
    ,
    parseToNetDateTimeString: function (date) {
        /// <summary>
        /// hàm thực hiện parse chuỗi thời gian về dạng Date(miliseconds);
        /// </summary>
        /// <param name="date">chuỗi thời gian dạng dd/mm/yyyy</param>
        if (date == null)
            return null;
        else {
            var _gmt = (new Date()) + "";
            if (_gmt.indexOf('UTC') != -1) {
                _gmt = _gmt.split('UTC')[1].split('(')[0];
            } else {
                _gmt = _gmt.split('GMT')[1].split('(')[0];
            }
            var _objDate = Date.parse(date.split('/')[1] + "/" + date.split('/')[0] + "/" + date.split('/')[2]);
            return '\/Date(' + _objDate + '' + _gmt.trim() + ')\/';
        }

        //1970-01-01 00:00:00.000
    }
    ,
    parseDateToJSONString: function (date) {
        /// <summary>
        /// hàm thực hiện parse chuỗi thời gian về dạng Date(miliseconds);
        /// </summary>
        /// <param name="date">chuỗi thời gian dạng dd/mm/yyyy</param>
        if (date == null)
            return null;
        var _objDate = Date.parse(date.split('/')[1] + "/" + date.split('/')[0] + "/" + date.split('/')[2]);
        return '\/Date(' + _objDate + ')\/';

    }
    ,
    parseToNetDateTimeObj: function (date) {
        /// <summary>
        /// hàm thực hiện parse chuỗi thời gian về dạng Date(miliseconds);
        /// </summary>
        /// <param name="date">chuỗi thời gian dạng dd/mm/yyyy</param>
        if (date == null)
            return null;
        else {
            return Date.parse(date.split('/')[1] + "/" + date.split('/')[0] + "/" + date.split('/')[2]);
        }

        //1970-01-01 00:00:00.000
    }
    ,
    //Checks if a given date string is in
    // one of the valid formats:
    // a) /M/YYYY format
    // b) D-M-YYYY format
    // c) D.M.YYYY format
    // d) D_M_YYYY format
    isValidDate: function (s) {
        if (s == null || s == undefined) {
            return false;
        }
        // make sure it is in the expected format
        if (s.search(/^\d{1,2}[\/|\-|\.|_]\d{1,2}[\/|\-|\.|_]\d{4}/g) != 0)
            return false;

        // remove other separators that are not valid with the Date class   
        s = s.replace(/[\-|\.|_]/g, "/");



        var arrDateParts = s.split("/");

        // convert it into a date instance
        var dt = new Date(Date.parse(arrDateParts[1] + "/" + arrDateParts[0] + "/" + arrDateParts[2]));
        // check the components of the date
        // since Date instance automatically rolls over each component
        return (
            dt.getMonth() == arrDateParts[1] - 1 &&
            dt.getDate() == arrDateParts[0] &&
            dt.getFullYear() == arrDateParts[2]
        );
    }
    ,
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
     
        format = format.replace("mm", (date.getMinutes() < 10 ? '0' : '') + date.getMinutes()); // Pad with '0' if needed
        format = format.replace("ss", (date.getSeconds() < 10 ? '0' : '') + date.getSeconds()); // Pad with '0' if needed
        format = format.replace("ms", date.getMilliseconds());
        return format;
    }
    ,
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
    }
    ,
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
    }
    ,
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
            timeout: 1800000,
            success: onPostSuccess,
            error: // onPostError
                   function (xmlHttpRequest) {
                       $("#biov3_loader").hide(0);
                       try {
                           $.ajax({
                               type: "POST",
                               url: "InsertSystemLogs",
                               async: true,
                               cache: false,
                               contentType: "application/json; charset=utf-8",
                               data: JSON.stringify({
                                   dtCreated: new Date(),
                                   strCreatedBy: "",
                                   strSource: "Ajax",
                                   strAction: urlMethod,
                                   strObject: dataString
                               }),
                               dataType: "json",
                               timeout: 1800000,
                               success: function () { },
                               error: function () { }
                           });
                       } catch (e) {
                           console.log(e);
                       }
                       //lacviet_js_services.showMessageBox(0,
                       //    "Không thể kết nối máy chủ.<br /> " +
                       //    '<span onclick="$(\'#dlg_error_detail\').css(\'display\', \'\')">Chi tiết kỹ thuật.</span> <br />' +
                       //    '<p id="dlg_error_detail" style="display:none">' + xmlHttpRequest.responseText + "</p>");
                   }
        });
    }
    ,
    postAsync: function (urlMethod, dataString, onPostSuccess, onPostError) {
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
            async: true,
            cache: false,
            contentType: "application/json; charset=utf-8",
            data: dataString,
            dataType: "json",
            timeout: 1800000,
            success: onPostSuccess,
            error: // onPostError
              function (xmlHttpRequest) {
                  $("#biov3_loader").hide(0);
                  try {
                      $.ajax({
                          type: "POST",
                          url: "InsertSystemLogs",
                          async: true,
                          cache: false,
                          contentType: "application/json; charset=utf-8",
                          data: JSON.stringify({
                              dtCreated: new Date(),
                              strCreatedBy: "",
                              strSource: "Ajax",
                              strAction: urlMethod,
                              strObject: dataString
                          }),
                          dataType: "json",
                          timeout: 1800000,
                          success: function () {},
                          error: function () {}
                      });
                  } catch (e) {
                      console.log(e);
                  }
                  //lacviet_js_services.showMessageBox(0,
                  //    "Không thể kết nối máy chủ.<br /> " +
                  //    '<span onclick="$(\'#dlg_error_detail\').css(\'display\', \'\')">Chi tiết kỹ thuật.</span> <br />' +
                  //    '<p id="dlg_error_detail" style="display:none">' + xmlHttpRequest.responseText + "</p>");
              }
        });
    }
    ,
    postMobileAsync: function (urlMethod, dataString, onPostSuccess, onPostError) {
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
            async: true,
            cache: false,
            contentType: "application/json; charset=utf-8",
            data: dataString,
            dataType: "json",
            success: onPostSuccess,
            error:  onPostError
        });
    }
    ,
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
    }
    ,
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
    }
    ,
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
    }
    ,
    showMessageBox: function (_type, _content) {
        if (lacviet_js_modaldialog != undefined) {
            ///
            ///_type : 0: loi, 1: thanh cong, 2: canh bao, 3: tro giup, mac dinh
            lacviet_js_modaldialog.showMessageDialog(
                'Thông báo',
                _type,
                _content,
                ["Đóng"],
                [lacviet_js_modaldialog.closeMessagebox],
                "150", "300");
        }
    }
    ,
    showAlertBox: function (_content) {
        ///
        ///_type : 0: loi, 1: thanh cong, 2: canh bao, 3: tro giup, mac dinh
        lacviet_js_modaldialog.showMessageDialog(
            'Thông báo',
            2,
            _content,
            ["Đóng"],
            [lacviet_js_modaldialog.closeMessagebox],
            "150", "300");
    }
    ,
    getParameterByName: function (_name) {
        _name = _name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
        var regex = new RegExp("[\\?&]" + _name + "=([^&#]*)"),
            results = regex.exec(location.search);
        return results == null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
    }
     ,
    getQueryStrings: function () {
        var assoc = {};
        var decode = function (s) { return decodeURIComponent(s.replace(/\+/g, " ")); };
        var queryString = location.search.substring(1);
        var keyValues = queryString.split('&');

        for (var i in keyValues) {
            var key = keyValues[i].split('=');
            if (key.length > 1) {
                assoc[decode(key[0])] = decode(key[1]);
            }
        }

        return assoc;
    }
    ,
    getWebUrl: function () {
        var webUrl = "";
        try {
            webUrl = ctx.HttpRoot;
        } catch (e) {
            webUrl = window.location.toString();
            webUrl = webUrl.substring(0, webUrl.indexOf("/_layouts", 0));
        }
        return webUrl;
    }
    ,
    getUrlVars: function () {
        var vars = [], hash;
        var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
        for (var i = 0; i < hashes.length; i++) {
            hash = hashes[i].split('=');
            vars.push(hash[0]);
            vars[hash[0]] = hash[1];
        }
        return vars;
    }

};

var Validation = {
    KeyNumber: function (e) {
        var c = String.fromCharCode(((window.event) ? event.keyCode : e.which));
        var isWordCharacter = c.match(/\d/);
        var key = e.keyCode || e.charCode;
        if (isWordCharacter == null && key != 8 && key != 46 && key != 37 && key != 39) {
            e.preventDefault();
            e.stopPropagation();
            return false;
        } else {
            return true;
        }
    }
}