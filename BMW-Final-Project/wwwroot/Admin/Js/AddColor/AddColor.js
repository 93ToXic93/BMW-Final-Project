
$('#submitBtn').on('click', function (e) {
    e.preventDefault(); // Prevent default form submission

    console.log("Button clicked");

    // Serialize form data manually
    var formData = {
        Name: $('#Name').val()
    };

    $.ajax({
        url: 'AddColor', // URL of your server-side endpoint
        type: 'POST', // HTTP method
        contentType: 'application/json',
        data: JSON.stringify(formData), // Form data to be sent to the server
        complete: function () {
            $('#ProgramNameModal').modal('hide');
        }
    });
});
