var multipleCancelButton = new Choices('#choices-multiple-remove-button', {
    removeItemButton: true
});

$('#affairtag').change(function () {
    $('#valueaffairtag').html($('#affairtag').val())
    $('#affairtag').attr('value', $('#affairtag').val());
});

getPercent = {
    init: function () {
        getPercent.registerEvents();
    },
    registerEvents: function () {
        $('#projectid').change(function (e) {
            e.preventDefault();
            var projectid = $('.checkedProject').val();

            $.ajax({
                url: "/ProjectManagement/Affair/changePercent",
                data: { projectid: projectid },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    $('#affairtag').attr('max', response.sparePercent);
                    $('#labelPercent').html("1 - " + response.sparePercent);
                }
            });
        });
    }
}
getPercent.init();
var chart;
getChartProject = {
    init: function () {
        getChartProject.registerEvents();
    },
    registerEvents: function () {
        $.ajax({
            url: "/ProjectManagement/Project/changeChartProject",
            dataType: "json",
            type: "GET",
            success: function (response) {
                var name = new Array();
                var data = new Array();
                chart = Object.entries((Object.entries(response))[0][1]);
                for ([key, value] of chart) {
                    name.push(key);
                    data.push(value);
                    console.log(key);
                    console.log(value);
                }
                renderChart(name, data, "bar", "myChartProject");
            }
        });
    }
}
getChartProject.init();

function renderChart(name, data, type, area) {
    new Chart(document.getElementById(area), {
        type: type,
        data: {
            labels: name,
            datasets: [{
                label: "unit (%)",
                backgroundColor: getColor(name.length),
                data: data
            }]
        },
        options: {
            title: {
                display: true,
                text: 'Project Statistic',
            }, tooltips: {
                enabled: true
            },
            scales: {
                xAxes: [{
                    display: true,
                    scaleLabel: {
                        display: true,
                        labelString: 'Project'
                    }
                }],
                yAxes: [{
                    display: true,
                    ticks: {
                        beginAtZero: true,
                        steps: 20,
                        stepValue: 5,
                        max: 100
                    }
                }]
            },
        }
    });
}

function get_random_color() {
    function c() {
        var hex = Math.floor(Math.random() * 256).toString(16);
        return ("0" + String(hex)).substr(-2); // pad with zero
    }
    return "#" + c() + c() + c();
}

function getColor(number) {
    var color = new Array();
    for (i = 0; i < number; i++) {
        color.push(get_random_color());
    }
    return color;
}
//project

$('#endplan').blur(function () {
    if ($('#startplan').val() != "") {
        if ($('#startplan').val() > $('#endplan').val()) {
            alert("Check Your Date Time");
            $('#startplan').focus();
        }
    } else {
        alert("Please Insert Start Time Plan !!!");
    }
});

$('#endactual').blur(function () {
    if ($('#startactual').val() != "") {
        if ($('#startactual').val() > $('#endactual').val()) {
            alert("Check Your Date Time");
        }
    } else {
        alert("Please Insert Start Time Actual !!!");
    }
})

var checkTimeProject = function () {
    if ($('#startplan').val() > $('#endplan').val() || $('#startactual').val() > $('#endactual').val()) {
        alert("Please End Time GREATER than Start Time");
        return false;
    }
}
//affair
$('#endtimeplan').blur(function () {
    if ($('#starttimeplan').val() != "") {
        if ($('#starttimeplan').val() > $('#endtimeplan').val()) {
            alert("Check Your Date Time");
            $('#endtimeplan').focus();
        }
    } else {
        alert("Please Enter Start Time Plan");
    }
})
$('#endtimeactual').blur(function () {
    if ($('#starttimeactual').val() != "") {
        if ($('#starttimeactual').val() > $('#endtimeactual').val()) {
            alert("Check Your Date Time");
            $('#endtimeactual').focus();
        }
    } else {
        alert("Please Enter Start Time Actual");
    }
})

var checkTimeAffair = function () {
    if ($('#starttimeplan').val() > $('#endtimeplan').val() || $('#starttimeactual').val() > $('#endtimeactual').val()) {
        alert("Please End Time GREATER than Start Time");
        return false;
    }
}

getName = {
    init: function () {
        getName.registerEvents();
    },
    registerEvents: function () {
        $('#projectname').blur(function () {
            var name = $('#projectname').val();
            if (name.trim() != "") {
                $.ajax({
                    url: "/ProjectManagement/Project/changeName",
                    data: { name: name },
                    dataType: "json",
                    type: "POST",
                    success: function (response) {
                        if (response.status == false) {
                            alert("Project Name is EXIST !!");
                            $('#projectname').reset();
                            $('#projectname').focus();
                        } else {
                            $('#btnProject').removeAttr('disabled');
                        }
                    }
                });
            } else {
                alert("Enter Project Name");
            }
        });
    }
}

getName.init();

var selectLeaderID = $('.selectLeaderID');
var getLeaderID = $('.getLeaderID').val();
console.log("leader" + selectLeaderID)
for (var id of selectLeaderID) {
    if (this.val() == getLeaderID) {
        this.attr('checked', true);
    }
}

var selectDocID = $('.selectDocID');
var getDocID = $('.getDocID').val();
for (var id of selectDocID) {
    if (this.val() == getDocID) {
        this.attr('checked', true);
    }
}

var selectMemberID = $('.selectMemberID');
var getMemberID = $('.getMemberID').val();
for (var id of selectMemberID) {
    if (this.val() == getMemberID) {
        this.attr('checked', true);
    }
}

getNotification = {
    init: function () {
        console.log("check Notification")
        getNotification.registerEvents();
    },
    registerEvents: function () {
        $.ajax({
            url: "/ProjectManagement/Affair/getNotification",
            dataType: "json",
            type: "GET",
            success: function (response) {
                $('#notiNew').html(response.countNew);
                $('#notiDebug').html(response.countDebug);
                $('#notiChecking').html(response.countChecking);
                $('#notiProcess').html(response.countProcess);
                $('#notiDone').html(response.countDone);
            }
        });
    }
}
getNotification.init();

$('[data-toggle="tooltip"]').tooltip();


getChartAffair = {
    init: function () {
        getChartAffair.registerEvents();
    },
    registerEvents: function () {
        var id = $('#getProjectID').val();

        if (id == 0) {
            $('#showChart').hide();
        } else {
            console.log( "chartid " + id);
            $.ajax({
                url: "/ProjectManagement/Affair/changeChartAffair",
                data: { chartid: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    var name = new Array();
                    var data = new Array();
                    chart = Object.entries((Object.entries(response))[0][1]);
                    for ([key, value] of chart) {
                        name.push(key);
                        data.push(value);
                    }
                    renderChartAffair(name, data, "pie", "myChartAffair");
                }
            });
        }
    }
}
getChartAffair.init();

function renderChartAffair(name, data, type, area) {
    new Chart(document.getElementById(area), {
        type: type,
        data: {
            labels: name,
            datasets: [{
                label: "unit (%)",
                backgroundColor: ['#FFFF00', '#00FF00', '#00FFFF', '#FF3333', '#000080', '#C0C0C0'],
                data: data
            }]
        },
        options: {
            title: {
                display: true,
                text: 'Project Statistic',
            }, tooltips: {
                enabled: true
            },
            scales: {
                xAxes: [{
                    display: true,
                    scaleLabel: {
                        display: true,
                        labelString: 'Project'
                    }
                }],
                yAxes: [{
                    display: true,
                    ticks: {
                        beginAtZero: true,
                        steps: 20,
                        stepValue: 5,
                        max: 100
                    }
                }]
            },
        }
    });
}