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


//let sessions = [];

//const addSession = (ev) => {
//    ev.preventDefault();
//    let sessionData = {
//        id: document.getElementById('#sid').value,
//        name: document.getElementById('#sname').value,
//            stframe: document.getElementById('#stframe').value
//    }
//    sessions.push(sessionData);
//    document.forms[0].reset();

//    console.log(sessionData);
//    console.log(addSession);
//    localStorage.setItem('Session List', JSON.stringify(sessions));
//}

//document.addEventListener('DOMContnetLoaded', () => {
//    document.getElementById('#sbtn').addEventListener('click', sessions);
//});


$(document).ready(function () {
    $(".nameChange").change(function () {
        let nameUpdate = '';
        $(".nameChange").map(function () {
            nameUpdate += this.value;
        })

        $("#Name").val(nameUpdate);
    });

    //Holder for session and product
    console.log(sessionIdentifier);
    console.log(sessionName);
    console.log(timeFrame);

});

    var sessionIdentifier;
    var sessionName;
    var timeFrame;

var QualificationShortName;
var AssessmentIndentifier;
var AssessmentName;
var AssessmentVersion;
var ComponentIdentifier;
var ComponentName;
var ComponentVersion;

var StartDate;
var StartDatePart;
var EndDate;

var QuestionPaperIdentifier;
var Barcode;
var QuestionPaperPartName;
var MarkingType;
var Name;
var PageCount;
var SyllabusCode;

$(".sessionCard").hover(
    function () {
        $(this).addClass("hoverdiv");
    }, function () {
        $(this).removeClass("hoverdiv");
    }
);

$(".ComponentsCard").hover(
    function () {
        $(this).addClass("hoverdiv");
    }, function () {
        $(this).removeClass("hoverdiv");
    }
);




$(".sessionCard").click(function () {

     sessionIdentifier = $(this).find('#SessionIdentifierL').text();
     sessionName = $(this).find('#NameL').text();
     timeFrame = $(this).find('#TimeframeL').text();

    console.log(sessionIdentifier);
    console.log(sessionName);
    console.log(timeFrame);

    $("#step3").trigger("click");
});


$("#newSession").click(function () {
    sessionIdentifier = $("#sid").val();
    sessionName = $("#sname").val();
    timeFrame = $("#stframe").val();

    console.log(sessionIdentifier);
    console.log(sessionName);
    console.log(timeFrame);

    $("#step3").trigger("click");
})

$(".ComponentsCard").click(function () {


    QualificationShortName = $(this).find('#QualificationShortNameL').text();
    AssessmentIndentifier = $(this).find('#AssessmentIndentifierL').text();
    AssessmentName = $(this).find('#AssessmentNameL').text();
    AssessmentVersion = $(this).find('#AssessmentVersionL').text();
    ComponentIdentifier = $(this).find('#ComponentIdentifierL').text();
    ComponentName = $(this).find('#ComponentNameL').text();
    ComponentVersion = $(this).find('#ComponentVersionL').text();

    console.log(QualificationShortName);
    console.log(AssessmentIndentifier);
    console.log(AssessmentName);
    console.log(AssessmentVersion);
    console.log(ComponentIdentifier);
    console.log(ComponentName);
    console.log(ComponentVersion);



    console.log(sessionIdentifier);
    console.log(sessionName);
    console.log(timeFrame);
    //$("#step4").trigger("click");
});


function createProduct() {

    if (!QualificationShortName) {
        console.log($("#QualificationShortName").val().length);
        if ($("#QualificationShortName").val().length == 0) {
            throw new Error("Something went badly wrong!");
        } else {


            QualificationShortName = $("#QualificationShortName").val();
            AssessmentIndentifier = $("#AssessmentIndentifier").val();
            AssessmentName = $("#AssessmentName").val();
            AssessmentVersion = $("#AssessmentVersion").val();
            ComponentIdentifier = $("#ComponentIdentifier").val();
            ComponentName = $("#ComponentName").val();
            ComponentVersion = $("#ComponentVersion").val();


            StartDate = $("#StartDate").val();
            StartDatePart = $("#StartDatePart").val();
            EndDate = $("#EndDate").val();

            QuestionPaperIdentifier = $("#QuestionPaperIdentifier").val();
            Barcode = $("#Barcode").val();
            QuestionPaperPartName = $("#QuestionPaperPartName").val();
            MarkingType = $("#MarkingType").val();
            Name = $("#Name").val();
            PageCount = $("#PageCount").val();
            SyllabusCode = $("#SyllabusCode").val();
        }
    }


    $.ajax({
        type: "POST",
        url: "/Home/addProduct",
        data: {
            QualificationShortName: QualificationShortName, AssessmentIndentifier: AssessmentIndentifier,
            AssessmentName: AssessmentName, AssessmentVersion: AssessmentVersion, ComponentIdentifier: ComponentIdentifier, ComponentName: ComponentName, ComponentVersion: ComponentVersion,
            SessionIdentifier: sessionIdentifier, Name: sessionName, Timeframe: timeFrame,
            StartDate: StartDate, StartDatePart: StartDatePart, EndDate: EndDate,
            QuestionPaperIdentifier: QuestionPaperIdentifier, Barcode: Barcode, QuestionPaperPartName: QuestionPaperPartName, MarkingType: MarkingType, NameQP: Name, PageCount: PageCount, SyllabusCode: SyllabusCode
        },
        success: function (response) {
            console.log("Yes");
        }
    });

}

function showActive(section) {

    var btnContainer = document.getElementById($(section).parent('div')[0].id);

    // Get all buttons with class="btn" inside the container
    var btns = btnContainer.getElementsByClassName("card");
    console.log(btns);
    // Loop through the buttons and add the active class to the current/clicked button
    for (var i = 0; i < btns.length; i++) {
        btns[i].addEventListener("click", function () {
            var current = btnContainer.getElementsByClassName("active");
            for (var j = 0; j < current.length; j++) {
                current[j].className = current[j].className.replace(" active", "");
            }
            this.className += " active";
        });
    }
}

