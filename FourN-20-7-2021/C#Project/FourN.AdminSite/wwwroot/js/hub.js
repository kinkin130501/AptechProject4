"use strict";
var connectionNotify = new signalR.HubConnectionBuilder().withUrl("/notify").build();

var connectionChat = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();