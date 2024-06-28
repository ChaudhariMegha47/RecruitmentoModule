
$(document).ready(function () {
    BindGrid();
    BindGetExperienceData();
    BindGetQualificationData();

    $('#addjobBtn').click(function () {
        // Clear the form
        $('#form')[0].reset();
        // Clear any previous error messages
        $('.text-danger').text('');
        $('#addjobModal').modal('show');
    });
    $('#btnMdlSave').click(function () {
        debugger;
        // Validation
        var Title = $('#Title').val();
        var Jobposition = $('#Jobposition').val();
        var Qualification = $('#qualification').val();
        var Jobtype = $('#Jobtype').val();
        var Jobdescription = $('#Jobdescription').val();
        var Vacancies = $('#Vacancies').val();
        var Experience = $('#Experience').val();
        var Validupto = $('#Validupto').val();
        var Createddate = $('#Createddate').val();
        var StartSalary = $('#StartSalary').val();
        var EndSalary = $('#EndSalary').val();
       
        //var Createddate = $('#Createddate').val();
        //var Createdby = $('#Createdby').val();
        // Reset previous errors


        $('.text-danger').text('');


        // Custom validations
        if (!Title) {
            $('#jobError').text('Please enter Title.');
            return;
        }
        if (!Jobposition) {
            $('#jobpositionError').text('Please enter Job position.');
            return;
        }
        if (!Qualification) {
            $('#qualificationError').text('Please enter Qualification.');
            return;
        }
        if (!Jobtype) {
            $('#jobtypeError').text('Please enter Job type');
            return;
        }
        if (!Jobdescription) {
            $('#jobdescError').text('Please enter Job Description.');
            return;
        }
        if (!Vacancies) {
            $('#vacanciesError').text('Please enter Vacancies.');
            return;
        }
       
        if (!Experience) {
            $('#experienceError').text('Please enter Experience.');
            return;
        }
        if (!Validupto) {
            $('#validuptoError').text('Please enter form due date.');
            return;
        }
        if (!Createddate) {
            $('#createddateError').text('Please enter Created date');
            return;
        }
        if (!StartSalary) {
            $('#StartSalaryError').text('Please enter Start salary');
            return;
        }
        if (!EndSalary) {
            $('#EndSalaryError').text('Please enter End salary');
            return;
        }
    
       
        //if (!Createddate) {
        //    $('#createddateError').text('Please enter Created date.');
        //    return;
        //}
        //if (!Createdby) {
        //    $('#createdbyError').text('Please enter Created by.');
        //    return;
        //}

        var formdata = new FormData($('#form')[0]);

        $.ajax({
            type: "POST",
            url: "/Createjob/SaveJobData",
            data: formdata,
            processData: false,
            contentType: false,
            dataType: 'json',
            success: function (data) {
                debugger;
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

function DetailModel(jobid) {
    $.ajax({
        type: "POST",
        url: "/Createjob/DetailsModel",
        data: { jobid: jobid },
        success: function (data) {
            if (data.isError) {
                alert(data.strMessage);
            } else {
                var dataList = data.result;
                Object.keys(dataList).forEach(function (key) {
                    if ($('#' + capitalizeFirstLetter(key)).length > 0 && $('#' + key).length > 0) {
                        if (key.includes("is")) {
                            $('#' + capitalizeFirstLetter(key)).prop('checked', dataList[key]);
                        }
                        else if (key == "Jobdescription") {
                            // Set value to textarea
                            $('#jobdescription').val(dataList[key]);

                            // Initialize CKEditor
                            CKEDITOR.replace('Jobdescription');
                        }
                        // Handle other input types if needed
                        else {
                            $('#' + capitalizeFirstLetter(key)).val(dataList[key]);
                        }
                    }
                });
            }
            $('#addDetailModal').modal('show');
        },
        error: function (ex) {
            alert("Something went wrong. Please try again.", "", "error");
        }
    });
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
                        else if (key == "qualification") {

                            $('#qualification').val(dataList[key]);

                        }
                        //else if (key == "experience") {

                        //    $('#Experience').val(dataList[key]);

                        //}
                        //else if (key == "validupto") {
                        //    $('#Validupto').val(dataList[key]);

                        //}
                        else {
                            $('#' + capitalizeFirstLetter(key)).val(dataList[key]);
                        }
                    }
                });
            }
            $('#addjobModal').modal('show');
        },
        error: function (ex) {
            alert("Something went wrong. Please try again.", "", "error");
        }
    });
}

function capitalizeFirstLetter(string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
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

    // Function to render cards
    function renderCards(data) { 
        var cardsContainer = $('#cardsContainer');
        cardsContainer.empty(); // Clear existing cards
        var tr = "";
        $.each(data, function (index, job) {
            tr += `
                <tr>
                    <td class="row">
                        <div>
                            <div class="col-md-12">
                                <div class="card-outline-primary">
                                    <div class="card">
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <h4 class="card-title">${job.title} &nbsp;<span class="ti ti-info-circle fs-6" onclick="DetailModel('${job.job_id}');" style="display: inline;"></span></h4>
                                                    <div>${job.createddate}</div><br>
                                                </div>
                                                <div class="col-md-8">
                                                    <div class="d-flex justify-content-end">
                                                        <a href="/ListofCandidate/Index?jobId=${job.job_id}" class="btn mb-0 btn-outline-success btnedit d-inline-flex mb-n3 me-3" title="Apply" id="addCandidateBtn">
                                                            Apply Now
                                                        </a>
                                                        <a href="javascript:void(0)" class="bg-primary rounded-circle p-2 text-white d-inline-flex mb-n3 me-3" style="float: right;" data-bs-toggle="tooltip" data-bs-placement="top" title="Edit" onclick="EditModel('${job.job_id}');">
                                                            <i class="ti ti-pencil fs-4"></i>
                                                        </a>
                                                        <a href="javascript:void(0)" class="bg-primary rounded-circle p-2 text-white d-inline-flex mb-n3 me-3" style="float: right;" data-bs-toggle="tooltip" data-bs-placement="top" title="Delete" onclick="DeleteData('${job.job_id}');">
                                                            <i class="ti ti-trash fs-4"></i>
                                                        </a>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-3"><label class="form-label">Vacancies:</label><br>${job.vacancies}</div>
                                                <div class="col-md-3"><label class="form-label">Experience:</label><br>${job.strexperience}</div>
                                                <div class="col-md-3"><label class="form-label">Qualification:</label><br>${job.strqualification}</div>
                                                <div class="col-md-3"><label class="form-label">Valid Upto:</label><br>${new Date(job.validupto).toLocaleDateString()}</div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>`;
                    });

        var table = '<table id="tblData"><thead><tr><th></th></tr></thead ><tbody>' + tr + "</tbody></table>"; 
        cardsContainer.append(table);

        $('#tblData').DataTable({
            "pageLength": 5,
            "lengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "All"]] // Options for the number of records per page
        });
    }

    // Fetch data and render cards
    function fetchDataAndRenderCards() {
        $.ajax({
            url: '/Createjob/GetJobData', // Update with your URL
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response && response.data) {
                    renderCards(response.data);
                }
            },
            error: function (xhr, status, error) {
                console.log('Error:', error);
            }
        });
    }

    // Initial call to fetch data and render cards
    fetchDataAndRenderCards();


    //if ($.fn.DataTable.isDataTable("#tbldata")) {
    //    $('#tbldata').DataTable().clear().destroy();
    //}

    //var yesBadge = '<span class="badge badge-info mt-1">Yes</span>';
    //var noBadge = '<span class="badge badge-secondary mt-1">No</span>';

    //var form = $('#frmAddEdit');
    //var token = $('input[name="AntiforgeryFieldname"]', form).val();

    //$("#tbldata").DataTable({
    //    "processing": true,
    //    "serverSide": false,
    //    "filter": true,
    //    "orderMulti": false,
    //    "initComplete": function () {
    //        var api = this.api();
    //        var searchInput = $('.dataTables_filter input');

    //        searchInput.on('keyup change', function () {
    //            if (searchInput.val() === '') {
    //                api.search('').draw();
    //            }
    //        });
    //    },
    //    "ajax": {
    //        "url": "/Createjob/GetJobData",
    //        "type": "POST",
    //        "headers": {
    //            "RequestVerificationToken": token
    //        },
    //        "datatype": "json",
    //        "dataSrc": function (json) {
    //            console.log(json.data);
    //            return json.data;
    //        },
    //        "error": function (xhr, error, code) {
    //            console.log("Error: ", error);
    //        }
    //    },
    //    "columnDefs": [{
    //        "targets": [0],
    //        "searchable": false
    //    }],
    //    "columns": [
    //        {
    //            name: "Sr No",
    //            render: function (data, type, row, meta) {
    //                return meta.row + meta.settings._iDisplayStart + 1;
    //            },
    //            autoWidth: true
    //        },
    //        { data: "title", name: "Title", autoWidth: true },
    //        { data: "jobdescription", name: "Jobdescription", autoWidth: true },
    //        { data: "strqualification", name: "strqualification", autoWidth: true },
    //        { data: "experience", name: "Experience", autoWidth: true },
    //        { data: "age", name: "Age", autoWidth: true },
    //        { data: "validupto", name: "Validupto", autoWidth: true },
    //        { data: "vacancies", name: "Vacancies", autoWidth: true },
    //        { data: "strCreateDate", name: "strCreateDate", autoWidth: true },
    //        { data: "createdby", name: "createdby", autoWidth: true },
    //        {
    //            data: "isActive",
    //            render: function (data, type, row) {
    //                return data ? yesBadge : noBadge;
    //            },
    //            autoWidth: true
    //        },
    //        {
    //            data: "job_id",
    //            render: function (data, type, row) {
    //                var strEdit = `<button class="btn mb-0 btn-outline-success btnedit" title="Edit" onclick="EditModel('${data}');"><i class="fas fa-pencil-alt"></i>Edit</button>&nbsp;`;
    //                var strRemove = `<button class="btn mb-0 btn-outline-danger btndelete" title="Delete" onclick="DeleteData('${data}');"><i class="fas fa-trash-alt"></i>Delete</button>`;
    //                return strEdit + strRemove;
    //            },
    //            autoWidth: true
    //        }
    //    ]
    //});
}