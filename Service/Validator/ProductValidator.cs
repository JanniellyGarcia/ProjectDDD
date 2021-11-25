using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validator
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Por favor, insira o nome.")
                .NotNull().WithMessage("Por favor, insira o nome.");

            RuleFor(c => c.Price)
                .NotEmpty().WithMessage("Por favor, insira o preço.")
                .NotNull().WithMessage("Por favor, insira o preço.");

            RuleFor(c => c.Price)
                .NotEmpty().WithMessage("Por favor, insira o peso.")
                .NotNull().WithMessage("Por favor, insira o peso.");


        }
    }
}
