-- OrderWithOrderItems 1
CREATE PROC OrderWithOrderItems (@id INT)
AS
BEGIN
	SELECT id
		,OrderDate
		,OrderNumber
		,CustomerId
		,TotalAmount
	FROM [Order]
	WHERE id = @id

	SELECT Id
		,OrderId
		,ProductId
		,UnitPrice
		,Quantity
	FROM OrderItem
	WHERE OrderId = @id
END
