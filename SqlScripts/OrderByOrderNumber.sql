CREATE PROC OrderByOrderNumber (@id INT)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT id
		,OrderDate
		,OrderNumber
		,CustomerId
		,TotalAmount
	FROM [Order]
	WHERE id = @id
END
