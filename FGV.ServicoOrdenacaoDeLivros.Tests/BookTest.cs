using AutoMapper;
using FGV.ServicoOrdenacaoDeLivros.Domain;
using FGV.ServicoOrdenacaoDeLivros.Domain.Book;
using FGV.ServicoOrdenacaoDeLivros.Domain.Book.Models.Dto;
using FGV.ServicoOrdenacaoDeLivros.Domain.Extentions;
using FGV.ServicoOrneacaoDeLivros.InfraStructure.Enum;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Xunit;

namespace FGV.ServicoOrdenacaoDeLivros.Tests
{
    public class BookTest
    {
        private readonly Mock<IValidator<OrderFilterDTO>> _validatorMock;
        private readonly IMapper _mapper;
        private readonly BookService _bookService;
        protected List<BookDTO> _books;

        public BookTest()
        {
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<MappingConfig>());
            _mapper = mapperConfig.CreateMapper();
            _validatorMock = new Mock<IValidator<OrderFilterDTO>>();
            _bookService = new BookService(_validatorMock.Object, _mapper);
            _books = MockBooks();
           
        }

        [Fact]
        public async Task NotificarErroQuandoNaoInformarLivros()
        {
            //Dado
            var request = new OrderFilterDTO();
            request.Books = null;

            _validatorMock.Setup(v => v.ValidateAsync(request, default))
                .ReturnsAsync(new ValidationResult());

            //Quando 
            var ex = await Assert.ThrowsAsync<BadRequestException>(() => _bookService.OrderBooksByFilter(request));

            //Então
            Assert.IsType<BadRequestException>(ex);
        }

        [Fact]
        public async Task NotificarQuandoInformarLivrosVazio()
        {
            //Dado
            var request = new OrderFilterDTO();
            request.Books = new List<BookDTO>();

            _validatorMock.Setup(v => v.ValidateAsync(request, default))
                .ReturnsAsync(new ValidationResult());

            //Quando 
            var response = await _bookService.OrderBooksByFilter(request);

            //Então
            Assert.Empty(response);
        }

        [Fact]
        public async Task OrderBooksByFilter_WhenOrderTypeEnumIsTitleAsc_OrdersBooksByTitle()
        {
            // Arrange
            var request = new OrderFilterDTO { Books = _books, OrderTypeEnum = (int)OrderTypeEnum.TitleAsc };

            // Configura o mock para retornar um resultado de validação válido
            _validatorMock.Setup(v => v.ValidateAsync(request, default))
                .ReturnsAsync(new ValidationResult());

            // Act
            var result = await _bookService.OrderBooksByFilter(request);

            // Assert
            Assert.Equal(3, result[0].Id);
            Assert.Equal(4, result[1].Id);
            Assert.Equal(1, result[2].Id);
            Assert.Equal(2, result[3].Id);
        }

        [Fact]
        public async Task OrderBooksByFilter_WhenOrderTypeEnumIsAuthorAscTitleDesc_OrdersBooksByAuthorAscTitleDesc()
        {
            // Arrange
            var request = new OrderFilterDTO { Books = _books, OrderTypeEnum = (int)OrderTypeEnum.AuthorAscTitleDesc };

            // Configura o mock para retornar um resultado de validação válido
            _validatorMock.Setup(v => v.ValidateAsync(request, default))
                .ReturnsAsync(new ValidationResult());

            // Act
            var result = await _bookService.OrderBooksByFilter(request);

            // Assert
            Assert.Equal(1, result[0].Id);
            Assert.Equal(4, result[1].Id);
            Assert.Equal(3, result[2].Id);
            Assert.Equal(2, result[3].Id);
        }

        [Fact]
        public async Task OrderBooksByFilter_WhenOrderTypeEnumIsEditionDescAuthorDescTituloAsc_OrdersBooksByEditionDescAuthorDescTituloAsc()
        {
            // Arrange
            var request = new OrderFilterDTO { Books = _books, OrderTypeEnum = (int)OrderTypeEnum.EditionDescAuthorDescTituloAsc };

            // Configura o mock para retornar um resultado de validação válido
            _validatorMock.Setup(v => v.ValidateAsync(request, default))
                .ReturnsAsync(new ValidationResult());

            // Act
            var result = await _bookService.OrderBooksByFilter(request);

            // Assert
            Assert.Equal(4, result[0].Id);
            Assert.Equal(1, result[1].Id);
            Assert.Equal(3, result[2].Id);
            Assert.Equal(2, result[3].Id);
        }
        private List<BookDTO> MockBooks()
        {
            return new List<BookDTO> {
                new BookDTO { Id = 1, Title = "Java How to Program", Author = "Deitel & Deitel", Edition = 2007 },
                new BookDTO { Id = 2, Title = "Patterns of Enterprise Application Architecture", Author = "Martin Fowler", Edition = 2002 },
                new BookDTO { Id = 3, Title = "Head First Design Patterns", Author = "Elisabeth Freeman", Edition = 2004 },
                new BookDTO { Id = 4, Title = "Internet & World Wide Web: How to Program", Author = "Deitel & Deitel", Edition = 2007 }
            };
        }
    }
}
