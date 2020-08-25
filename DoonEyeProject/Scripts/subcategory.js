



$(document).ready(function () {

    $("#SuperCategoryID").change(function () {
        $.get("/SubCategory/getmainbyid", { SuperCategoryID: $("#SuperCategoryID").val() }, function (data) {
            $("#MainCategoryID").empty();
            $.each(data, function (index, row) {
                $("#MainCategoryID").append("<option value='" + row.MainCategoryID + "'>" + row.MainCategoryname + "</option>");

            });
        });
    });
    loadDataSub();
});


//Load Data function
function loadDataSub() {

    $.ajax({

        url: '/adminuser/SubCategory/ListSub',
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';

               
               
                html += '<td>' + item.SubCategoryName + '</td>';
                html += '<td>' + item.SubCategoryDes + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.SubCategoryID + ')">Edit</a> | <a href="#" onclick="Delele(' + item.SubCategoryID + ')">Delete</a></td>';
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
function getbyID(SubCategoryID) {

    $('#SubCategoryID').css('border-color', 'lightgrey');
    $('#SubCategoryName').css('border-color', 'lightgrey');
    $('#SubCategoryDes').css('border-color', 'lightgrey');

    $.ajax({
        url: "/adminuser/SubCategory/GetbyID/" + SubCategoryID,
        typr: "GET",
        data: { 'SubCategoryID': SubCategoryID },
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#SubCategoryID').val(result.SubCategoryID);
            $('#SubCategoryName').val(result.SubCategoryName);
            $('#SubCategoryDes').val(result.SubCategoryName);


            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
            $('#SubCategoryID').attr('readonly', 'true');
            $('#MainCategoryID').hide();
            $('#SuperCategoryID').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}


//Add Data Function
function Addsub() {
    var res = validatesub();
    if (res === false) {
        return false;
    }
    var c = {

        //SubCategoryID: $('#SubCategoryID').val(),
        SubCategoryName: $('#SubCategoryName').val(),
        SubCategoryDes: $('#SubCategoryDes').val(),
        MainCategoryID: $('#MainCategoryID').val(),
        

    };
    $.ajax({
        url: '/adminuser/SubCategory/AddSub',
        data: JSON.stringify(c),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadDataSub();
            $('#myModal').modal('hide');
            location.reload(true);

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


//Valdidation using jquery
function validatesub() {
    var isValid = true;
    var numbers = /^[0-9]+$/;
    var letters = /^[A-Za-z]+$/;
    //if ($('#SubCategoryID').val().trim() === "" || !$.isNumeric($('#SubCategoryID').val())) {
    //    $('#SubCategoryID').css('border-color', 'Red');
    //    isValid = false;
    //}
    //else {
    //    $('#SubCategoryID').css('border-color', 'lightgrey');
    //}
    if ($('#SubCategoryName').val().trim() === "" || !$('#SubCategoryName').val().match(letters)) {
        $('#SubCategoryName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#SubCategoryName').css('border-color', 'lightgrey');
    }


    if ($('#SubCategoryDes').val().trim() === "") {
        $('#SubCategoryDes').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#SubCategoryName').css('border-color', 'lightgrey');
    }

   

    return isValid;
}

//update sub

function Update() {

    var res = validate();
    if (res === false) {
        return false;
    }
    var c = {
        
        SubCategoryID: $('#SubCategoryID').val(),
        SubCategoryName: $('#SubCategoryName').val(),
        SubCategoryDes: $('#SubCategoryDes').val()


    };
    $.ajax({

        url: '/adminuser/SuperCategory/update',
        data: JSON.stringify(c),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadDataSub();
            $('#myModal').modal('hide');

            $('#SubCategoryName').val("");
            $('#SubCategoryDes').val("");

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


//deleting sub

function Delele(SubCategoryID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: '/adminuser/SubCategory/delete/' + SubCategoryID,
            data: JSON.stringify({ "SubCategoryID": SubCategoryID }),
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            processData: false,
            dataType: "json",
            success: function (result) {
                loadDataSub();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}




//Function for clearing the textboxes
function clearTextBox() {

   
    $('#SubCategoryID').val("");
    $('#SubCategoryDes').val("");

    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#SubCategoryName').css('border-color', 'lightgrey');
    $('#SubCategoryID').css('border-color', 'lightgrey');

}






