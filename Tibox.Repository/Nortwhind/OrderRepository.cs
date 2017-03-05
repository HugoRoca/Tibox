using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Tibox.Models;

namespace Tibox.Repository.Nortwhind
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public Order OrderWithOrdersItems(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);

                using (var multiple = connection.QueryMultiple("OrderWithOrderItems",
                    parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    var orders = multiple.Read<Order>().Single();
                    orders.OrderItems = multiple.Read<OrderItem>();
                    return orders;
                }
            }
        }

        public Order SearchOrderByOrderNumber(int id)
        {
            using (var conecction = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);

                return conecction.QueryFirst<Order>("OrderByOrderNumber", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
