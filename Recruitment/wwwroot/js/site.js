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