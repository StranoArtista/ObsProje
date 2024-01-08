$(document).ready(function () {
    $('#dataTableData').DataTable({
        language: {
            url:"//cdn.datatables.net/plug-ins/1.13.4/i18n/tr.json"
        },
        columnDefs: [
            { orderable: false, targets:[-1] }
        ],
    })
});