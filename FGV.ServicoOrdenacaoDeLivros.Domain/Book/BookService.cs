using AutoMapper;
using FGV.ServicoOrdenacaoDeLivros.Domain.Book.Models.Dto;
using FGV.ServicoOrdenacaoDeLivros.Domain.Book.Responses;
using FGV.ServicoOrdenacaoDeLivros.Domain.Extentions;
using FGV.ServicoOrneacaoDeLivros.InfraStructure.Enum;
using FluentValidation;

namespace FGV.ServicoOrdenacaoDeLivros.Domain.Book
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IValidator<OrderFilterDTO> _validator;

        public BookService(IValidator<OrderFilterDTO> validator, IMapper mapper)
        {
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<List<BookResponse>> OrderBooksByFilter(OrderFilterDTO orderFilterDTO)
        {
            var validator = await _validator.ValidateAsync(orderFilterDTO);
            if (validator.IsValid is false)
                throw new BadRequestException(validator.Errors);

            var booksToOrder = orderFilterDTO.Books;
            if (booksToOrder == null)
                throw new BadRequestException("Não há livros para buscar");

            if (booksToOrder.Count == 0)
                return new List<BookResponse>();

            
                switch (orderFilterDTO.OrderTypeEnum)
            {
                case (int)OrderTypeEnum.TitleAsc:
                    booksToOrder = orderByTitle(booksToOrder);
                    break;

                case (int)OrderTypeEnum.AuthorAscTitleDesc:
                    booksToOrder = orderByAuthorAscTitleDesc(booksToOrder);
                    break;
                case (int)OrderTypeEnum.EditionDescAuthorDescTituloAsc:
                    booksToOrder = orderByEditionDescAuthorDescTituloAsc(booksToOrder);
                    break;

                default:
                    throw new BadRequestException("Não há essa opção de filtro");
                    break;
            }

            var response = _mapper.Map<List<BookResponse>>(booksToOrder);

            return response;
        }

        private List<BookDTO> orderByTitle(List<BookDTO> booksToOrder)
        {
            return booksToOrder.OrderBy(item => item.Title).ToList();
        }

        private List<BookDTO> orderByAuthorAscTitleDesc(List<BookDTO> booksToOrder)
        {
            return booksToOrder.OrderBy(item => item.Author)
                .ThenByDescending(item => item.Title).ToList();
        }

        private List<BookDTO> orderByEditionDescAuthorDescTituloAsc(List<BookDTO> booksToOrder)
        {
            return booksToOrder.OrderByDescending(item => item.Edition)
                .ThenByDescending(item => item.Author)
                .ThenBy(item => item.Title).ToList();
        }

    }
}
