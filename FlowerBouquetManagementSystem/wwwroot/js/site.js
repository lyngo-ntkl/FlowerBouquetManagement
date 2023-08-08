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
            url: '/User/UserIndexFlowerBouquet?handler=FlowerBouquets',
            success: function (result) {
                DrawFlowerTable(result);
            },
            error: (error) => {
                console.log(error)
            }
        });
        //$.ajax({
        //    method: 'GET',
        //    url: '/Admin/FlowerBouquetCRUD/Index?handler=FlowerBouquets',
        //    success: function (result) {
        //        DrawFlowerTableAdmin(result);
        //    },
        //    error: (error) => {
        //        console.log(error)
        //    }
        //});
    }

    function DrawFlowerTableAdmin(result) {
        var tr = '';
        for (let i = 0; i < result.length; i++) {
            var v = result[i];
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
        var list = document.getElementById('flowerTable');
        for (let i = 0; i < result.length; i++) {
            var v = result[i];
            var tr = document.createElement("tr");
            var name = document.createElement("td"); name.textContent = v.flowerBouquetName; tr.appendChild(name);
            var description = document.createElement("td"); description.textContent = v.description; tr.appendChild(description);
            var unitPrice = document.createElement("td"); unitPrice.textContent = v.unitPrice; tr.appendChild(unitPrice);
            var unitsInStock = document.createElement("td"); unitsInStock.textContent = v.unitsInStock; tr.appendChild(unitsInStock);
            var status = document.createElement("td"); status.textContent = v.flowerBouquetStatus; tr.appendChild(status);
            var category = document.createElement("td"); category.textContent = v.category.categoryName; tr.appendChild(category);
            var btnAdd = document.createElement("button"); btnAdd.textContent = 'Add to cart'; btnAdd.classList.add("btn-link");
            btnAdd.onclick = function () {
                    $.ajax({
                        type: "POST",
                        //headers: { "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val() },
                        url: '/User/UserIndexFlowerBouquet?handler=AddCart',
                        data: {
                            "id": v.flowerBouquetId
                        },
                        contentType: "application/x-www-form-urlencoded",
                        error: (error) => {
                            console.log(error)
                        }
                    }).done(function (response) {
                        alert('Add to cart');
                    });
            };
            
            var td = document.createElement("td"); td.appendChild(btnAdd);
            var btnBuyNow = document.createElement("button"); btnBuyNow.textContent = 'Buy Now';
            tr.appendChild(td);
            console.log(tr);
            list.appendChild(tr);
        }
    }

    //function DrawFlowerTable(result) {
    //    var tr = '';
    //    const NewEL = (tag, prop) => Object.assign(document.createElement(tag), prop);
    //    for (let i = 0; i < result.length; i++) {
    //        var v = result[i];
    //        console.log(v);
    //        console.log(v.category.categoryName)

    //        var btnAdd = NewEL("button", {
    //            textContent: "Add to cart",
    //            onclick() {
    //                var url = window.location.href + '?handler=AddCart';
    //                $.ajax({
    //                    type: "POST",
    //                    //headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
    //                    url: url,
    //                    data: {
    //                        "id": v.flowerBouquetId
    //                    },
    //                    contentType: "application/x-www-form-urlencoded"
    //                }).done(function (response) {
    //                    alert('Add to cart');
    //                });
    //            },
    //        });
    //        console.log(btnAdd);
    //        tr += `<tr>
    //        <td>${v.flowerBouquetName}</td>
    //        <td>${v.description}</td>
    //        <td>${v.unitsInStock}</td>
    //        <td>${v.unitsInStock}</td>
    //        <td>${v.flowerBouquetStatus}</td>
    //        <td>${v.category.categoryName}</td>
    //        <td>${btnAdd}</td>
            
    //    </tr>`
    //    }
    //    //<td>
    //    //    <form method="post" action="/User/UserIndexFlowerBouquet">
    //    //        <input type="hidden" name="id" value="${v.flowerBouquetId}" />
    //    //        <button type="submit" name="action" value="add" class="page-link">Add to cart</button> |
    //    //        <button >Details</button> |
    //    //        <button type="submit" name="action" value="buy">Buy now</button>
    //    //    </form>
    //    //</td>
    //    $('#flowerTable').html(tr);
    //}

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