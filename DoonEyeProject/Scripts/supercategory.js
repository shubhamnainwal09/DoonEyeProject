
$(document).ready(function () {

    loadSuperData();

});
//Load Data function
function loadSuperData() {

    $.ajax({

        url: '/adminuser/SuperCategory/List',
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';

                // html += '<td>' + '<input type="text" readonly value=' + item.SuperCategoryName+'></input>'+ '</td>';

                
                html += '<td>' + item.SuperCategoryName + '</td>';
                html += '<td>' + item.SuperCategoryDescription + '</td>';
                html += '<td>' + '<img src=' + item.SuperCategoryIcon + '></img>' + '</td>';
               // html += '<td>' + item.SuperCategoryIcon + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.SuperCategoryID + ')">Edit</a> | <a href="#" onclick="Delele(' + item.SuperCategoryID + ')">Delete</a></td>';
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
function getbyID(SuperCategoryID) {

    $('#SuperCategoryName').css('border-color', 'lightgrey');
    $('#SuperCategoryDescription').css('border-color', 'lightgrey');
    //$('#SuperCategoryIcon').css('border-color', 'lightgrey');

   
    $.ajax({
        url: "/adminuser/SuperCategory/GetbyID/" + SuperCategoryID,
        typr: "GET",
        data: { 'SuperCategoryID': SuperCategoryID },
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#SuperCategoryID').val(result.SuperCategoryID);
            $('#SuperCategoryName').val(result.SuperCategoryName);
            $('#SuperCategoryDescription').val(result.SuperCategoryDescription);
            
            
            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
            $('#SuperCategoryID').attr('readonly', 'true');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}


//Add Data Function
function AddnewSuper() {

    var formdata = new FormData(); //FormData object
    var fileInput = document.getElementById('SuperCategoryIcon');
    var SuperCategoryName = document.getElementById("SuperCategoryName").value;
    var SuperCategoryDescription = document.getElementById("SuperCategoryDescription").value;
    for (i = 0; i < fileInput.files.length; i++) {
        //Appending each file to FormData object
        formdata.append(fileInput.files[i].name, fileInput.files[i]);
    }
    var res = validate();
    if (res === false) {
        return false;
    }
    
    formdata.append("SuperCategoryName", SuperCategoryName);
    formdata.append("SuperCategoryDescription", SuperCategoryDescription);
    //Creating an XMLHttpRequest and sending
    var xhr = new XMLHttpRequest();
    xhr.open('POST', '/SuperCategory/AddSuper');
    xhr.send(formdata);
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == 200) {
            alert(xhr.responseText);
        }
    }
    return false;
}

//var formdata = new FormData(); //FormData object
    //var totalFiles = document.getElementById("SuperCategoryIcon").files.length;
    //for (var i = 0; i < totalFiles; i++) {
    //    var file = document.getElementById("SuperCategoryIcon").files[i];

    //    formData.append("SuperCategoryIcon", file);
    //}
   // var file = document.getElementById("SuperCategoryIcon").files[0];
   // formData.append("SuperCategoryIcon", file);
    //Iterating through each files selected in fileInput
    //for (i = 0; i < SuperCategoryIcon.files.length; i++) {
        //Appending each file to FormData object
       // formdata.append(SuperCategoryIcon.files[i].name, SuperCategoryIcon.files[i]);
    //}

    //formdata.append('SuperCategoryID', SuperCategoryID);

    //formdata.append('SuperCategoryName', SuperCategoryName);

    //formdata.append('SuperCategoryDescription', SuperCategoryDescription);


    //$.ajax({
    //    type: "POST",
    //    url: '/adminuser/SuperCategory/AddSuper',
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
//        url: '/adminuser/SuperCategory/AddSuper',
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

    //if ($('#SuperCategoryID').val().trim() === "") {
    //    $('#SuperCategoryID').css('border-color', 'Red');
    //    isValid = false;
    //}
    //else {
    //    $('#SuperCategoryID').css('border-color', 'lightgrey');
    //}
   
    if ($('#SuperCategoryName').val().trim() === "" || !$('#SuperCategoryName').val().match(letters)) {
        $('#SuperCategoryName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#SuperCategoryName').css('border-color', 'lightgrey');
    }


    if ($('#SuperCategoryDescription').val().trim() === "") {
        $('#SuperCategoryDescription').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#SuperCategoryDescription').css('border-color', 'lightgrey');
    }
   


    //if ($('#SuperCategoryIcon').val().trim() === "") {
    //    $('#SuperCategoryIcon').css('border-color', 'Red');
    //    isValid = false;
    //}
    //else {
    //    $('#SuperCategoryIcon').css('border-color', 'lightgrey');
    //}

    return isValid;
}

//function for edit/update superCategory

function Update() {

    var res = validate();
    if (res === false) {
        return false;
    }
    var c = {
        //SuperCategoryID: $('#SuperCategoryID').val(),
        SuperCategoryName: $('#SuperCategoryName').val(),
        SuperCategoryDescription: $('#SuperCategoryDescription').val()


    };
    $.ajax({

        url: '/adminuser/SuperCategory/update',
        data: JSON.stringify(c),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadSuperData();
            $('#myModal').modal('hide');

            $('#SuperCategoryName').val("");
            $('#SuperCategoryDescription').val("");

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


//deleting super

function Delele(SuperCategoryID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: '/adminuser/SuperCategory/delete/' + SuperCategoryID,
            data: JSON.stringify({ "SuperCategoryID": SuperCategoryID }),
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            processData: false,
            dataType: "json",
            success: function (result) {
                loadSuperData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

//Function for clearing the textboxes
function clearTextBox() {

   
    $('#SuperCategoryName').val("");
    $('#SuperCategoryDescription').val("");
    $('#SuperCategoryIcon').val("");
   

    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#SuperCategoryID').css('border-color', 'lightgrey');
    $('#SuperCategoryName').css('border-color', 'lightgrey');
    $('#SuperCategoryDescription').css('border-color', 'lightgrey');
    $('#SuperCategoryIcon').css('border-color', 'lightgrey');

}





