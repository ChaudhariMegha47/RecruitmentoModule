// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function ResolveUrl(url) {
    if (url.indexOf("/") == 0) {
        url = url.split(baseUrl.substring(0, (baseUrl.length - 1))).join('');
        url = baseUrl + url.substring(1);
    }
    return url;
}


function ValidateControl(obj) {
    var objval = $(obj).val();
    if (objval != null && objval != undefined && objval != '' && regexGlobalValidation.test(objval)) {

        var objclass = $(obj).attr('class');
        if (objclass != null && objclass != undefined && objclass != '') {
            if (objclass.includes('validname')) {
                if (regexName.test(objval)) {
                    return true;
                }
                else {
                    return false;
                }
            }
            if (objclass.includes('validemail')) {
                if (regexEmail.test(objval)) {
                    return true;
                }
                else {
                    return false;
                }
            }
            if (objclass.includes('phone')) {
                if (regexMobileNo.test(objval)) {
                    return true;
                }
                else {
                    return false;
                }
            }
            if (objclass.includes('validpassword')) {
                if (regexPassword.test(objval)) {
                    return true;
                }
                else {
                    return false;
                }
            }
            if (objclass.includes('validpincode')) {
                if (regexPincode.test(objval)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        return true;
    } else {
        return false;
    }
}

