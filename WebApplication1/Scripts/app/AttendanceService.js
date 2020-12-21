var AttendanceService = function () {
    var createAttendance = function (gigID, onDone, onFail) {
        $.post("/api/attendances", { gidId: gigID })
                .done(onDone)
                .fail(onFail);
    };
    var deleteAttendance = function (gigID, onDone, onFail) {
        $.ajax({
            url: "/api/attendances/" + gigID,
            method: "DELETE"
        })
                .done(onDone)
                .fail(onFail);

    };
    return { 
        createAttendance: createAttendance,
        deleteAttendance: deleteAttendance
    }
   
}();