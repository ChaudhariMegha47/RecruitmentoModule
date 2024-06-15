
$(document).ready(function () {
    BindGrid();

    $('#addRoleBtn').click(function () {
        // Clear the form
        $('#form')[0].reset();
        // Clear any previous error messages
        $('.text-danger').text('');
        $('#addRoleModal').modal('show');
    });
    $('#btnMdlSave').click(function () {
        // Validation
        var Role = $('#Rolename').val();
        // Reset previous errors
        $('.text-danger').text('');

        // Custom validations
        if (!Role) {
            $('#roleError').text('Please enter Role.');
            return;
        }

        var formdata = new FormData($('#form')[0]);

        $.ajax({
            type: "POST",
            url: "/Role/SaveRoleData",
            data: formdata,
            processData: false,
            contentType: false,
            dataType: 'json',
            success: function (data) {
                if (data != null && data != undefined) {

                    //ShowMessage(data.strMessage, "", data.type);
                    BindGrid();
                    $('#addRoleModal').modal('hide');
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

function EditModel(roleid) {

    $.ajax({
        type: "POST",
        url: "/Role/GetRoleDetails",
        data: { roleid: roleid },
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
            $('#addRoleModal').modal('show');
        },
        error: function (ex) {
            ShowMessage("Something went wrong. Please try again.", "", "error");
        }
    });
}


function DeleteData(roleid) {

    if (confirm('Are you sure you want to delete this?')) {
        $.ajax({
            type: "POST",
            url: "/Role/DeleteRoleData",
            data: { roleid: roleid },
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
            "url": "/Role/GetRoleData",
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
            { data: "rolename", name: "Role", autoWidth: true },
            {
                data: null,
                render: function (data, type, row) {
                    return row.isActive ? yesBadge : noBadge;
                }, autoWidth: true
            },
            {
                data: null,
                render: function (data, type, row) {
                    var strEdit = "<button class=\"btn mb-0 btn-outline-success btnedit\" title=\"Edit\" onclick=\"EditModel('" + row.role_id + "');\" ><i class=\"fas fa-pencil-alt\"></i>Edit</button>&nbsp;";
                    var strRemove = "<button class=\"btn mb-0 btn-outline-danger btndelete\" title=\"Delete\" onclick=\"DeleteData('" + row.role_id + "');\"><i class=\"fas fa-trash-alt\"></i>Delete</button>";
                    var strMain = strEdit + strRemove;
                    return strMain;
                }, autoWidth: true
            },
        ]

    });
}








