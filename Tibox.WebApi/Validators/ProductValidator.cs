﻿using FluentValidation;
using Tibox.Models;

namespace Tibox.WebApi.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            ValidatorOptions.CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(p => p.ProductName).NotNull().NotEmpty().WithMessage("El nombre del producto es requerido");
            RuleFor(p => p.SupplierId).NotNull().GreaterThan(0).WithName("Proveedor").WithMessage("No a seleccionado un proveedor valido");
            When(p => p.UnitPrice > 0, () =>
               {
                   RuleFor(p => p.UnitPrice).LessThan(100000).WithName("Precio unitario").WithMessage("Costo muy elevado");
               });
            When(p => string.IsNullOrWhiteSpace(p.Package), () => {
                RuleFor(p => p.Package).Length(1, 30).WithMessage("El nombre del paquete exedio lo permitido");
            });
        }
    }
}