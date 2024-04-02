


console.log('im in');

$('#AlertColor').hide();
$('#AlertColorError').hide();

$('#submitBtn').on('click', function () {
    var formData = $('#Name').val();

    var obj = {
        Name: formData
    }

    $.ajax({
        url: '/Admin/AddColor',
        type: 'POST',
        data: obj,
        success: function () {

            console.log('adding color')

            $('#AlertColor').fadeIn('slow');
            fetchColors();
            $('#ProgramNameModal').modal('hide');
        },
        error: function (error) {
            $('#AlertColorError').fadeIn('slow');
        },

    });

    setTimeout(function () {
        $('#AlertColor').fadeOut('slow');
    }, 3000);
    setTimeout(function () {
        $('#AlertColorError').fadeOut('slow');
    }, 3000);
   
});


function fetchColors() {
    console.log('im in fetch')
    $.ajax({
        url: '/Admin/GetColors',
        type: 'GET',
        dataType: 'json',
        contentType: "application/json",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        success: function (data) {
            console.log(data)
            console.log('im in succses fetch')
            $('#colorDropdown').empty();
            $('#colorDropdown').append($('<option>').val('').html('Изберете цвят'));
            $.each(data, function (index, color) {
                $('#colorDropdown').append($('<option>').val(color.id).text(color.name));
                console.log(color)
            });
            console.log('made every color')
        },
        error: function (error) {
            console.error('Error fetching colors:', error);
        }
    });
}

fetchColors();