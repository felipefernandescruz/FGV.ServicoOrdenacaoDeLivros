using FGV.ServicoOrdenacaoDeLivros.Domain.Book.Models.Dto;
using FluentValidation;

namespace FGV.ServicoOrdenacaoDeLivros.Domain.Book.Validator
{
    public class OrderFilterValidator : AbstractValidator<OrderFilterDTO>
    {
        public OrderFilterValidator()
        {
            RuleFor(x => x.Books).NotEmpty().NotNull();
            RuleFor(x => x.OrderTypeEnum).NotEmpty().NotNull();
        }
    }
}
