// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(() => {
    //LoadFlowerBouquets()
    var connection = new signalR.HubConnectionBuilder().withUrl("/flowerHub").build();
    connection.start();

    connection.on("LoadFlowerBouquet", function () {
        LoadFlowerBouquets();
    })

    LoadFlowerBouquets();

    function LoadFlowerBouquets() {
        $.ajax({
            method: 'GET',
            url: '/Admin/FlowerBouquetCRUD/Index?handler=FlowerBouquets',
            success: function (result) {
                DrawFlowerTableAdmin(result);
            },
            error: (error) => {
                console.log(error)
            }
        });
        $.ajax({
            method: 'GET',
            url: '/User/Index?handler=FlowerBouquets',
            success: function (result) {
                DrawFlowerTable(result);
            },
            error: (error) => {
                console.log(error)
            }
        });
    }

    function DrawFlowerTableAdmin(result) {
        var values = result.$values;
        var tr = '';
        for (let i = 0; i < values.length; i++) {
            var v = values[i];
            tr += `<tr>
            <td>${v.flowerBouquetName}</td>
            <td>${v.description}</td>
            <td>${v.unitPrice}</td>
            <td>${v.unitsInStock}</td>
            <td>${v.flowerBouquetStatus}</td>
            <td>${v.category.categoryName}</td>
            <td>
                <a href="/Admin/FlowerBouquetCRUD/Edit?flowerBouquetId=${v.flowerBouquetId}">Edit</a> |
                <a href="/Admin/FlowerBouquetCRUD/Details?flowerBouquetId=${v.flowerBouquetId}">Details</a> |
                <a href="/Admin/FlowerBouquetCRUD/Delete?flowerBouquetId=${v.flowerBouquetId}">Delete</a>
            </td>
        </tr>`
            }
        $('#flowerTable').html(tr);
    }

    function DrawFlowerTable(result) {
        var values = result.$values;
        console.log(result);
        console.log(values);
        var tr = '';
        for (let i = 0; i < values.length; i++) {
            var v = values[i];
            console.log(v)
            var cate = v.category.categoryName;
            console.log(cate)
            // missing cate
            
            tr += `<tr>
            <td>${v.flowerBouquetName}</td>
            <td>${v.description}</td>
            <td>${v.unitsInStock}</td>
            <td>${v.unitsInStock}</td>
            <td>${v.flowerBouquetStatus}</td>
            <td>${v.category.categoryName}</td>
            
            <td>
                <form method="post">
                    <input type="hidden" name="id" value="@item.FlowerBouquetId"/>
                    <button asp-page-handler="AddCart" type="submit" name="action" value="add">Add to cart</button> |
                    <button>Details</button> |
                    <button type ="submit" name="action" value="buy">Buy now</button>
                </form>
            </td>
        </tr>`
        }
    }

    function LoadCustomers() {
        $.ajax({
            method: 'GET',
            url: '/Admin/CustomerCRUD/Index',
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
        console.log(values);
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
                <a asp-page="./Edit" asp-route-id="@item.CustomerId">Edit</a> |
                <a asp-page="./Details" asp-route-id="@item.CustomerId">Details</a> |
                <a asp-page="./Delete" asp-route-id="@item.CustomerId">Delete</a>
            </td>
        </tr>`
        }
        $('#tableCustomer').html(tr);
    }
})