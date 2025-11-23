
function ChangeImage(input, id) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#imagePath_' + id).attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}

// Attach change handler dynamically if needed
$(document).on('change', 'input[type="file"]', function () {
    var id = $(this).data('id');  // get the id from data attribute
    ChangeImage(this, id);
});