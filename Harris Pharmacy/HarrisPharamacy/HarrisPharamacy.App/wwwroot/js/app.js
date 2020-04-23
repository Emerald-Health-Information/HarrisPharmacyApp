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
function fidoRegister(Model) {
    console.log(Model);
    let challengeBytesAsString = atob(Model.base64Challenge);
    let challenge = new Uint8Array(challengeBytesAsString.length);
    for (let i = 0; i < challengeBytesAsString.length; i++) {
        challenge[i] = challengeBytesAsString.charCodeAt(i);
    }
    // Supported algorithms, ordered by preference
    var pubKeyCredParams = [
        {
            type: "public-key",
            alg: -8
        },
        {
            type: "public-key",
            alg: -259
        },
        {
            type: "public-key",
            alg: -39
        },
        {
            type: "public-key",
            alg: -36
        },
        {
            type: "public-key",
            alg: -258
        },
        {
            type: "public-key",
            alg: -38
        },
        {
            type: "public-key",
            alg: -35
        },
        {
            type: "public-key",
            alg: -7
        },
        {
            type: "public-key",
            alg: -257
        },
        {
            type: "public-key",
            alg: -37
        },
        {
            type: "public-key",
            alg: -7
        },
        {
            type: "public-key",
            alg: -65535
        }
    ];
    // Relying party details
    let rp = {
        id: Model.relyingPartyId,
        name: "RSK FIDO Quickstart - Core"
    };

    // User handle
    let userHandleBytesAsString = atob(Model.base64UserHandle);
    let userHandle = new Uint8Array(userHandleBytesAsString.length);
    for (let i = 0; i < userHandleBytesAsString.length; i++) {
        userHandle[i] = userHandleBytesAsString.charCodeAt(i);
    }
    let user = {
        name: Model.userId,
        displayName: Model.userId,
        id: userHandle
    };
    navigator.credentials.create({ publicKey: { challenge, rp, user, pubKeyCredParams } })
        .then((credentials) => {
            // base64 encode array buffers
            let encodedCredentials = {
                id: credentials.id,
                rawId: btoa(String.fromCharCode.apply(null, new Uint8Array(credentials.rawId))),
                type: credentials.type,
                response: {
                    attestationObject:
                        btoa(String.fromCharCode.apply(null, new Uint8Array(credentials.response.attestationObject))),
                    clientDataJSON:
                        btoa(String.fromCharCode.apply(null, new Uint8Array(credentials.response.clientDataJSON)))
                }
            };
            // post to register callback endpoint and redirect to homepage
            $.ajax({
                url: 'api/home/CompleteRegistration',
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(encodedCredentials),
                success: function () {
                    window.location.href = "/";
                },
                error: function () {
                    console.error("Error from server...");
                }
            });
        })
        .catch((error) => {
            console.error(error);
        });
}