﻿using Tibox.Models;
using Tibox.Repository;
using Tibox.Repository.Nortwhind;

namespace Tibox.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }

        IOrderRepository Orders { get; }

        IRepository<OrderItem> OrderItems { get; }

        IRepository<Product> Products { get; }

        IRepository<Supplier> Suppliers { get; }
    }
}
