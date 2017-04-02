(function (tibox) {
    tibox.order = tibox.order || {};

    tibox.order.getCustomers = function () {
        $.ajax({
            url: '../Customer/Customers',
            type: "GET",
            headers: {
                "Content-Type": "application/json; charset=utf-8"
            },
            success: function (response) {
                response.forEach(function (item) {
                    $('#CustomerId')
                        .append("<option value='" +
                        item.Id + "' >" +
                        item.FirstName + " " + item.LastName +
                        "</option>"
                    );
                }, this);
            },
            error: function (error) {
                alert(error);
            }
        });
    };

    tibox.order.getProducts = function () {
        $.ajax({
            url: '../Product/Products',
            type: "GET",
            headers: {
                "Content-Type": "application/json; charset=utf-8"
            },
            success: function (response) {
                response.forEach(function (item) {
                    $('#product')
                        .append("<option value='" +
                        item.Id + "' >" +
                        item.ProductName +
                        "</option>"
                    );
                }, this);
            },
            error: function (error) {
                alert(error);
            }
        });
    };

    tibox.order.addOrderItem = function () {
        var $row = $("#contentRow").clone().removeAttr('id');
        $('#product', $row).val($('#product').val());
        $('#addItemButton', $row).addClass('remove').val('remove').removeClass('btn-success').addClass('btn-danger');
        $('#product, #unitPrice, #quantity', $row).removeAttr('id');
        $('#orderItemList').append($row);
        $('#product').val(0);
        $('#unitPrice, #quantity').val('');
    }

    tibox.order.save = function(){
        var orderItemList = [];
        
        $('#orderItemList tbody tr').each(function (index, value) {
            var orderItem = {
                ProductId: $('select.product', this).val(),
                UnitPrice: parseFloat($('.unitPrice', this).val()),
                Quantity: parseInt($('.quantity', this).val()),
            };
            orderItemList.push(orderItem);
        });

        var data = {
            Order: {
                OrderDate: $('#Order_OrderDate').val(),
                OrderNumber: $('#Order_OrderNumber').val(),
                CustomerId: $('#CustomerId').val(),
                TotalAmount: $('#Order_TotalAmount').val()
            },
            OrderItems: orderItemList           
        };


        $.ajax({
            url: '/Order/Save',
            type: "POST",
            data: JSON.stringify(data),
            contentType: 'application/json',
            success: function (response) {
                console.log(response);
            },
            error: function (error) {
                alert(error);
            }
        });
    }

    function init() {
        tibox.order.getCustomers();
        tibox.order.getProducts();

        $('#addItemButton').click(tibox.order.addOrderItem);

        //anidacion handler
        $('#orderItemList').on('click', '.remove', function () {
            $(this).parents('tr').remove();
        });

        $('#btnSave').click(tibox.order.save);
    }

    init();

})(window.tibox = window.tibox || {});