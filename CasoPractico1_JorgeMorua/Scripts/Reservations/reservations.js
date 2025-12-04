$(document).ready(function () {
    let table = new DataTable('#reservationsTable');
});

// Abrir offcanvas y cargar PartialView
$(document).on('click', '.addReservations', function () {

    // 1) Mostrar SweetAlert de carga
    Swal.fire({
        title: 'Cargando formulario...',
        text: 'Por favor espera un momento.',
        allowOutsideClick: false,
        allowEscapeKey: false,
        didOpen: () => {
            Swal.showLoading();
        }
    });

    $.ajax({
        url: '/Reservations/CreatePV',     // mejor ruta absoluta
        type: 'GET',
        success: function (response) {
            // 3) Cerrar el loader
            Swal.close();

            $('#offcanvasRightReservationsAdd .offcanvas-body').html(response);

            let offcanvas = bootstrap.Offcanvas.getOrCreateInstance(
                document.getElementById('offcanvasRightReservationsAdd')
            );
            offcanvas.show();
        },
        error: function () {
            Swal.fire({
                title: "Oops!",
                text: "No podemos cargar el offcanvas!",
                icon: "error"
            }).then(() => location.reload());
        }
    });
});

// Enviar formulario por AJAX
$(document).on('click', '#submitReservationsAdd', function (e) {
    e.preventDefault();

    const $form = $('#offcanvasRightReservationsAdd').find('form');

    $.ajax({
        url: '/Reservations/CreatePV',      // ruta absoluta
        type: 'POST',
        data: $form.serialize(),
        success: function (response) {
            if (response.success) {
                Swal.fire({
                    title: "¡Éxito!",
                    text: "¡Reserva creada con éxito!",
                    icon: "success"
                }).then(() => {
                    // Redirigir a Details usando el ID que vino del server
                    window.location.href = '/Reservations/Details?id=' + response.reservationId;
                });
            } else {
                // Si response no es JSON (es HTML), esto vuelve a dibujar el form con validaciones
                $('#offcanvasRightReservationsAdd .offcanvas-body').html(response);
            }
        },
        error: function () {
            Swal.fire({
                title: "Oops!",
                text: "No podemos procesar tu solicitud en este momento.",
                icon: "error"
            }).then(() => location.reload());
        }
    });
});

// Cuando cambie la habitación o las fechas, intentamos recalcular el monto
$(document).on('change', '#idRoom, #FechaInicioReserva, #FechaFinReserva', function () {
    calcularMontoReserva();
});

function calcularMontoReserva() {
    // Valores del formulario dentro del offcanvas
    const roomId = $('#idRoom').val();
    const fechaInicio = $('#FechaInicioReserva').val();
    const fechaFin = $('#FechaFinReserva').val();

    // Si falta alguno, limpiamos el monto y no hacemos nada
    if (!roomId || !fechaInicio || !fechaFin) {
        $('#monto').val('');
        return;
    }

    $.ajax({
        url: '/Reservations/CalcularMonto',   // ruta absoluta
        type: 'GET',
        data: {
            roomId: roomId,
            fechaInicio: fechaInicio,
            fechaFin: fechaFin
        },
        success: function (response) {
            console.log('CalcularMonto response:', response); // DEBUG

            if (response.success) {
                // Usamos "total" porque así lo devuelve tu controller
                $('#monto').val(response.total);
            } else {
                console.log(response.message);
                $('#monto').val('');
            }
        },
        error: function (xhr, status, error) {
            console.log('Error al llamar a CalcularMonto:', status, error);
            $('#monto').val('');
        }
    });
}
