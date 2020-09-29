//Table of contents

//01. StartFeeds


//Table of contents




//01. StartFeeds
var currentStatus = "upload";

function nextUploadproccess() {

    if (currentStatus == "upload") {
        currentStatus = "session";
    } else if (currentStatus == "session") {
        currentStatus = "component";
    }


    $.ajax({
        url: "/RMWebService/uploadProcess",
        type: "get",
        data: { step: currentStatus },
    }).done(function (data) {
        $(".partialViewHolder").html(data);
    }).fail(function (err) {
        alert(err);
    });

}