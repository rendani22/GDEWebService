//Table of contents

//01. StartFeeds


//End Table of contents



//01. StartFeeds
var currentStatus = "upload";

function nextUploadproccess() {
    console.log("Works");

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