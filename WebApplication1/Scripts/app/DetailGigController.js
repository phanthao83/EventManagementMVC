var DetailGigController = function (followService) {
    var button; 
    var onDone = function () {
        var text = (button.text == "Follow?") ? "Follow?" : "Following"
        button.toggleClass("btn-link").toggleClass("btn-info").text(text);
    };
    var onFail = function () {
        alert("System Error ! Pls contact IT. ");
    };

    var toogleFollow = function (e) {
        button = $(e.target);
        var artId = button.attr("data-art-id");
        if (button.hasClass("btn-link")) followService.createFollow(artId, onDone, onFail);
        else followService.deleteFollow(artId, onDone, onFail);

    };
    var manageFollow = function (container) {
        
        $(container).on("click", ".js-toogle-follow", toogleFollow);
    }; 

    return {
        manageFollow: manageFollow
    }
 

}(FollowService);