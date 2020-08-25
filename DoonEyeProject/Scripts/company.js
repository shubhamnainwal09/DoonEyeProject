
$(document).ready(function () {

    loadData();

});
//Load Data function
function loadData() {

    $.ajax({

        url: '/adminuser/MasterCompany/List',
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';

                // html += '<td>' + '<input type="text" readonly value=' + item.CompanyName+'></input>'+ '</td>';

                html += '<td>' + item.CompanyName + '</td>';
                html += '<td>' + item.LocalArea + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.CompanyID + ')">Edit</a> | <a href="#" onclick="Delele(' + item.CompanyID + ')">Delete</a></td>';
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
    $('#CompanyName').css('border-color', 'lightgrey');
    $('#CompanyID').css('border-color', 'lightgrey');
    $('#Address1').css('border-color', 'lightgrey');
    $('#Address2').css('border-color', 'lightgrey');
    $('#CityCode').css('border-color', 'lightgrey');
    $('#LocalArea').css('border-color', 'lightgrey');
    $('#LogoUrl').css('border-color', 'lightgrey');
    $('#Tagline').css('border-color', 'lightgrey');

    $('#Uername').css('border-color', 'lightgrey');
    $('#Password').css('border-color', 'lightgrey');
    $('#CompanyEmail').css('border-color', 'lightgrey');
   


    $.ajax({
        url: "/adminuser/MasterCompany/GetbyID/" + CompanyID,
        typr: "GET",
        data: { 'CompanyID': CompanyID },
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#CompanyID').val(result.CountryCode);
            $('#CompanyName').val(result.CompanyName);
            $('#Address1').val(result.Address1);
            $('#Address2').val(result.Address2);

            $('#CityCode').val(result.CityCode);
            $('#LocalArea').val(result.LocalArea);
            $('#LogoUrl').val(result.LogoUrl);
            $('#Tagline').val(result.Tagline);

            $('#Uername').val(result.LocalArea);
            $('#Password').val(result.LogoUrl);
            $('#CompanyEmail').val(result.Tagline);


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
   
    var c = {

        //CompanyID: $('#CompanyID').val(),
        CompanyName: $('#CompanyName').val(),
        Address1: $('#Address1').val(),
        Address2: $('#Address2').val(),

        CityCode: $('#CityCode').val(),
        LocalArea: $('#LocalArea').val(),
        LogoUrl: $('#LogoUrl').val(),
        Tagline: $('#Tagline').val(),

        Username: $('#Username').val(),
        Password: $('#Password').val(),
        CompanyEmail: $('#CompanyEmail').val()
       
    };
    $.ajax({
        url: '/adminuser/MasterCompany/Add',
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





function clearTextBox() {

    $('#CompanyName').val("");
    $('#CompanyID').val("");

    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#CompanyName').css('border-color', 'lightgrey');
    $('#CompanyID').css('border-color', 'lightgrey');

}





