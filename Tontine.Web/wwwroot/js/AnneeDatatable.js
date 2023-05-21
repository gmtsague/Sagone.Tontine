$(document).ready(function () {
  var table =  $("#anneesDatatable").DataTable({
        "processing": true,
      "serverSide": true,
      "responsive": true,
        "filter": true,
        "ajax": {
            "url": "/CoreAnnees/Getdatas",
            "type": "GET",
            "datatype": "json"
        },
       /* "columnDefs": [{
            "targets": [0],
            "visible": false,
            "searchable": false
        }],*/
        "columns": [
            //{ "data": "idannee", "name": "Id", "autoWidth": true },
            { "data": "libelle", "name": "Libell�", "autoWidth": true },
            { "data": "datedebut", "name": "Debut", "autoWidth": true },
            { "data": "datefin", "name": "Fin", "autoWidth": true },
            { "data": "iscurrent", "name": "En cours", "autoWidth": true },
            { "data": "isclosed", "name": "Cl�tur�e", "autoWidth": true },
            { "data": "nbdivision", "name": "Nb divisions", "autoWidth": true },
            { "data": "idbureau", "name": "Bureau", "autoWidth": true },

            {
                "render": function (data, row) { return "<a href='#' class='btn btn-danger' onclick=DeleteCustomer('" + row.id + "'); >Delete</a>"; }
            },
        ]
  });

   /* $('#anneesDatatable tbody').on('click', 'tr', function () {
        $(this).toggleClass('selected');
    });

    $('#button').click(function () {
        alert(table.rows('.selected').data().length + ' row(s) selected');
    });*/
}); 