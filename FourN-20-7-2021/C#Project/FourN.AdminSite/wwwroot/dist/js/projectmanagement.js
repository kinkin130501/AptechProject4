var multipleCancelButton = new Choices('#choices-multiple-remove-button', {
    removeItemButton: true
});

$('#affairtag').change(function () {
    $('#valueaffairtag').html($('#affairtag').val())
    $('#affairtag').attr('value', $('#affairtag').val());
});

$('#showChartProject').hide();
var hideChart = function () {
    $('#showChartProject').hide();
}
var showProjectChart = function () {
    $('#showChartProject').show();
}

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
                var nameTemp = new Array();
                var dataTemp = new Array();
                var name = new Array();
                var data = new Array();
                chart = Object.entries((Object.entries(response))[0][1]);

                for ([key, value] of chart) {
                    nameTemp.push(key);
                    dataTemp.push(value);
                }
                if (nameTemp.length > 10) {
                    for (let i = 0; i < 10; i++) {
                        name[i] = nameTemp[i];
                        data[i] = dataTemp[i];
                    }
                    name.reverse();
                    data.reverse();
                } else {
                    name = nameTemp;
                    data = dataTemp;
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
                backgroundColor: ['#FFFF00', '#00FF00', '#00FFFF', '#FF3333', '#000080', '#C0C0C0', '#008080', '#008000', '#00FFFF', '#FF9966'],
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

$('#startplan').change(function () {
    var datenow = new Date().getTime();
    var startplan = new Date($('#startplan').val()).getTime();
    if (startplan < datenow) {
        toastr.error("Time of project must be in the future");
    }
});

$('#endplan').change(function () {
    if ($('#startplan').val() != "") {
        if ($('#startplan').val() >= $('#endplan').val()) {
            toastr.error("End Date MUST be greater than Start Date");
            $('#startplan').focus();
        }
    } else {
        toastr.error("Please Insert Start Time Plan !!!");
    }
});


var checkTimeProject = function () {
    if ($('#projectcode').val().trim() == "") {
        toastr.error("Please Enter Project Code");
        $('#projectcode').val("");
        return false;
    }
    if ($('#projectname').val().trim() == "") {
        toastr.error("Please Enter Project Name");
        $('#projectname').val("");
        return false;
    }
    if ($('#startplan').val() >= $('#endplan').val()
        || $('#startactual').val() > $('#endactual').val()) {
        toastr.error("Please End Time GREATER than Start Time");
        return false;
    }
}

var weekstart = getWeek(new Date($('#weekstart').text()));
var weekend = getWeek(new Date($('#weekend').text()));

function getNumberOfWeek(start, end) {
    var html = "";
    for (let i = start; i <= end; i++) {
        html += "<div class=\"form-group col-md-4\"><div style=\"margin: 10px; padding: 5px; border-radius: 5px; width: 70px; height: 70px; background-color: #F5FFFA; border: 1px solid gray\"> W: <span class=\"inputWeekTime\">" + i + "</span></div></div>";
    }
    $("#getWeekTime").html(html);
}
getNumberOfWeek(weekstart, weekend);

var nowdate = new Date();
var nowWeek = getWeek(nowdate);
var arrWeek = $(".inputWeekTime");

for (let k = 0; k < arrWeek.length; k++) {
    if (parseInt($(arrWeek[k]).text()) < nowWeek) {
        $(arrWeek[k]).parent().css({ "background-color": "#4F4F4F", "color": "white" });
    } else if (parseInt($(arrWeek[k]).text()) == nowWeek) {
        $(arrWeek[k]).parent().css("background-color", "#99FFFF");
    }
}
function getWeek(target) {
    var dayNr = (target.getDay() + 6) % 7;
    var firstThursday = target.valueOf();
    target.setDate(target.getDate() - dayNr + 3);
    target.setMonth(0, 1);
    if (target.getDay() != 4) {
        target.setMonth(0, 1 + ((4 - target.getDay()) + 7) % 7);
    }
    return 1 + Math.ceil((firstThursday - target) / 604800000); // 604800000 = 7 * 24 * 3600 * 1000
}

//affair

$('#endtimeplan').change(function () {
    var enddate = new Date($('#endtimeplan').val());
    var thungay = enddate.getDay();
    console.log("thu ngay thang nam: " + thungay);
    if (enddate.getHours() > 18) {
        toastr.error("Time-Job ends at 6 PM");
    }
    if ($('#starttimeplan').val() != "") {
        if ($('#starttimeplan').val() >= $('#endtimeplan').val()) {
            toastr.error("End Date MUST be greater than Start Date");
            $('#starttimeplan').focus();
        }
    } else {
        toastr.error("Please Enter Start Time Plan");
    }
    var startdate = new Date($('#starttimeplan').val()).getTime();
    var end = new Date($('#endtimeplan').val()).getTime();
    var spantime = (end - startdate) / 1000 / 3600;
    if (spantime < 1) {
        toastr.error("Time-Task must be greater than or equal 1 HOUR");
    }
    if (thungay == 0 || thungay == 6) {
        toastr.error("You must not assign affair on Saturday or Sunday");
    }
});

$('#starttimeplan').change(function () {
    var startdate = new Date($('#starttimeplan').val()).getHours();

    var timestartplan = new Date($('#timestartplan').val()).getTime();
    var timeendplan = new Date($('#timeendplan').val()).getTime();
    var starttimeplan = new Date($('#starttimeplan').val()).getTime();

    var thungay = new Date($('#starttimeplan').val()).getDay();
    console.log("thu ngay thang nam: " + thungay);
    if (startdate < 9) {
        toastr.error("Time-Job starts at 9 AM");
    }
    if (startdate > 18) {
        toastr.error("Time-Job end at 6 PM");
    }
    if (starttimeplan < timestartplan) {
        toastr.error('Time of Affair must be greater Start Time of Project');
    }
    if (starttimeplan > timeendplan) {
        toastr.error('Time of Affair must be smaller End Time of Project');
    }

    if (thungay == 0 || thungay == 6) {
        toastr.error("You must not assign affair on Saturday or Sunday");
    }
});

$('#endtimeactual').change(function () {
    if ($('#starttimeactual').val() != "") {
        if ($('#starttimeactual').val() >= $('#endtimeactual').val()) {
            toastr.error("Check Your Date Time");
        }
    } else {
        toastr.error("Please Enter Start Time Actual");
    }
});

var checkTimeAffair = function () {
    if ($('#starttimeplan').val() >= $('#endtimeplan').val() || $('#starttimeactual').val() > $('#endtimeactual').val()) {
        toastr.error("Please End Time GREATER than Start Time");
        return false;
    }
    var startdate = new Date($('#starttimeplan').val()).getTime();
    var end = new Date($('#endtimeplan').val()).getTime();
    var spantime = (end - startdate) / 1000 / 3600;
    if (spantime < 1) {
        toastr.error("Time-Task must be greater than or equal 1 HOUR");
        return false;
    }

    var userid = $('#userid').val();
    if (userid == 0) {
        toastr.error("Choose User");
        return false;
    }
}

getName = {
    init: function () {
        getName.registerEvents();
    },
    registerEvents: function () {
        $('#projectcode').change(function () {
            var name = $('#projectcode').val();
            if (name.trim() != "") {
                if (name.length > 15) {
                    toastr.error("Number of CHARACTERS in PROJECTCODE must be small than 15 letter");
                    $('#projectcode').val("");
                    $('#btnProject').attr('disabled', 'true');
                } else {
                    $.ajax({
                        url: "/ProjectManagement/Project/changeCode",
                        data: { name: name },
                        dataType: "json",
                        type: "POST",
                        success: function (response) {
                            if (response.status == false) {
                                toastr.error("Project CODE is EXIST !!");
                                $('#projectcode').val("");
                                $('#btnProject').attr('disabled', 'true');
                            } else {
                                $('#btnProject').removeAttr('disabled');
                            }
                        }
                    });
                }
            } else {
                toastr.error("Enter Project Code");
                $('#btnProject').attr('disabled', 'true');
            }
        });
    }
}

getName.init();

var selectLeaderID = $('.selectLeaderID');
var getLeaderID = $('.getLeaderID').val();
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
//for (var id of selectMemberID) {
//    if (id.val() == getMemberID) {
//       /* id.attr('checked', true);*/
//        var text = id.text();
//        var html = "<input type='hidden' id='userid' name='userid' value='" + getMemberID + "'/> <input type='text' readonly value='" + text + "'/>";
//        $(".parent").append(html);
//        $("select#userid").remove();
//    }
//}
var option = $("select#userid option:selected");
var text = option.text();
var id = option.val();
var html = `<input type="hidden" id="userid" name="userid" value="${id}"/> <input type="text" style="border:none" readonly value="${text}"/>`
        $(".parent").append(html);
        $("select#userid").remove();

getNotification = {
    init: function () {
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
                backgroundColor: ['#FFFF00', '#00FF00', '#00FFFF', '#FF3333', '#000080'],
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

getLeadGroup = {
    init: function () {
        getLeadGroup.registerEvents();
    },
    registerEvents: function () {
        $('#getLeadGroup').change(function () {
            var id = $('#getLeadGroup').val();
            var html = "";
            $.ajax({
                url: "/ProjectManagement/Project/changeLeadGroup",
                data: { groupid: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    var users = Object.entries((Object.entries(response))[0][1]);
                    for (let i = 0; i < users.length; i++) {
                        html += "<option value=" + users[i][1]["userid"] + ">" + users[i][1]["username"] + "</option>";
                    }

                    $('#leaderid').html(html);
                }
            });
        });
    }
}
getLeadGroup.init();

var triggerTabList = [].slice.call(document.querySelectorAll('#myTab a'));
triggerTabList.forEach(function (triggerEl) {
    var tabTrigger = new bootstrap.Tab(triggerEl);

    triggerEl.addEventListener('click', function (event) {
        event.preventDefault();
        tabTrigger.show();
    });
});

getTimeMember = {
    init: function () {
        getTimeMember.registerEvents();
    },
    registerEvents: function () {
        $('#userid').change(function () {
            var id = $('#userid').val();
            var projectid = $('#projectid').val();
            $.ajax({
                url: "/ProjectManagement/Affair/changeTimeMember",
                data: { memberid: id, projectid: projectid },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    $("#maxtimeget").html(response.time);
                }
            });
        });
    }
}
getTimeMember.init();
