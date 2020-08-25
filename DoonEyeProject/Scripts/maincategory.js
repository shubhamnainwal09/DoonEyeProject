




$(document).ready(function () {

    loadMainData();

});
//Load Data function
function loadMainData() {

    $.ajax({

        url: '/adminuser/MainCategory/List',
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';

                // html += '<td>' + '<input type="text" readonly value=' + item.CountryName+'></input>'+ '</td>';


                html += '<td>' + item.MainCategoryname + '</td>';
                html += '<td>' + item.MainCategoryDes + '</td>';
               
                html += '<td><a href="#" onclick="return getbyID(' + item.MainCategoryID + ')">Edit</a> | <a href="#" onclick="Delele(' + item.MainCategoryID + ')">Delete</a></td>';
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
function getbyID(MainCategoryID) {

    
    $('#MainCategoryname').css('border-color', 'lightgrey');
    $('#MainCategoryDes').css('border-color', 'lightgrey');
   

    $.ajax({
        url: "/adminuser/MainCategory/GetbyID/" + MainCategoryID,
        typr: "GET",
        data: { 'MainCategoryID': MainCategoryID },
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
           
            $('#MainCategoryID').val(result.MainCategoryID);
            $('#MainCategoryname').val(result.MainCategoryname);
            $('#MainCategoryDes').val(result.MainCategoryDes);
           

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
            $('#MainCategoryID').attr('readonly', 'true');
            $('#SuperCategoryID').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}


//Add Data Function
function AddnewMain() {

    var res = validate();
    if (res === false) {
        return false;
    }

    var c = {
        //MainCategoryID: $('#MainCategoryID').val(),
        SuperCategoryID: $('#SuperCategoryID').val(),
        MainCategoryname: $('#MainCategoryname').val(),
        MainCategoryDes: $('#MainCategoryDes').val()
    };

    $.ajax({

        url: '/adminuser/MainCategory/AddMain',
        data: JSON.stringify(c),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadMainData();
            $('#myModal').modal('hide');
            location.reload(true);

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//var formdata = new FormData(); //FormData object
//var totalFiles = document.getElementById("MainCategoryIcon").files.length;
//for (var i = 0; i < totalFiles; i++) {
//    var file = document.getElementById("MainCategoryIcon").files[i];

//    formData.append("MainCategoryIcon", file);
//}
// var file = document.getElementById("MainCategoryIcon").files[0];
// formData.append("MainCategoryIcon", file);
//Iterating through each files selected in fileInput
//for (i = 0; i < MainCategoryIcon.files.length; i++) {
//Appending each file to FormData object
// formdata.append(MainCategoryIcon.files[i].name, MainCategoryIcon.files[i]);
//}

//formdata.append('MainCategoryID', MainCategoryID);

//formdata.append('MainCategoryname', MainCategoryname);

//formdata.append('MainCategoryDes', MainCategoryDes);


//$.ajax({
//    type: "POST",
//    url: '/adminuser/MainCategory/AddSuper',
//    data: formdata,
//    dataType: 'json',
//    contentType: false, // Not to set any content header  
//    processData: false, // Not to process data  



//    success: function (result) {
//        loadData();
//        $('#myModal').modal('hide');
//        location.reload(true);

//    },
//    error: function (errormessage) {
//        alert(errormessage.responseText);
//    }
//});


//    $.ajax({


//        type: "POST",
//        url: '/adminuser/MainCategory/AddSuper',
//        contentType: "false",
//        processData: "false",
//        success: function (result) {
//            loadDataCity();
//            $('#myModal').modal('hide');
//            location.reload(true);

//        },
//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }
//    });



//}


//Valdidation using jquery
function validate() {
    var isValid = true;
    var letters = /^[A-Za-z]+$/;

    //if ($('#MainCategoryID').val().trim() === "") {
    //    $('#MainCategoryID').css('border-color', 'Red');
    //    isValid = false;
    //}
    //else {
    //    $('#MainCategoryID').css('border-color', 'lightgrey');
    //}

    if ($('#MainCategoryname').val().trim() === "" || !$('#MainCategoryname').val().match(letters)) {
        $('#MainCategoryname').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#MainCategoryname').css('border-color', 'lightgrey');
    }


    if ($('#MainCategoryDes').val().trim() === "") {
        $('#MainCategoryDes').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#MainCategoryDes').css('border-color', 'lightgrey');
    }



    //if ($('#MainCategoryIcon').val().trim() === "") {
    //    $('#MainCategoryIcon').css('border-color', 'Red');
    //    isValid = false;
    //}
    //else {
    //    $('#MainCategoryIcon').css('border-color', 'lightgrey');
    //}

    return isValid;
}

//update main

function Update() {

    var res = validate();
    if (res === false) {
        return false;
    }
    var c = {
       
        MainCategoryID: $('#MainCategoryID').val(),
        MainCategoryname: $('#MainCategoryname').val(),
        MainCategoryDes: $('#MainCategoryDes').val()


    };
    $.ajax({

        url: '/adminuser/MainCategory/update',
        data: JSON.stringify(c),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadMainData();
            $('#myModal').modal('hide');

            $('#MainCategoryname').val("");
            $('#MainCategoryDes').val("");
          

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


//delete main

function Delele(MainCategoryID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: '/adminuser/MainCategory/delete/' + MainCategoryID,
            data: JSON.stringify({ "MainCategoryID": MainCategoryID }),
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            processData: false,
            dataType: "json",
            success: function (result) {
                loadMainData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

//Function for clearing the textboxes
function clearTextBox() {

   
    $('#MainCategoryname').val("");
    $('#MainCategoryDes').val("");
    $('#MainCategoryIcon').val("");


    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#MainCategoryID').css('border-color', 'lightgrey');
    $('#MainCategoryname').css('border-color', 'lightgrey');
    $('#MainCategoryDes').css('border-color', 'lightgrey');
    $('#MainCategoryIcon').css('border-color', 'lightgrey');

}





