using AutoMapper;
using FGV.ServicoOrdenacaoDeLivros.Domain.Book.Models.Dto;
using FGV.ServicoOrdenacaoDeLivros.Domain.Book.Responses;

namespace FGV.ServicoOrdenacaoDeLivros.Domain
{

    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<BookResponse, BookDTO>().ReverseMap();
        }
    }
}

