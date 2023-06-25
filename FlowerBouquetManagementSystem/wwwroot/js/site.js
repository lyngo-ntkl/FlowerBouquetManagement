// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(() => {
    LoadFlowerBouquets()
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
            dataType: 'json',
            success: function (result) {
                DrawTable(result);
            },


            //success: (result) => {
            //    $.each(result, (k, v) => {
            //        tr += `<tr>
            //            <td>${v.FlowerBouquetName}</td>
            //            <td>${v.Description}</td>
            //            <td>${v.UnitPrice}</td>
            //            <td>${v.UnitsInStock}</td>
            //            <td>${v.FlowerBouquetStatus}</td>
            //            <td>${v.Category.CategoryName}</td>
            //            <td>${v.Supplier.SupplierName}</td>
            //            <td>
            //                <a asp-page="./Edit" asp-route-id="@item.FlowerBouquetId">Edit</a> |
            //                <a asp-page="./Details" asp-route-id="@item.FlowerBouquetId">Details</a> |
            //                <a asp-page="./Delete" asp-route-id="@item.FlowerBouquetId">Delete</a>
            //            </td>
            //        </tr>`
            //    })
            //    $("#flowerTable").html(tr);
            //},


            error: (error) => {
                console.log(error)
            }
        });
    }

    function DrawTable(result) {
        var tr = '';
        $.each(result, (k, v) => {
            tr += `<tr>
            <td>${v.FlowerBouquetName}</td>
            <td>${v.Description}</td>
            <td>${v.UnitPrice}</td>
            <td>${v.UnitsInStock}</td>
            <td>${v.FlowerBouquetStatus}</td>
            
            <td>
                <a asp-page="./Edit" asp-route-id="@item.FlowerBouquetId">Edit</a> |
                <a asp-page="./Details" asp-route-id="@item.FlowerBouquetId">Details</a> |
                <a asp-page="./Delete" asp-route-id="@item.FlowerBouquetId">Delete</a>
            </td>
        </tr>`
        })
        $("#flowerTable").html(tr);
    }
})