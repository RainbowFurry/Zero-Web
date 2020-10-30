//Create an Cookie with the given Name
function addCookie(cName, cValue) {
    if (getCookie("cookieconsent_dismissed") == "yes") {
        document.cookie = cName + "=" + cValue;
    } else {
        requestCookiePermission("Diese Webseite nutzt Cookies, um bestmögliche Funktionalität bieten zu können.");
    }
}

//delete an existing Cookie
function deleteCookie(cName) {
    if (getCookie(cName) != "" || getCookie(cName) != null)
        document.cookie = cName + "=; expires=Thu, 01 Jan 1970 00:00:00 UTC;";
}

//Change the Value of an set Cookie
function changeCookie(cName, cValue) {
    document.cookie = cName + "=" + cValue;
}

//Clear all existing Cookies
function clearCookie() {
    //
}

function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

function setDefaultCookies() {
    if (getCookie("MainColor") == "" || getCookie("MainColor") == null) {
        addCookie("MainColor", "#ff5e00");
        addCookie("ThemeColor", "#333333");
    }
}
setDefaultCookies();

function loadPageTheme() {
    $(':root').css('--MainColor', getCookie("MainColor"));
}
loadPageTheme();