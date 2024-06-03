$(document).ready(function () {
    BindGrid();

    $('#addEmployeeBtn').click(function () {
        $('#addEmployeeModal').modal('show');
    });

    $('#btnMdlSave').click(function () {
        // Validation
        var Title = $('#Title').val();
        var Firstname = $('#Firstname').val();
        var Lastname = $('#Lastname').val();
        var Gender = $('input[name="Gender"]:checked').val();
        var Dateofbirth = $('#Dateofbirth').val();
        var Email = $('#Email').val();
        var Contactno = $('#Contactno').val();
        var Designation = $('#Designation').val();
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
        if (!Gender) {
            $('#genderError').text('Please select Gender.');
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
        if (!Contactno) {
            $('#contactnoError').text('Please enter Contact no.');
            return;
        }
        if (!Designation) {
            $('#designationError').text('Please enter Designation.');
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
            "url": "/Employee/GetEmployeeData",
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
            { data: "firstname", name: "Firstname", autoWidth: true },
            { data: "lastname", name: "Lastname", autoWidth: true },
            { data: "gender", name: "Gender", autoWidth: true },
            { data: "strdateofbirth", name: "strdateofbirth", autoWidth: true },
            { data: "email", name: "Email", autoWidth: true },
            { data: "contactno", name: "Contactno", autoWidth: true },
            { data: "designation", name: "Designation", autoWidth: true },
            {
                data: "IsActive",
                render: function (data, type, row) {
                    return data ? yesBadge : noBadge;
                },
                autoWidth: true
            },
            {
                data: "emp_id",
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
