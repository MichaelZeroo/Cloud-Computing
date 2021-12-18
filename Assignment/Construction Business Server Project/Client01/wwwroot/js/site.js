// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
setupMenu();

function setupMenu() {
    var xmenu;
    var oe = document.getElementById("menu");

    xmenu = new XMLHttpRequest();
    xmenu.open("GET", "SharedMenu.html", false);
    xmenu.send();
    oe.innerHTML = xmenu.responseText;
}

//if logged in then make Catalog and Editing visible
function checkIfLoggedIn() {
    if (getCookie("username") != "") {
        document.getElementById("inventoryService").style.display = "inline";
        document.getElementById("orderService").style.display = "inline";
    }
}

//Ref: https://www.w3schools.com/js/js_cookies.asp
function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
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