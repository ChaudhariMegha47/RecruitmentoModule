$(document).ready(function () {
    $('#addDetailModal').on('shown.bs.modal', function () {
        // Replace 'path_to_ckeditor' with the actual path where CKEditor is located.
        CKEDITOR.replace('Jobdescription');
    });
});