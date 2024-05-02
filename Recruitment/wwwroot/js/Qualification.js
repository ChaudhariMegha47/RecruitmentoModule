﻿
$(document).ready(function () {
    BindGrid();

    $('#addQualificationBtn').click(function () {
        $('#addQualificationModal').modal('show');
    });
    $('#btnMdlSave').click(function () {
        //console.log("into this");
        
        // Validation
        var QuaName = $('#QuaName').val();
        // Reset previous errors
        $('.text-danger').text('');

        // Custom validations
        if (!QuaName) {
            $('#qualificationError').text('Please enter First Name.');
            return;
        }

        var formdata = new FormData($('#form')[0]);

        //$.ajax({

        //    type: "POST",
        //    url: "/Qualification/SaveQualificationData",
        //    contentType: false,
        //    data: formdata,
        //    dataType: "json",
        //    success: function (res) {
        //        $("#LanguageId").empty();
        //        $.each(res, function (data, value) {
        //            $("#LanguageId").append($("<option></option>").val(value.value).html(value.text));
        //        });
        //        HideLoader();
        //    }

        //});

        $.ajax({
            type: "POST",
            url: "/Qualification/SaveQualificationData",
            data: formdata,
            processData: false,
            contentType: false,
            dataType: 'json',
            success: function (data) {
                if (data != null && data != undefined) {
                    debugger;
                    //ShowMessage(data.strMessage, "", data.type);
                    BindGrid();
                    $('#addQualificationModal').modal('hide');
                    alert(data.message);
                    $('#form')[0].reset();
                }
                else {
                    alert("Record not saved, Try again", "", "error");
                }
            },
            error: function (ex) {
                alert("Something went wrong, Try again!", "", "error");
            }
        });

    });
});


function EditModel(eduid) {
    debugger;
    $.ajax({
        type: "POST",
        url: "/Qualification/GetQualificationDetails",
        data: { eduid: eduid },
        success: function (data) {
            if (data.isError) {
                alert(data.strMessage);
            } else {
                var qualification = data.result;

                // Populate form fields
                Object.keys(qualification).forEach(function (key) {
                    var value = qualification[key];

                    // Check if the key exists as an ID in the form
                    var element = $('#' + key);
                    if (element.length) {
                        if (key === "IsActive") {
                            // Handle checkbox for IsActive
                            element.prop('checked', value);
                        } else {
                            element.val(value);
                        }
                    }
                });
            }
            $('#addQualificationModal').modal('show');
        },
        error: function (ex) {
            ShowMessage("Something went wrong. Please try again.", "", "error");
        }
    });
}



function DeleteData(row, rowname = '') {
    debugger;
    var form = $('#form');
   // var token = $('input[name="AntiforgeryFieldname"]', form).val();

    confirmDelete("Do you want to delete " + rowname, "/Qualification/DeleteQualificationData", row, "POST");

    BindGrid();
}

function BindGrid() {
    debugger;
    if ($.fn.DataTable.isDataTable("#tbldata")) {
        $('#tbldata').DataTable().clear().destroy();
    }

    var yesBadge = '<td><span class="badge badge-info mt-1">Yes</span></td>';
    var noBadge = '<td><span class="badge badge-secondary mt-1">No</span></td>';

    var form = $('#frmAddEdit');
    var token = $('input[name="AntiforgeryFieldname"]', form).val();

    $("#tbldata").DataTable({
        "processing": true, // for show progress bar
        "serverSide": false, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "initComplete": function () {
            var api = this.api();
            var searchInput = $('.dataTables_filter input');

            searchInput.on('keyup change', function () {
                if (searchInput.val() === '') {
                    api.search('').draw();
                }
            });
        },
        "ajax": {
            "url": "/Qualification/GetQualificationData",
            "contentType": "application/x-www-form-urlencoded",
            "type": "POST",
            'data': {
                "AntiforgeryFieldname": token
                // etc..
            },
            "datatype": "json",
            "dataSrc": function (json) {

                // Settings.
                var jsonObj = json.data;
                // Data
                console.log(jsonObj);
                return jsonObj;
            }
        },
        "columnDefs": [{
            "targets": [0],
            //"visible": false,
            "searchable": false
        }],
        "columns": [

            {
                name: "Sr No",
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }, autoWidth: true
            },
            { data: "qualificationname", name: "Qualification Name", autoWidth: true },
            {
                data: null,
                render: function (data, type, row) {
                    return row.isActive ? yesBadge : noBadge;
                }, autoWidth: true
            },
            {
                data: null,
                render: function (data, type, row) {
                    var strEdit = "<button class=\"btn mb-0 btn-outline-success btnedit\" title=\"Edit\" onclick=\"EditModel('" + row.edu_id + "');\" ><i class=\"fas fa-pencil-alt\"></i>Edit</button>&nbsp;";
                    var strRemove = "<button class=\"btn mb-0 btn-outline-danger btndelete\" title=\"Delete\" onclick=\"DeleteData('" + row.edu_id + "');\"><i class=\"fas fa-trash-alt\"></i>Delete</button>";
                    var strMain = strEdit + strRemove;
                    return strMain;
                }, autoWidth: true
            },
        ]

    });
}








