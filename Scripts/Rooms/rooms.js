$(document).ready(function () {
    let table = new DataTable('#roomsTable');
    $('#openModal').click(function () {
        $.ajax({
            url: 'PartialViewRooms',
            type: 'GET',
            data: { },
            success: function (response) {
                $('#exampleModal .modal-body').html(response);
                $('#exampleModal').modal('show');
            },
            error: function (xhr, status, error) {
                alert('Error loading rooms: ' + error);
            }
        });
    });
});

function loadRoom(roomId) {
}