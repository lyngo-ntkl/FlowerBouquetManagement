// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(() => {
    var connection = new signalR.HubConnectionBuilder().withUrl("/flowerHub").build();
    connection.start();

    connection.on("LoadFlowerBouquet", function () {
        LoadFlowerBouquets();
    })

    LoadFlowerBouquets();

    function LoadFlowerBouquets() {
        $.ajax({
            method: 'GET',
            url: '/?handler=FlowerBouquets',
            success: function (result) {
                DrawFlowerTable(result);
            },
            error: (error) => {
                console.log(error)
            }
        });
    }

    function DrawFlowerTable(result) {
        var values = result.$values;
        var tr = '';
        //console.log(result);
        //console.log(Object.keys(result))
        //console.log(result["id"]);
        //console.log(result['id']);
        //console.log(result.$id);
        //$.each(result, (key, value) => {
            //console.log(value);
            for (let i = 0; i < values.length; i++) {
                var v = values[i];
                tr += `<tr>
            <td>${v.flowerBouquetName}</td>
            <td>${v.description}</td>
            <td>${v.unitPrice}</td>
            <td>${v.unitsInStock}</td>
            <td>${v.flowerBouquetStatus}</td>
            
            <td>
                <a href="/Admin/FlowerBouquetCRUD/Edit?flowerBouquetId=${v.flowerBouquetId}">Edit</a> |
                <a href="/Admin/FlowerBouquetCRUD/Details?flowerBouquetId=${v.flowerBouquetId}">Details</a> |
                <a href="/Admin/FlowerBouquetCRUD/Delete?flowerBouquetId=${v.flowerBouquetId}">Delete</a>
            </td>
        </tr>`
            }
        //});
        $('#flowerTable').html(tr);
    }

    var connectionCustomer = new signalR.HubConnectionBuilder().withUrl("/customerHub").build();
    connectionCustomer.start();

    connectionCustomer.on("LoadCustomer", function () {
        LoadCustomers();
    })

    LoadCustomers();

    function LoadCustomers() {
        $.ajax({
            method: 'GET',
            url: '/Admin/CustomerCRUD/Index?handler=Customers',
            success: function (result) {
                DrawCustomerTable(result);
            },
            error: (error) => {
                console.log(error)
            }
        });
    }

    function DrawCustomerTable(result) {
        var values = result.$values;
        var tr = '';
        for (let i = 0; i < values.length; i++) {
            var v = values[i];
            tr += `<tr>
            <td>${v.email} </td>
            <td>${v.customerName}</td>
            <td>${v.city}</td>
            <td>${v.country}</td>
            <td>${v.password}</td>
            <td>${v.birthday}</td>
            <td>
                <a href="/Admin/CustomerCRUD/Edit?customerId=${v.customerId}">Edit</a> |
                <a href="/Admin/CustomerCRUD/Details?customerId=${v.customerId}">Details</a> |
                <a href="/Admin/CustomerCRUD/Delete?customerId=${v.customerId}">Delete</a>
            </td>
        </tr>`
        }
        $('#tableCustomer').html(tr);
    }
})