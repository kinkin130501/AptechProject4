"use strict";

var connectionChat = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
//document.getElementById("btn-send").disabled = true;

connectionChat.on("ReceiveMessage", function (user, message) {
    //var li = document.createElement("li");
    var username = $('.username').val();
    var today = new Date()
    var date = today.getDate();
    var min = today.getMinutes();
    var sec = today.getSeconds();
    if (sec < 10) {
        sec = '0' + sec;
    }
    if (min < 10) {
        min = '0' + min;
    }
    if (date < 10) {
        date = '0' + date;
    }
    const monthNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun",
        "Jul", "Aug", "Sept", "Oct", "Nov", "Dec"
    ];
    var month = today.toLocaleString('default', { month: 'long' }).substring(0, 3);
    var year = today.toLocaleString('default', { year: 'numeric' }).substr(2);
    var hour = Number(today.getHours());
    var time = "";
    if (Number(today.getHours()) > 12) {
        hour = Number(today.getHours()) - 12;
        time = date + "-" + month + "-" + year + " " + hour + ":" + min + ":" + sec + " PM";
    }
    else {
        time = date + "-" + month + "-" + year + " " + hour + ":" + min + ":" + sec + " AM";
    }
    if (user != username)
    {
        var html = '<div class="row"> <div class="col-md-12 pull-left div-odd"> <label class="chat-username mr-1">' + user + '</label>:<span class="mr-1">' + message + '</span><span>( ' + time+' )</span></div></div>';
        //document.getElementById("chatroom-content").append(html);
        $('.chatroom-content').append(html);
        /* li.textContent = `${user} says ${message}`;*/
    }
   
});

connectionChat.start().then(function () {
}).catch(function (err) {
    return console.error(err.toString());
});

//document.getElementById("btn-send").addEventListener("click", function (event) {
//    //var user = document.getElementById("userInput").value;
//    var user = $('.username').val();
//    var message = document.getElementById("chat-text").value;
    
//    connection.invoke("SendMessage", user, message).catch(function (err) {
//        return console.error(err.toString());
//    });
    
//    event.preventDefault();
//});