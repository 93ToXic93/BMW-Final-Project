

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

            fetchColors();
            $('#ProgramNameModal').modal('hide');
        }
    });
});

function fetchColors() {
    $.ajax({
        url: 'GetColors',
        type: 'GET',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            console.log(data)

            $('#colorDropdown').empty();
            $('#colorDropdown').append($('<option>').val('').text('chose color'));
            $.each(data, function (index, color) {
                $('#colorDropdown').append($('<option>').val(color.id).text(color.name));
                console.log(color)
            });
        },
        error: function (error) {
            console.error('Error fetching colors:', error);
        }
    });
}

fetchColors();

