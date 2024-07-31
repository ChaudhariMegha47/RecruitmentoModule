
$(document).ready(function () {
    BindGrid();
});





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
            { data: "jobtitle", name: "Job Title", autoWidth: true },
            { data: "title", name: "Title", autoWidth: true },
            { data: "firstname", name: "First Name", autoWidth: true },
            { data: "middlename", name: "Middle Name", autoWidth: true },
            { data: "lastname", name: "Last Name", autoWidth: true },
            { data: "strBirthdate", name: "Date of Birth", autoWidth: true },
            { data: "age", name: "Age", autoWidth: true },
            { data: "contactno", name: "Contact No.", autoWidth: true },
            { data: "email", name: "Email", autoWidth: true },
            { data: "gender", name: "Gender", autoWidth: true },
            { data: "address", name: "Address", autoWidth: true },
            { data: "strqualification", name: "Qualification", autoWidth: true },
            { data: "experience", name: "Experience", autoWidth: true },
            { data: "candidate_image", name: "Candidate Image", autoWidth: true },
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