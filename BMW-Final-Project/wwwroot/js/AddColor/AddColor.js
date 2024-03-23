
$('#submitBtn').on('click', function (e) {
    e.preventDefault();

    console.log("Button clicked");


    var formData = {
        Name: $('#Name').val()
    };

    $.ajax({
        url: 'AddColor',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(formData),
        complete: function () {
            $('#ProgramNameModal').modal('hide');
        }
    });
});
