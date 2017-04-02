using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Tibox.Models;
using System;

namespace Tibox.Repository.Northwind
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public Order OrderByOrderNumber(string orderNumber)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@orderNumber", orderNumber);

                return connection
                    .QueryFirst<Order>("dbo.OrderByOrderNumber",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public Order OrderWithOrderItems(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@orderId", id);

                using (var multiple =
                    connection.QueryMultiple("dbo.OrderWithOrderItems",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure))
                {
                    var order = multiple.Read<Order>().Single();
                    order.OrderItems = multiple.Read<OrderItem>();
                    return order;
                }
            }
        }

        public bool SaverOrderAndOrderItems(Order order, IEnumerable<OrderItem> items)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var id = (int)connection.Insert(order, transaction);
                        items.Select(c => { c.OrderId = id; return c; }).ToList();
                        foreach (var orderItem in items)
                        {
                            connection.Insert(orderItem, transaction);
                        }
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
