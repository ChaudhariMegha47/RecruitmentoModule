
$(document).ready(function () {
    BindGrid();
    BindGetExperienceData();
    BindGetQualificationData();

    $('#addjobBtn').click(function () {
        $('#addjobModal').modal('show');
    });
    $('#btnMdlSave').click(function () {
        // Validation
        var Title = $('#Title').val();
        var Jobdescription = $('#Jobdescription').val();
        var Qualification = $('#qualification').val();
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
                alert('Deleted successfully.');
            },
            error: function () {
                alert("An error occurred while deleting the Job.");
            }
        });
    }

}

function BindGetExperienceData() {
    // Populate experience dropdown
    $.ajax({
        type: "GET",
        url: "/Experience/ExperienceList", // URL to fetch experience data
        dataType: 'json',
        success: function (data) {
            if (data != null && data.length > 0) {
                // Clear existing options
                $('#Experience').empty();

                // Add default option
                $('#Experience').append('<option value="">Select Experience</option>');

                // Iterate over experience data and add options to the dropdown
                $.each(data, function (index, experience) {
                    console.log(experience);
                    $('#Experience').append('<option value="' + experience.exp_id + '">' + experience.experience + '</option>');
                });
            } else {
                // Handle empty or no data
                $('#Experience').append('<option value="">No data available</option>');
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.error("Error fetching experience data: ", textStatus, errorThrown);
            alert("An error occurred while fetching experience data.");
        }
    });
}

function BindGetQualificationData() {
    // Populate experience dropdown
    $.ajax({
        type: "GET",
        url: "/Qualification/QualificationList", // URL to fetch experience data
        dataType: 'json',
        success: function (data) {
            if (data != null && data.length > 0) {
                // Clear existing options
                $('#qualification').empty();

                // Add default option
                $('#qualification').append('<option value="">Select Qualification</option>');

                // Iterate over experience data and add options to the dropdown
                $.each(data, function (index, qualification) {
                    console.log(qualification);
                    $('#qualification').append('<option value="' + qualification.edu_id + '">' + qualification.qualificationname + '</option>');
                });
            } else {
                // Handle empty or no data
                $('#qualification').append('<option value="">No data available</option>');
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.error("Error fetching qualification data: ", textStatus, errorThrown);
            alert("An error occurred while fetching qualification data.");
        }
    });
}

function BindGrid() {
    if ($.fn.DataTable.isDataTable("#tbldata")) {
        $('#tbldata').DataTable().clear().destroy();
    }

    var yesBadge = '<span class="badge badge-info mt-1">Yes</span>';
    var noBadge = '<span class="badge badge-secondary mt-1">No</span>';

    var form = $('#frmAddEdit');
    var token = $('input[name="AntiforgeryFieldname"]', form).val();

    $("#tbldata").DataTable({
        "processing": true,
        "serverSide": false,
        "filter": true,
        "orderMulti": false,
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
            "type": "POST",
            "headers": {
                "RequestVerificationToken": token
            },
            "datatype": "json",
            "dataSrc": function (json) {
                console.log(json.data);
                return json.data;
            },
            "error": function (xhr, error, code) {
                console.log("Error: ", error);
            }
        },
        "columnDefs": [{
            "targets": [0],
            "searchable": false
        }],
        "columns": [
            {
                name: "Sr No",
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                },
                autoWidth: true
            },
            { data: "title", name: "Title", autoWidth: true },
            { data: "jobdescription", name: "Jobdescription", autoWidth: true },
            { data: "strqualification", name: "strqualification", autoWidth: true },
            { data: "experience", name: "Experience", autoWidth: true },
            { data: "age", name: "Age", autoWidth: true },
            { data: "validupto", name: "Validupto", autoWidth: true },
            { data: "vacancies", name: "Vacancies", autoWidth: true },
            { data: "strCreateDate", name: "strCreateDate", autoWidth: true },
            { data: "createdby", name: "Createdby", autoWidth: true },
            {
                data: "isActive",
                render: function (data, type, row) {
                    return data ? yesBadge : noBadge;
                },
                autoWidth: true
            },
            {
                data: "job_id",
                render: function (data, type, row) {
                    var strEdit = `<button class="btn mb-0 btn-outline-success btnedit" title="Edit" onclick="EditModel('${data}');"><i class="fas fa-pencil-alt"></i>Edit</button>&nbsp;`;
                    var strRemove = `<button class="btn mb-0 btn-outline-danger btndelete" title="Delete" onclick="DeleteData('${data}');"><i class="fas fa-trash-alt"></i>Delete</button>`;
                    return strEdit + strRemove;
                },
                autoWidth: true
            }
        ]
    });
}









