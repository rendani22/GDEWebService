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

    console.log(StartDate);
    console.log(StartDatePart);
    console.log(EndDate);

    console.log(QuestionPaperIdentifier);
    console.log(Barcode);
    console.log(QuestionPaperPartName);
    console.log(MarkingType);
    console.log(Name);
    console.log(PageCount);
    console.log(SyllabusCode);

    console.log(sessionIdentifier);
    console.log(sessionName);
    console.log(timeFrame);



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