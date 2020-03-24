/*

Harrison1 COSC 470 2019

File = app.js

Author = Taylor Adam

Date = 2019-11-19

License = MIT

				Modification History

Version		Author			Date				Desc
v 1.0		Taylor Adam		2019-11-19			Added Headers
v 1.1		Taylor Adam		2019-11-19			Added Js for sliding nav menu
v 1.2       Nelson Murray   2019-11-30          Added toggle nav function

*/
function webChat(c) {
    console.log("in " + c);
    window.WebChat.renderWebChat(
        {
            directLine: window.WebChat.createDirectLine({
                token: c
            }),
            userID: 'YOUR_USER_ID',
            username: 'Web Chat User',
            locale: 'en-US',
            botAvatarInitials: 'WC',
            userAvatarInitials: 'WW'
        },
        document.getElementById('webchat')
    );
}

/* Set the width of the side navigation to 250px and the left margin of the page content to 250px and add a black background color to body */
function openNav() {
    document.getElementById("mySidenav").style.width = "350px";
    document.getElementById("main").style.marginLeft = "350px";
}

/* Set the width of the side navigation to 0 and the left margin of the page content to 0, and the background color of body to white */
function closeNav() {
    document.getElementById("mySidenav").style.width = "0";
    document.getElementById("main").style.marginLeft = "0";
}

function toggleNav() {
    var widthItem = document.getElementById("mySidenav");

    if (widthItem.style.width === "350px") {
        closeNav();
    } else {
        openNav();
    }
}