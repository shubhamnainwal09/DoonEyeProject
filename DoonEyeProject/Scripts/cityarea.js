



$(document).ready(function () {

    $("#CountryCode").change(function () {
        $.get("/CityArea/getstatebyid", { CountryCode: $("#CountryCode").val() }, function (data) {
            $("#StateCode").empty();
            $.each(data, function (index, row) {
                $("#StateCode").append("<option value='" + row.StateCode + "'>" + row.StateName + "</option>");

            });
        });
    });

    $("#StateCode").change(function () {
        $.get("/CityArea/getcitybyid", { StateCode: $("#StateCode").val() }, function (data) {
            $("#CityCode").empty();
            $.each(data, function (index, row) {
                $("#CityCode").append("<option value='" + row.CityCode + "'>" + row.CityName + "</option>");

            });
        });
    });
    loadDataAreaCity();
});


//Load Data function
function loadDataAreaCity() {

    $.ajax({

        url: '/adminuser/CityArea/Listcityarea',
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';

                html += '<td>' + item.CountryName + '</td>';
                html += '<td>' + item.CountryInitial + '</td>';
                html += '<td>' + item.StateCode + '</td>';
                html += '<td>' + item.StateName + '</td>';
                html += '<td>' + item.StateInitial + '</td>';
                html += '<td>' + item.CityCode + '</td>';
                html += '<td>' + item.CityName + '</td>';
                html += '<td>' + item.AreaCode + '</td>';
                html += '<td>' + item.AreaName + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.AreaCode + ')">Edit</a> | <a href="#" onclick="Delele(' + item.AreaCode + ')">Delete</a></td>';
                html += '</tr>';

            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}



//Function for getting the Data Based upon City Code
function getbyID(CityCode) {

    $('#CityCode').css('border-color', 'lightgrey');
    $('#CityName').css('border-color', 'lightgrey');

    $.ajax({
        url: "/adminuser/City/GetbyID/" + CityCode,
        typr: "GET",
        data: { 'CityCode': CityCode },
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#CityCode').val(result.CityCode);
            $('#CityName').val(result.CityName);


            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
            $('#CityCode').attr('readonly', 'true');
            $('#CountryCode').hide();
            $('#StateCode').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}


//Add Data Function
function Addcityarea() {
    var res = validatecityarea();
    if (res === false) {
        return false;
    }
    var c = {
        AreaCode: $('#AreaCode').val(),
        CityCode: $('#CityCode').val(),
        AreaName: $('#AreaName').val()

    };
    $.ajax({
        url: '/adminuser/CityArea/Addcityarea',
        data: JSON.stringify(c),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadDataAreaCity();
            $('#myModal').modal('hide');
            location.reload(true);

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


//Valdidation using jquery
function validatecityarea() {
    var isValid = true;
    var numbers = /^[0-9]+$/;
    var letters = /^[A-Za-z]+$/;
    if ($('#AreaCode').val().trim() === "" || !$.isNumeric($('#AreaCode').val())) {
        $('#AreaCode').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#AreaCode').css('border-color', 'lightgrey');
    }
    if ($('#AreaName').val().trim() === "" || !$('#AreaName').val().match(letters)) {
        $('#AreaName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#AreaName').css('border-color', 'lightgrey');
    }

    if ($('#CountryCode').val().trim() === "") {
        $('#CountryCode').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#CountryCode').css('border-color', 'lightgrey');
    }
    if ($('#StateCode').val().trim() === "") {
        $('#StateCode').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#StateCode').css('border-color', 'lightgrey');
    }

    if ($('#CityCode').val().trim() === "") {
        $('#CityCode').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#CityCode').css('border-color', 'lightgrey');
    }

    return isValid;
}

//Valdidation updateCity jquery
function validatecityareaupdate() {
    var isValid = true;
    var numbers = /^[0-9]+$/;
    var letters = /^[A-Za-z]+$/;

    if ($('#AreaName').val().trim() === "" || !$('#AreaName').val().match(letters)) {
        $('#AreaName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#AreaName').css('border-color', 'lightgrey');
    }
    return isValid;
}




//function for updating State's record
function Update() {

    var res = validatecityupdate();
    if (res === false) {
        return false;
    }
    var c = {
        CityCode: $('#CityCode').val(),
        CityName: $('#CityName').val()
    };
    $.ajax({

        url: '/adminuser/City/Updatecity',
        data: JSON.stringify(c),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadDataCity();
            $('#myModal').modal('hide');

            $('#CityCode').val("");
            $('#CityName').val("");
            location.reload(true);

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//function for deleting State record
function Delele(CityCode) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: '/adminuser/City/deletecity/' + CityCode,
            data: JSON.stringify({ "CityCode": CityCode }),
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            processData: false,
            dataType: "json",
            success: function (result) {
                loadDataCity();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}
//Function for clearing the textboxes
function clearTextBox() {

    $('#AreaName').val("");
    $('#AreaCode').val("");

    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#AreaName').css('border-color', 'lightgrey');
    $('#AreaCode').css('border-color', 'lightgrey');

}

//check AreaCode Exists
//function CheckAvailability() {
//    var AreaCode = $("#AreaCode").val();
//    $.ajax({
//        type: "POST",
//        url: "/adminuser/CityArea/CheckUsername",
//        data: '{AreaCode: "' + AreaCode + '" }',
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function (response) {
//            var message = $("#message");
//            if (response) {
//                //Email available.
//                message.css("color", "green");
//                //message.html("Email is available");
//            }
//            else {
//                //Email not available.
//                message.css("color", "red");
//                message.html("AreaCode already Exists!");
//            }
//        }
//    });
//}

//function ClearMessage() {
//    $("#message").html("");
//}




