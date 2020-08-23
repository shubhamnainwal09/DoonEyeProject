
$(document).ready(function () {
    
    loadData();
    
});
//Load Data function
function loadData() {
    
    $.ajax({
        
        url: '/adminuser/Country/List',
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
           
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                
               // html += '<td>' + '<input type="text" readonly value=' + item.CountryName+'></input>'+ '</td>';
               
                html += '<td>' + item.CountryName + '</td>';
                html += '<td>' + item.CountryInitial + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.CountryCode + ')">Edit</a> | <a href="#" onclick="Delele(' + item.CountryCode + ')">Delete</a></td>';
                html += '</tr>'; 
               
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


//Function for getting the Data Based upon Country Code
function getbyID(CountryCode) {
    $('#CountryName').css('border-color', 'lightgrey');
    $('#CountryInitial').css('border-color', 'lightgrey');
    
    $.ajax({
        url: "/adminuser/Country/GetbyID/" + CountryCode,
        typr: "GET",
        data: { 'CountryCode': CountryCode},
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#CountryCode').val(result.CountryCode);
            $('#CountryName').val(result.CountryName);
            $('#CountryInitial').val(result.CountryInitial);
            
            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}


//Add Data Function
function Add() {
    var res = validate();
    if (res === false) {
        return false;
    }
    var c = {
        
        CountryName: $('#CountryName').val(),
        CountryInitial: $('#CountryInitial').val()
    };
    $.ajax({
        url: '/adminuser/Country/Add',
        data: JSON.stringify(c),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            location.reload(true);
            
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


//Valdidation using jquery
function validate() {
    var isValid = true;
    var letters = /^[A-Za-z]+$/;
    if ($('#CountryName').val().trim() === "" || !$('#CountryName').val().match(letters)) {
        $('#CountryName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#CountryName').css('border-color', 'lightgrey');
    }
    if ($('#CountryInitial').val().trim() === "" || !$('#CountryInitial').val().match(letters)) {
        $('#CountryInitial').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#CountryInitial').css('border-color', 'lightgrey');
    }
   
    return isValid;
}



//function for updating Country's record
function Update() {
    
    var res = validate();
    if (res === false) {
        return false;
    }
    var c = {
        CountryCode: $('#CountryCode').val(),
        CountryName: $('#CountryName').val(),
        CountryInitial: $('#CountryInitial').val()
        
        
    };
    $.ajax({
        
        url: '/adminuser/Country/update',
        data: JSON.stringify(c),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
           
            $('#CountryName').val("");
            $('#CountryInitial').val("");
            
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//function for deleting Country record
function Delele(CountryCode) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: '/adminuser/Country/delete/' + CountryCode,
            data: JSON.stringify({ "CountryCode": CountryCode }),
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            processData: false,
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}
//Function for clearing the textboxes
function clearTextBox() {
    
    $('#CountryName').val("");
    $('#CountryInitial').val("");
    
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#CountryName').css('border-color', 'lightgrey');
    $('#CountryInitial').css('border-color', 'lightgrey');
  
}
   

   
     
   
