using FGV.ServicoOrdenacaoDeLivros.Domain;
using FGV.ServicoOrdenacaoDeLivros.Domain.Book;
using FGV.ServicoOrdenacaoDeLivros.Domain.Book.Models.Dto;
using FGV.ServicoOrdenacaoDeLivros.Domain.Book.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FGV.ServicoOrdenacaoDeLivros.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse<List<BookResponse>>>> OrderBooks([FromBody]  OrderFilterDTO orderfilterDTO)
        {
            var response = new APIResponse<List<BookResponse>>();
            try
            {
                response.Result = await _bookService.OrderBooksByFilter(orderfilterDTO);
                response.StatusCode = HttpStatusCode.OK;
                response.IsSuccess = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>() { ex.ToString() };
                return BadRequest(response);
            }
        }
    }
}
