using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;

namespace Tibox.Repository.Nortwhind
{
    public interface IOrderRepository: IRepository<Order>
    {
        Order SearchOrderByOrderNumber(int id);

        Order OrderWithOrdersItems(int id);
    }
}
