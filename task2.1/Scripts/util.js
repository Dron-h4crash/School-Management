$(function () {

    var server = $.connection.myHub;
    
    server.client.onDataChanged = function () {

        document.location.reload();
    }

    $.connection.hub.start();
});
