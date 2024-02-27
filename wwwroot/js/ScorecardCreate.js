function showParData() {
    var selectedCourse = document.getElementById("CourseId").value;

    // Do a Ajax call to the ScorecardController action "GetCourseInfo"
    // find what par is for every hole given the selected course
    $.ajax({
        type: 'GET',
        url: '/Scorecard/GetCourseInfo',
        data: { selectedCourse: selectedCourse },
        success: function (data) {
            changeParText(data)//Implement partial refreshing.
        }
    });
}


function changeParText(data) {
    //Loop over key value pairs and change text of corresponding div
    Object.entries(data).map(([holeNumber, par] = entry) => {
        $(`#par${holeNumber}`).text(par);
    })
}


//JQuery Test
/*
$(document).ready(function () {
    $("div").click(function () {
        $(this).hide();
    });
});
*/