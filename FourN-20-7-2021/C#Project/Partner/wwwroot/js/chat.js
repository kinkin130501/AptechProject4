"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("btn-send").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    //var li = document.createElement("li");
    var username = $('.username').val();
    if (user != username)
    {
        var html = '<div class="row"> <div class="col-md-12 pull-left div-odd"> <label class="chat-username mr-1">' + user + '</label>:<span class="mr-1">' + message + '</span></div></div>';
        //document.getElementById("chatroom-content").append(html);
        $('.chatroom-content').append(html);
        /* li.textContent = `${user} says ${message}`;*/
    }
   
});

connection.start().then(function () {
    document.getElementById("btn-send").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("btn-send").addEventListener("click", function (event) {
    //var user = document.getElementById("userInput").value;
    var user = $('.username').val();
    var message = document.getElementById("chat-text").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});