"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

// Disable the send button until connection is established.
//document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (data) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);

    // Display the received message with sender's name, userID, picurl, message, and timestamp.
    li.textContent = `${data.senderName} (${data.userID}) says: ${data.message} (${data.timeStamp})`;
});

// Ensure the connection is started before attempting to send the connection ID
startConnection();

document.getElementById("sendButton").addEventListener("click", function (event) {
    var userID = document.getElementById("userIDInput").value;
    var message = document.getElementById("messageInput").value;

    // Send the message along with recipient's userID.
    connection.invoke("SendMessage", userID, message).catch(function (err) {
        return console.error(err.toString());
    });

    event.preventDefault();
});

function startConnection() {
    connection.start()
        .then(function () {
            // Get the connection ID after the connection is established
            connection.invoke("GetConnectionId")
                .then(function (connectionId) {
                    // Send the connection ID to the HomeController
                    sendConnectionIdToHomeController(connectionId);

                    // Enable the send button
                    document.getElementById("sendButton").disabled = false;
                })
                .catch(function (err) {
                    console.error(err.toString());
                });
        })
        .catch(function (err) {
            console.error(err.toString());
            // Retry or handle the error as needed
        });
}

function sendConnectionIdToHomeController(connectionId) {
    // Use AJAX to send the connection ID to the HomeController without expecting a response
    $.post("/Home/SendConnectionId", { connectionId: connectionId })
        .done(function () {
            console.log("Connection ID sent");
        })
        .fail(function () {
            console.error("Connection ID Error");
        });
}

