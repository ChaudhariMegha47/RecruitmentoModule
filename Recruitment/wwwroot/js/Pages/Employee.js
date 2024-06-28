$(document).ready(function () {
    BindGrid();

    $('#addEmployeeBtn').click(function () {
        // Clear the form
        $('#form')[0].reset();
        // Clear any previous error messages
        $('.text-danger').text('');
        $('#addEmployeeModal').modal('show');
    });

    $('#btnMdlSave').click(function () {
        // Validation
        var Title = $('#Title').val();
        var Firstname = $('#Firstname').val();
        var Lastname = $('#Lastname').val();
        var Dateofbirth = $('#Dateofbirth').val();
        var Email = $('#Email').val();
        var Contactno = $('#Contactno').val();
        var Designation = $('#Designation').val();
        var Gender = $('input[name="Gender"]:checked').val()
        var IsActive = $('#IsActive').val();
    
        // Reset previous errors
        $('.text-danger').text('');

        // Custom validations
        if (!Title) {
            $('#titleError').text('Please enter Title.');
            return;
        }
        if (!Firstname) {
            $('#firstnameError').text('Please enter First name.');
            return;
        }
        if (!Lastname) {
            $('#lastnameError').text('Please enter Last name.');
            return;
        }
        if (!Dateofbirth) {
            $('#dobError').text('Please enter Date of birth.');
            return;
        }
        if (!validateEmail(Email)) {
            $('#emailError').text('Please enter a valid Email.');
            return;
        }
        if (!validateContactNumber(Contactno)) {
            $('#contactnoError').text('Please enter 10 digits Contact no.');
            return;
        }
        if (!Designation) {
            $('#designationError').text('Please enter Designation.');
            return;
        }
        if (!Gender) {
            $('#genderError').text('Please select Gender.');
            return;
        }
        if (!IsActive) {
            $('#isactiveError').text('Please select IsActive');
            return;
        }

        var formdata = new FormData($('#form')[0]);

        $.ajax({
            type: "POST",
            url: "/Employee/SaveEmployeeData",
            data: formdata,
            processData: false,
            contentType: false,
            dataType: 'json',
            success: function (data) {
                if (data != null && data != undefined) {
                    BindGrid();
                    $('#addEmployeeModal').modal('hide');
                    alert(data.message);
                    $('#form')[0].reset();
                } else {
                    alert("Record not saved, Try again", "", "error");
                }
            },
            error: function (ex) {
                alert("Something went wrong, Try again!", "", "error");
            }
        });
    });
});

function validateEmail(email) {
    var re = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;
    return re.test(email);
}

function capitalizeFirstLetter(string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
}

function validateContactNumber(contactNumber) {
    // Regular expression for validating contact numbers
    var phonePattern = /^(\+?\d{1,4}[\s-]?)?(\(?\d{3}\)?[\s-]?)?\d{3}[\s-]?\d{4}$/;

    // Test the contact number against the pattern
    return phonePattern.test(contactNumber);
}

function EditModel(empid) {
    $.ajax({
        type: "POST",
        url: "/Employee/EditEmployeeDetails",
        data: { empid: empid },
        success: function (data) {
            if (data.isError) {
                alert(data.strMessage);
            } else {
                var dataList = data.result;
                Object.keys(dataList).forEach(function (key) {
                    if ($('#' + capitalizeFirstLetter(key)) != null && $('#' + key) != undefined) {
                        if (key.includes("is")) {
                            $('#' + capitalizeFirstLetter(key)).prop('checked', dataList[key]);
                        } else {
                            $('#' + capitalizeFirstLetter(key)).val(dataList[key]);
                        }
                    }
                });
            }
            $('#addEmployeeModal').modal('show');
        },
        error: function (ex) {
            alert("Something went wrong. Please try again.", "", "error");
        }
    });
}

function DeleteData(empid) {
    if (confirm('Are you sure you want to delete this?')) {
        $.ajax({
            type: "POST",
            url: "/Employee/DeleteEmployeeData",
            data: { empid: empid },
            success: function (result) {
                BindGrid();
                alert('Deleted successfully.');
            },
            error: function () {
                alert("An error occurred while deleting the Employee.");
            }
        });
    }
}

function BindGrid() {
    // Function to render cards
    function renderCards(data) {
        var cardsContainer = $('#cardsContainer');
        cardsContainer.empty(); // Clear existing cards
        var tr = "";
        var value = 0;

        $.each(data, function (index, employee) {
            value++;
            if (value == 1) {
                tr += "<tr><td><div class='row'>";
            }
            tr += `
                   <div class="col-md-3">
                        <div class="card overflow-hidden rounded-2">
                            <div class="position-relative">
                                <a href="javascript:void(0)">
                                    <img src="${employee.image_Path}" class="card-img-top rounded-0" alt="">
                                </a>
                                <a href="javascript:void(0)" class="bg-primary rounded-circle p-2 text-white d-inline-flex position-absolute bottom-0 end-0 mb-n3 me-3" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-title="Add To Cart">
                                    <i class="ti ti-pencil fs-4" onclick="EditModel('${employee.emp_id}');"></i>
                                </a>
                            </div>
                            <div class="card-body pt-3 p-4">
                                <h6 class="fw-semibold fs-4">${employee.title} ${employee.firstname} ${employee.lastname}</h6>
                                <div class="d-flex align-items-center justify-content-between">
                                    <h6 class="fw-semibold fs-4 mb-0">${employee.designation}</h6>
                                   <button class="btn mb-0 btn-outline-danger btndelete" title="Delete" onclick="DeleteData('${employee.emp_id}');"><i class="fas fa-trash-alt"></i>Delete</button>
                                </div>
                            </div>
                        </div>
                   </div>`;

            if (value == 4) {
                tr += "</div></td></tr>";
                value = 0;
            }
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
            url: '/Employee/GetEmployeeData', // Update with your URL
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
    //        "url": "/Employee/GetEmployeeData",
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
    //        { data: "firstname", name: "Firstname", autoWidth: true },
    //        { data: "lastname", name: "Lastname", autoWidth: true },
    //        { data: "gender", name: "Gender", autoWidth: true },
    //        { data: "strdateofbirth", name: "strdateofbirth", autoWidth: true },
    //        { data: "email", name: "Email", autoWidth: true },
    //        { data: "contactno", name: "Contactno", autoWidth: true },
    //        { data: "designation", name: "Designation", autoWidth: true },
    //        {
    //            data: "IsActive",
    //            render: function (data, type, row) {
    //                return data ? yesBadge : noBadge;
    //            },
    //            autoWidth: true
    //        },
    //        {
    //            data: "emp_id",
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
