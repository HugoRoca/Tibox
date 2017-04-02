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
                        item.Id + "' >"+
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
        var $newRow = $('#orderItems').clone().removeAttr('id');
        $('#product', $newRow).val($('#product').val());

        //Replace add button with remove button
        $('#addItemButton', $newRow).addClass('remove').val('Remove').removeClass('btn-success').addClass('btn-danger');

        //remove id attribute from new clone row
        $('#product,#unitPrice,#quantity', $newRow).removeAttr('id');        
        //append clone row
        $('#orderItemList').append($newRow);

        //clear select data
        $('#product').val('0');
        $('#unitPrice,#quantity').val('');
    };
    
    tibox.order.saveOrder = function () {
        var orderItemList = [];
        $('#orderItemList tbody tr').each(function (index, ele) {
            var orderItem = {
                ProductId: $('select.product', this).val(),
                UnitPrice: parseFloat($('.unitPrice', this).val()),
                Quantity: parseInt($('.quantity', this).val()),
            };
            orderItemList.push(orderItem);
        });

        var data = {
            Order: {
                OrderDate: $('#OrderDate').val().trim(),
                OrderNumber: $('#OrderNumber').val().trim(),
                CustomerId: $('#CustomerId').val().trim(),
                TotalAmount: $('#TotalAmount').val().trim()
            },
            OrderItems: orderItemList
        }

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
        $("input[type='datetime']").datetimepicker();

        $('#addItemButton').click(tibox.order.addOrderItem);

        $('#orderItemList').on('click', '.remove', function () {
            $(this).parents('tr').remove();
        });
    }

    init();

})(window.tibox = window.tibox || {});