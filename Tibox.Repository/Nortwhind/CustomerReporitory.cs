using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Tibox.Models;
using Tibox.Repository;

namespace Tibox.Repository.Nortwhind
{
    public class CustomerReporitory : BaseRepository<Customer>, ICustomerRepository
    {
        public Customer CustomerWithOrders(int id)
        {
            using (var connection  = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@customerId", id);

                using (var multiple = connection.QueryMultiple("CustomerWithOrders", 
                    parameters, 
                    commandType: CommandType.StoredProcedure))
                {
                    var customer = multiple.Read<Customer>().Single();
                    customer.Orders = multiple.Read<Order>();
                    return customer;
                }
            }
        }

        public Customer SearchByNames(string firstName, string lastName)
        {
            using (var conecction = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@firstName", firstName);
                parameters.Add("@lastName", lastName);

                return conecction.QueryFirst<Customer>("CustomerSearchByNames", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
