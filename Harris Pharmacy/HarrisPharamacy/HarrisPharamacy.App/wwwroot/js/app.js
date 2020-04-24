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

var LastElementDOM;
var LastValueDOM;

function mutateDOM(ElementDOM, value) {
    if (LastElementDOM == ElementDOM && LastValueDOM == value)
        return false;

    LastElementDOM = ElementDOM;
    LastValueDOM = value;

    var event = new Event('change');
    ElementDOM.dispatchEvent(event);
}

function selectChange(_this) {
    mutateDOM(_this, _this.value);
    return "Done";
}

function getStartDate() {
    return $('#datetimepicker1').datetimepicker('viewDate');
}
function getEndDate() {
    return $('#datetimepicker2').datetimepicker('viewDate');
}

function setMinDate() {
    $('#datetimepicker1').datetimepicker({
        minDate: new Date()
    });
}
function isFormValid(formRef) {
    return formRef.checkValidity();
}
/*function setEndDate() {
    var d = $('#datetimepicker1').datetimepicker.('viewDate');

    $('#datetimepicker2').datetimepicker({
        minDate: d
    });
}*/

/*function initializeValidator() {
    $(document).ready(function () {
        $("#selectedForm").validate();
    });
}

function isFormValid() {
    var form = $('#selectedForm');
    return form.valid();
}*/



