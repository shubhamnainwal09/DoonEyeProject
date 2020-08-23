



$(document).ready(function () {
    loadDatastate();
});
//Load Data function
function loadDatastate() {

    $.ajax({
        
        url: '/adminuser/State/Liststate',
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
                html += '<td><a href="#" onclick="return getbyID(' + item.StateCode + ')">Edit</a> | <a href="#" onclick="Delele(' + item.StateCode + ')">Delete</a></td>';
                html += '</tr>';

            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}



//Function for getting the Data Based upon State Code
function getbyID(StateCode) {
   
    $('#StateName').css('border-color', 'lightgrey');
    $('#StateInitial').css('border-color', 'lightgrey');

    $.ajax({
        url: "/adminuser/State/GetbyID/" + StateCode,
        typr: "GET",
        data: { 'StateCode': StateCode },
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#StateCode').val(result.StateCode);
            $('#StateName').val(result.StateName);
            $('#StateInitial').val(result.StateInitial);

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
            $('#StateCode').attr('readonly', 'true');
            $('#CountryCode').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}


//Add Data Function
function Addstate() {
    var res = validatestate();
    if (res === false) {
        return false;
    }
    var c = {
        StateCode: $('#StateCode').val(),
        StateName: $('#StateName').val(),
        StateInitial: $('#StateInitial').val(),
        CountryCode: $('#CountryCode').val()
    };
    $.ajax({
        url: '/adminuser/State/Addstate',
        data: JSON.stringify(c),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadDatastate();
            $('#myModal').modal('hide');
            location.reload(true);

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


//Valdidation using jquery
function validatestate() {
    var isValid = true;
    var numbers = /^[0-9]+$/;
    var letters = /^[A-Za-z]+$/;
    if ($('#CountryCode').val().trim() === "" ) {
        $('#CountryCode').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#CountryCode').css('border-color', 'lightgrey');
    }
    if ($('#StateName').val().trim() === "" || !$('#StateName').val().match(letters)) {
        $('#StateName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#StateName').css('border-color', 'lightgrey');
    }

    if ($('#StateCode').val().trim() === "" || !$.isNumeric($('#StateCode').val())) {
        $('#StateCode').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#StateCode').css('border-color', 'lightgrey');
    }
    if ($('#StateInitial').val().trim() === "") {
        $('#StateInitial').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#StateInitial').css('border-color', 'lightgrey');
    }

    return isValid;
}


//Valdidation updateState jquery
function validatestateupdate() {
    var isValid = true;
    var numbers = /^[0-9]+$/;
    var letters = /^[A-Za-z]+$/;

    if ($('#StateName').val().trim() === "" || !$('#StateName').val().match(letters)) {
        $('#StateName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#StateName').css('border-color', 'lightgrey');
    }

    if ($('#StateInitial').val().trim() === "" || !$('#StateInitial').val().match(letters)) {
        $('#StateInitial').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#StateInitial').css('border-color', 'lightgrey');
    }
    return isValid;
}



//function for updating State's record
function Update() {


    var res = validatestateupdate();
    if (res === false) {
        return false;
    }
   
    var c = {
        StateCode: $('#StateCode').val(),
        StateName: $('#StateName').val(),
        StateInitial: $('#StateInitial').val()


    };
    $.ajax({

        url: '/adminuser/State/Updatestate',
        data: JSON.stringify(c),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadDatastate();
            $('#myModal').modal('hide');
           
            $('#StateName').val("");
            $('#StateInitial').val("");

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//function for deleting State record
function Delele(StateCode) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: '/adminuser/State/deletestate/' + StateCode,
            data: JSON.stringify({ "StateCode": StateCode }),
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            processData: false,
            dataType: "json",
            success: function (result) {
                loadDatastate();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}
//Function for clearing the textboxes
function clearTextBox() {

    $('#StateName').val("");
    $('#StateInitial').val("");

    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#StateName').css('border-color', 'lightgrey');
    $('#StateInitial').css('border-color', 'lightgrey');

}






