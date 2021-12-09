"use strict";

var connectionNotify = new signalR.HubConnectionBuilder().withUrl("/notify").build();

//document.getElementById("message-modal-btn-confirm").disabled = true;

connectionNotify.on("sendToUser", function (user, message) {
    var username = $('.usernameNotify').val();
    
    if (username != user)
    {
        var numCount = Number($('span.count-badge').text());
        numCount = numCount + 1;
        $('span.count-badge').css('display', 'block');
        $('span.count-badge').text(numCount)
        //time
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
        //end time
        if (value['notitype'] == 'message') {
            var html = '<a class="dropdown-item" href="/Module4/Message"><i class="fas fa-envelope mr-2"></i> You have a new <span id="notify" >' + message + '</span>'  + ' at' + time + '</a ><div class="dropdown-divider"></div>';
            $('.dropdown-badge').append(html);
        }
        else if (value['notitype'] == 'meeting') {
            var html = '<a class="dropdown-item" href="/Module4/Calendar"><i class="fas fa-envelope mr-2"></i> You have a new <span id="notify" >' + message + '</span>' + ' at' + time + '</a ><div class="dropdown-divider"></div>';
            $('.dropdown-badge').append(html);
        }
        else {
            var html = '<a class="dropdown-item" href="/Module4/Calendar"><i class="fas fa-envelope mr-2"></i> You have a new <span id="notify" >' + message + '</span>'  + ' at' + time + '</a ><div class="dropdown-divider"></div>';
            $('.dropdown-badge').append(html);
        }
        //var html = '<a class="dropdown-item"><i class="fas fa-envelope mr-2"></i> You have a new <span id="notify" >' + message+'</span></a ><div class="dropdown-divider"></div>';
        //$('.dropdown-badge').append(html);
    }
});
connectionNotify.start().then(function () {
}).catch(function (err) {
    return console.error(err.toString());
});
//connection.start().then(function () {
//    //document.getElementById("message-modal-btn-confirm").disabled = false;
//}).catch(function (err) {
//    return console.error(err.toString());
//});

//document.getElementById("message-modal-btn-confirm").addEventListener("click", function (event) {
//    var user = $('.username').val();
//    var message = document.getElementById("chat-text").value;

//    connection.invoke("SendNotify", user, message).catch(function (err) {
//        return console.error(err.toString());
//    });
    
//    event.preventDefault();
//});