var filedata = [];
var products = [];
$(document).ready(
    function () {
        $.getJSON("../../backend/products.json", function (data) {
            filedata = data;
            $.each(data, function (key, val) {
                products.push("<tr>");
                products.push("<td id=''" + key + "''>" + val.Id + "</td>");
                products.push("<td id=''" + key + "''>" + val.ProductName + "</td>");
                products.push("<td id=''" + key + "''>" + val.CategoryId + "</td>");
                products.push("<td id=''" + key + "''>" + val.Price + "</td>");
                products.push("</tr>");
            });
            $("<tbody/>", { html: products.join("") }).appendTo("table");
        });
        $("#Currency").change(function () {

            var productswithnewprice = [];
            $.each(filedata, function (key, val) {
                productswithnewprice.push("<tr>");
                productswithnewprice.push("<td id=''" + key + "''>" + val.Id + "</td>");
                productswithnewprice.push("<td id=''" + key + "''>" + val.ProductName + "</td>");
                productswithnewprice.push("<td id=''" + key + "''>" + val.CategoryId + "</td>");
                productswithnewprice.push("<td id=''" + key + "''>" + ConvertCurrency(val.Price, document.getElementById("Currency").value) + "</td>");
                productswithnewprice.push("</tr>");
            });
            $("#ProductTable > tbody").empty();
            $("<tbody/>", { html: productswithnewprice.join("") }).appendTo("table");
        });
    });

//send Currency only in USD
function ConvertCurrency(price, currency) {
    switch (currency) {
        case 'USD': return price;
        case 'GBP': return price * 0.71;
        case 'SEK': return price * 8.38;
        case 'DKK': return price * 6.06;
    }
}





