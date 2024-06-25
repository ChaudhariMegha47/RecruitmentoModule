
$(document).ready(function () {
    BindGrid();
    BindGetExperienceData();
    BindGetQualificationData();

    $('#addCandidateBtn').click(function () {
        // Clear the form
        $('#form')[0].reset();
        // Clear any previous error messages
        $('.text-danger').text('');
        $('#addCandidateModal').modal('show');
    });
    $('#btnMdlSave').click(function () {
        // Validation
        var candidateimage = $('#CandidateImageFile').val();
        var Title = $('#Title').val();
        var Firstname = $('#Firstname').val();
        var Middlename = $('#MiddleName').val();
        var Lastname = $('#Lastname').val();
        var Gender = $('input[name="Gender"]:checked').val();
        var Dateofbirth = $('#Dateofbirth').val();
        var Age = $('#Age').val();
        var Email = $('#Email').val();
        var address = $('#Address').val();
        var Contactno = $('#Contactno').val();
        var experience = $('#Experience').val();
        var qualification = $('#qualification').val();
        var resume = $('#ResumeImageFile').val();
        var Result = $('#Result').val();
        // Reset previous errors
        $('.text-danger').text('');

        // Custom validations
        if (!candidateimage) {
            $('#candidateError').text('Please Upload Candidate Image.');
            return;
        }
        if (!Title) {
            $('#titleError').text('Please enter Title.');
            return;
        }
        if (!Firstname) {
            $('#firstnameError').text('Please enter First name.');
            return;
        }
        if (!Middlename) {
            $('#middlenameError').text('Please enter Middle name.');
            return;
        }
        if (!Lastname) {
            $('#lastnameError').text('Please enter Last name.');
            return;
        }
        if (!Gender) {
            $('#genderError').text('Please select Gender.');
            return;
        }
        if (!Dateofbirth) {
            $('#dobError').text('Please enter Date of birth.');
            return;
        }
        if (!Age) {
            $('#ageError').text('Please enter Age.');
            return;
        }
        if (!validateEmail(Email)) {
            $('#emailError').text('Please enter a valid Email.');
            return;
        }
        if (!address) {
            $('#addressError').text('Please enter Address.');
            return;
        }
        if (!Contactno) {
            $('#contactnoError').text('Please enter Contact no.');
            return;
        }
        if (!experience) {
            $('#experienceError').text('Please Select Experience.');
            return;
        }
        if (!qualification) {
            $('#qualificationError').text('Please Select Qualification.');
            return;
        }
        if (!resume) {
            $('#resumeError').text('Please Upload Resume Image.');
            return;
        }
        if (!Result) {
            $('#resultError').text('Please enter Satuts.');
            return;
        }

        var formdata = new FormData($('#form')[0]);

        $.ajax({
            type: "POST",
            url: "/ListofCandidate/SaveListofCandidateData",
            data: formdata,
            processData: false,
            contentType: false,
            dataType: 'json',
            success: function (data) {
                if (data != null && data != undefined) {

                    //ShowMessage(data.strMessage, "", data.type);
                    BindGrid();
                    $('#addCandidateModal').modal('hide');
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

function EditModel(candidateid) {
    $.ajax({
        type: "POST",
        url: "/ListofCandidate/EditListofCandidateDetails",
        data: { candidateid: candidateid },
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
            $('#addCandidateModal').modal('show');
        },
        error: function (ex) {
            alert("Something went wrong. Please try again.", "", "error");
        }
    });
}

function DeleteData(candidateid) {
    if (confirm('Are you sure you want to delete this?')) {
        $.ajax({
            type: "POST",
            url: "/ListofCandidate/DeleteListofCandidateData",
            data: { candidateid: candidateid },
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
            "url": "/ListofCandidate/GetListofCandidateData",
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
            { data: "job_id", name: "Job", autoWidth: true },
            { data: "candidate_image", name: "Candidate Image", autoWidth: true },
            { data: "title", name: "Title", autoWidth: true },
            { data: "firstname", name: "First Name", autoWidth: true },
            { data: "middlename", name: "Middle Name", autoWidth: true },
            { data: "lastname", name: "Last Name", autoWidth: true },
            { data: "gender", name: "Gender", autoWidth: true },
            { data: "dateofbirth", name: "Date of Birth", autoWidth: true },
            { data: "age", name: "Age", autoWidth: true },
            { data: "email", name: "Email", autoWidth: true },
            { data: "address", name: "Address", autoWidth: true },
            { data: "contactno", name: "Contact No.", autoWidth: true },
            { data: "experience", name: "Experience", autoWidth: true },
            { data: "qualification", name: "Qualification", autoWidth: true },
            { data: "resume_image", name: "Resume", autoWidth: true },
            { data: "result", name: "Result", autoWidth: true },
            {
                data: null,
                render: function (data, type, row) {
                    return row.isActive ? yesBadge : noBadge;
                }, autoWidth: true
            },
            {
                data: null,
                render: function (data, type, row) {
                    var strEdit = "<button class=\"btn mb-0 btn-outline-success btnedit\" title=\"Edit\" onclick=\"EditModel('" + row.candidate_id + "');\" ><i class=\"fas fa-pencil-alt\"></i>Edit</button>&nbsp;";
                    var strRemove = "<button class=\"btn mb-0 btn-outline-danger btndelete\" title=\"Delete\" onclick=\"DeleteData('" + row.candidate_id + "');\"><i class=\"fas fa-trash-alt\"></i>Delete</button>";
                    var strMain = strEdit + strRemove;
                    return strMain;
                }, autoWidth: true
            },
        ]

    });
}









