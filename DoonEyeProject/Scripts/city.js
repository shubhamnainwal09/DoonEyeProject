



$(document).ready(function () {
    
    $("#CountryCode").change(function () {
        $.get("/City/getstatebyid", { CountryCode: $("#CountryCode").val() }, function (data) {
            $("#StateCode").empty();
            $.each(data, function (index, row) {
                $("#StateCode").append("<option value='" + row.StateCode + "'>" + row.StateName + "</option>");
                
            });
        });
    });
    loadDataCity();
});


//Load Data function
function loadDataCity() {

    $.ajax({

        url: '/adminuser/City/Listcity',
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
                html += '<td><a href="#" onclick="return getbyID(' + item.CityCode + ')">Edit</a> | <a href="#" onclick="Delele(' + item.CityCode + ')">Delete</a></td>';
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
function Addcity() {
    var res = validatecity();
    if (res === false) {
        return false;
    }
    var c = {
        CityCode: $('#CityCode').val(),
        StateCode: $('#StateCode').val(),
        CityName: $('#CityName').val()
        
    };
    $.ajax({
        url: '/adminuser/City/Addcity',
        data: JSON.stringify(c),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadDataCity();
            $('#myModal').modal('hide');
            location.reload(true);

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


//Valdidation using jquery
function validatecity() {
    var isValid = true;
    var numbers = /^[0-9]+$/;
    var letters = /^[A-Za-z]+$/;
    if ($('#CityCode').val().trim() === "" || !$.isNumeric($('#CityCode').val())) {
        $('#CityCode').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#CityCode').css('border-color', 'lightgrey');
    }
    if ($('#CityName').val().trim() === "" || !$('#CityName').val().match(letters)) {
        $('#CityName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#CityName').css('border-color', 'lightgrey');
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
    
    return isValid;
}

//Valdidation updateCity jquery
function validatecityupdate() {
    var isValid = true;
    var numbers = /^[0-9]+$/;
    var letters = /^[A-Za-z]+$/;
   
    if ($('#CityName').val().trim() === "" || !$('#CityName').val().match(letters)) {
        $('#CityName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#CityName').css('border-color', 'lightgrey');
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

    $('#CityName').val("");
    $('#CityCode').val("");

    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#CityName').css('border-color', 'lightgrey');
    $('#CityCode').css('border-color', 'lightgrey');

}






