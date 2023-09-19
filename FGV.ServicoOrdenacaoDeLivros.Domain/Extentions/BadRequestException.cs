using FluentValidation.Results;

namespace FGV.ServicoOrdenacaoDeLivros.Domain.Extentions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message)
       : base(message) { }

        public BadRequestException(IEnumerable<ValidationFailure> failures)
        : base(string.Join("; ", failures.Select(x => x.ErrorMessage))) { }
    }
}
