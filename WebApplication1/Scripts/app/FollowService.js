var FollowService = function () {

    var createFollow = function (followeeId , onDone, onFail){
        $.post("/api/follow", { followeeID: followeeId })
              .done(onDone)
              .fail(onFail);
    }; 
    var deleteFollow = function (followeeId, onDone, onFail) {
        $.ajax({
            url: "/api/follow/" + followeeId,
            method: "DELETE"
        }).done(onDone)
            .fail(onFail);
    };
    return {
        createFollow: createFollow, 
        deleteFollow: deleteFollow
    }

}();