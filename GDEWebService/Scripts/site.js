//Table of contents

//import { get } from "jquery";

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


let sessions = [];

const addSession = (ev) => {
    ev.preventDefault();
    let sessionData = {
        id: document.getElementById('#sid').value,
        name: document.getElementById('#sname').value,
            stframe: document.getElementById('#stframe').value
    }
    sessions.push(sessionData);
    document.forms[0].reset();

    console.log(sessionData);
    console.log(addSession);
    localStorage.setItem('Session List', JSON.stringify(sessions));
}

document.addEventListener('DOMContnetLoaded', () => {
    document.getElementById('#sbtn').addEventListener('click', sessions);
});

