using FGV.ServicoOrdenacaoDeLivros.Domain.Book.Models.Dto;
using FGV.ServicoOrdenacaoDeLivros.Domain.Book.Responses;

namespace FGV.ServicoOrdenacaoDeLivros.Domain.Book
{
    public interface IBookService
    {
        Task<List<BookResponse>> OrderBooksByFilter(OrderFilterDTO orderFilterDTO);        
    }
}
