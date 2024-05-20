
$(document).ready(function () {
    BindGrid();

    $('#addjobBtn').click(function () {
        $('#addjobModal').modal('show');
    });
    $('#btnMdlSave').click(function () {
        // Validation
        var Title = $('#Title').val();
        var Jobdescription = $('#Jobdescription').val();
        var Qualification = $('#Qualification').val();
        var Experience = $('#Experience').val();
        var Age = $('#Age').val();
        var Validupto = $('#Validupto').val();
        var Vacancies = $('#Vacancies').val();
        var Createddate = $('#Createddate').val();
        var Createdby = $('#Createdby').val();
        // Reset previous errors
        $('.text-danger').text('');


        // Custom validations
        if (!Title) {
            $('#jobError').text('Please enter Title.');
            return;
        }
        if (!Jobdescription) {
            $('#jobdescError').text('Please enter Job decription.');
            return;
        }
        if (!Qualification) {
            $('#qualificationError').text('Please enter Qualification.');
            return;
        }
        if (!Experience) {
            $('#experienceError').text('Please enter Experience.');
            return;
        }
        if (!Age) {
            $('#ageError').text('Please enter Age.');
            return;
        }
        if (!Validupto) {
            $('#validuptoError').text('Please enter form due date.');
            return;
        }
        if (!Vacancies) {
            $('#vacanciesError').text('Please enter Vacancies.');
            return;
        }
        if (!Createddate) {
            $('#createddateError').text('Please enter Created date.');
            return;
        }
        if (!Createdby) {
            $('#createdbyError').text('Please enter Created by.');
            return;
        }

        var formdata = new FormData($('#form')[0]);

        $.ajax({
            type: "POST",
            url: "/Createjob/SaveJobData",
            data: formdata,
            processData: false,
            contentType: false,
            dataType: 'json',
            success: function (data) {
                if (data != null && data != undefined) {

                    //ShowMessage(data.strMessage, "", data.type);
                    BindGrid();
                    $('#addjobModal').modal('hide');
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

function capitalizeFirstLetter(string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
}

function EditModel(jobid) {

    $.ajax({
        type: "POST",
        url: "/Createjob/EditJobDetails",
        data: { jobid: jobid },
        success: function (data) {

            if (data.isError) {
                alert(data.strMessage);
            } else {
                var dataList = data.result;

                Object.keys(dataList).forEach(function (key) {

                    if ($('#' + capitalizeFirstLetter(key)) != null && $('#' + key) != undefined) {
                        if (key.includes("is")) {
                            $('#' + capitalizeFirstLetter(key)).prop('checked', dataList[key]);
                        }
                        else {
                            $('#' + capitalizeFirstLetter(key)).val(dataList[key]);
                        }
                    }

                });

                // Populate form fields
                //Object.keys(qualification).forEach(function (key) {
                //    var value = qualification[key];
                //    // Check if the key exists as an ID in the form
                //    var element = $('#' + key);

                //    if (element.length > 0) { // Check if element exists
                //        if (key === "isActive") {
                //            // Handle checkbox for IsActive
                //            element.prop('checked', value);
                //        } else if (key === "quaName") {
                //            $('#QuaName').val(dataList[key]);
                //            // Assuming 'quaName' is an input field, use .val() to set its value
                //            //element.val(value);
                //        } else {
                //            // Assuming other fields are text fields, use .val() to set their values
                //            element.val(value);
                //        }
                //    }
                //});
            }
            $('#addjobModal').modal('show');
        },
        error: function (ex) {
            ShowMessage("Something went wrong. Please try again.", "", "error");
        }
    });
}


function DeleteData(jobid) {

    if (confirm('Are you sure you want to delete this?')) {
        $.ajax({
            type: "POST",
            url: "/Createjob/DeleteJobData",
            data: { jobid: jobid },
            success: function (result) {
                BindGrid();
                alert('deleted successfully.');
            },
            error: function () {
                alert("An error occurred while deleting the Experience.");
            }
        });
    }

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
            "url": "/Createjob/GetJobData",
            "contentType": false,
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
            { data: "title", name: "Title", autoWidth: true },
            { data: "jobdescription", name: "Jobdecription", autoWidth: true },
            { data: "qualification", name: "Qualification", autoWidth: true },
            { data: "experience", name: "Experience", autoWidth: true },
            { data: "age", name: "Age", autoWidth: true },
            { data: "validupto", name: "Validupto", autoWidth: true },
            { data: "vacancies", name: "Vacancies", autoWidth: true },
            { data: "createddate", name: "Createddate", autoWidth: true },
            { data: "createdby", name: "Createdby", autoWidth: true },

            {
                data: null,
                render: function (data, type, row) {
                    return row.isActive ? yesBadge : noBadge;
                }, autoWidth: true
            },
            {
                data: null,
                render: function (data, type, row) {
                    var strEdit = "<button class=\"btn mb-0 btn-outline-success btnedit\" title=\"Edit\" onclick=\"EditModel('" + row.job_id + "');\" ><i class=\"fas fa-pencil-alt\"></i>Edit</button>&nbsp;";
                    var strRemove = "<button class=\"btn mb-0 btn-outline-danger btndelete\" title=\"Delete\" onclick=\"DeleteData('" + row.job_id + "');\"><i class=\"fas fa-trash-alt\"></i>Delete</button>";
                    var strMain = strEdit + strRemove;
                    return strMain;
                }, autoWidth: true
            },
        ]

    });
}








