var GigController = function (attendanceService) {
    var button; 

    var onFail = function () {
        alert("System Error roi do !")
    };
    var onDone = function () {
        var text = (button.text == "Going?") ? "Going?" : "Going"
        button.toggleClass("btn-info").toggleClass("btn-default").text(text);
    };
    var toogleAttendance = function (e) {
        button = $(e.target);
         var id = button.attr("data-gig-id"); 
        if (button.hasClass("btn-default")) attendanceService.createAttendance(id, onDone, onFail);
        else attendanceService.deleteAttendance(id, onDone, onFail); 
    };
    var manageAttendance = function (container) {
        $(container).on("click", ".js-toogle-attendance", toogleAttendance);
       
    };
    return {
        manageAttendance: manageAttendance
    }

}(AttendanceService);