document.addEventListener('DOMContentLoaded', function () {
    loadOrders();
});

function loadOrders() {
    fetch('/Orders/GetAllOrders') // Aseg�rate de reemplazar con la ruta correcta
        .then(response => response.json())
        .then(data => {
            initializeDataTable(data.data);
        })
        .catch(error => console.error('Error:', error));
}


function initializeDataTable(orders) {
    let table = document.getElementById('ordersTable');
    if (!table) {
        table = document.createElement('table');
        table.id = 'ordersTable';
        table.className = 'display'; // Clase necesaria para DataTables
        document.getElementById('ordersContainer').appendChild(table);
    }

    $(table).DataTable({
        responsive: true,
        data: orders,
        columns: [
            { title: "ID", data: "id", className: "column-id" },
            { title: "Fecha de la Orden", data: "orderDate", className: "column-date" },
            { title: "Numero de orden", data: "orderNumber", className: "column-ordernumber" },
            { title: "CustomeId", data: "customerId", className: "column-customerid" },
            { title: "Total Amount", data: "totalAmount", className: "column-totalamount" },
            {
                title: "Acciones",
                data: "id",
                render: function (data) {
                    return `<div class="text-center">
                                <a href="/Orders/Detail/${data}" class="btn btn-primary"><i class="fa fa-eye"></i></a>
                                <a href="/Orders/Edit/${data}" class="btn btn-secondary"><i class="fa fa-edit"></i></a>
                                <a onclick="Delete('/Orders/Delete/${data}')" class="btn btn-danger"><i class="fa fa-trash"></i></a>
                            </div>`;
                },
                className: "column-actions"
            }
        ]
    });
}


function Delete(url) {
    Swal.fire({
        title: "�Est� seguro de querer borrar el registro?",
        text: "�Esta acci�n no puede ser revertida!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'S�, b�rralo!',
        cancelButtonText: 'Cancelar'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (response) {
                    if (response && response.success) {
                        toastr.success(response.message || "Registro eliminado con �xito.");
                        // Recargar DataTables
                        $('#ordersTable').DataTable().clear().destroy();
                        loadOrders();
                    } else {
                        toastr.error(response.message || "Ocurri� un error desconocido.");
                    }
                },
                error: function (error) {
                    toastr.error("Error al intentar eliminar el registro.");
                    console.error('Error:', error);
                }
            });
        }
    });
}