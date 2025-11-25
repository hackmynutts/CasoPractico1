$(document).ready(function () {
     let table = new DataTable('#roomsTable');
    $('#openModal').on('click', function () {
        $.ajax({
            // Ruta MVC hacia RoomsController.PartialViewRooms
            url: 'PartialViewRooms',
            type: 'GET',
            success: function (response) {
                // Inserta el HTML de la partial en el cuerpo del modal
                $('#exampleModal .modal-body').html(response);
                let myModal = new bootstrap.Modal(document.getElementById('exampleModal'));
                myModal.show();
            },
            error: function (xhr, status, error) {
                console.error('Error AJAX:', status, error, xhr.responseText);
                alert('Error cargando habitaciones: ' + error);
            }
        });
    });
});

// Espera a que todo el DOM esté cargado antes de ejecutar el código
$(document).ready(function () {

    // Cuando se hace clic en el botón "Agregar cuartos"
    $('#openModalAdd').on('click', function () {
        $.ajax({
            // Acción del controlador que devuelve la *partial view* con el formulario
            url: 'CreatePV',
            type: 'GET',
            // Si el servidor respondió bien
            success: function (response) {
                // Inserta el HTML de la partial dentro del cuerpo del modal
                $('#AddRoomModal .modal-body').html(response);

                // Crea una instancia del modal de Bootstrap y lo muestra
                let myModal = new bootstrap.Modal(document.getElementById('AddRoomModal'));
                myModal.show();
            },
            // Si hubo error en la petición GET
            error: function (xhr, status, error) {
                console.error('Error AJAX:', status, error, xhr.responseText);
                alert('Error cargando el formulario de agregar habitación: ' + error);
            }
        });
    });

    // Cuando se hace clic en el botón "Crear" dentro del modal
    $('#submitRoomsAdd').on('click', function () {
        // Busca el <form> que está dentro del modal (viene en la partial)
        const $form = $('#AddRoomModal').find('form');

        $.ajax({
            // Acción del controlador que recibe el POST y guarda la habitación
            url: 'CreatePV',
            type: 'POST',
            // Envía todos los campos del formulario serializados (nombre=valor&...)
            data: $form.serialize(),
            // Si el servidor respondió bien
            success: function (response) {
                // Si el controlador devolvió JSON { success: true }
                if (response.success) {
                    Swal.fire({
                        title: "Excelente!",
                        text: "Habitación agregada exitosamente!",
                        icon: "success"
                    }).then(() => {
                        // Recarga la página para ver la nueva habitación en la tabla
                        location.reload();
                    });
                } else {
                    // Si hubo errores de validación, el servidor devuelve otra vez la partial;
                    // se reemplaza el cuerpo del modal por ese HTML (mostrando mensajes de error).
                    $('#AddRoomModal .modal-body').html(response);
                }
            },
            // Si hubo error en la petición POST
            error: function (xhr, status, error) {
                console.error('Error AJAX:', status, error, xhr.responseText);
                alert('Error al agregar la habitación: ' + error);
            }
        });
    });
});
