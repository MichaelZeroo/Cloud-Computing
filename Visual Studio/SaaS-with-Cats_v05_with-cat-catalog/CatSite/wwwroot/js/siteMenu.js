// Load menu
setupMenu();

function setupMenu() {
    var xmenu;
    var oe = document.getElementById("menu");

    xmenu = new XMLHttpRequest();
    xmenu.open("GET", "SharedMenu.html", false);
    xmenu.send();
    oe.innerHTML = xmenu.responseText;
    checkIfLoggedIn();
}

//if logged in then make Catalog and Editing visible
function checkIfLoggedIn() {
    if (getCookie("catbabysittinguser") != "") {
        document.getElementById("menuCatalog").style.display = "inline";
        document.getElementById("menuCatDetail").style.display = "inline";
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
