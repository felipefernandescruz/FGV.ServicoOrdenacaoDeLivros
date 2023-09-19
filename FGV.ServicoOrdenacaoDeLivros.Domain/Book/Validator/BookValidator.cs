using FGV.ServicoOrdenacaoDeLivros.Domain.Book.Models.Dto;
using FluentValidation;

namespace FGV.ServicoOrdenacaoDeLivros.Domain.Book.Validator
{
    public class BookValidator : AbstractValidator<BookDTO>
    {
        public BookValidator()
        {
            RuleFor(x => x.Title).NotEmpty().NotNull().MaximumLength(80);
            RuleFor(x => x.Author).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(x => x.Edition).NotEmpty().NotNull();
        }
    }
}
