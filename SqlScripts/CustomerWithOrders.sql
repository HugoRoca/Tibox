CREATE PROCEDURE CustomerWithOrders
	@customerId int
AS
BEGIN	
	SET NOCOUNT ON;
	SELECT [Id]
      ,[FirstName]
      ,[LastName]
      ,[City]
      ,[Country]
      ,[Phone]
	  FROM dbo.Customer
	  WHERE Id=@customerId

	SELECT   Id
			,OrderDate
			,OrderNumber
			,CustomerId
			,TotalAmount
	FROM dbo.[Order] 
	WHERE CustomerId=@customerId
END
GO
