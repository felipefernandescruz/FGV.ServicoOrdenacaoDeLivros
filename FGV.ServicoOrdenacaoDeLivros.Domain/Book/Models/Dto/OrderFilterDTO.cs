using FGV.ServicoOrneacaoDeLivros.InfraStructure.Enum;

namespace FGV.ServicoOrdenacaoDeLivros.Domain.Book.Models.Dto
{
    public class OrderFilterDTO
    {
        public int OrderTypeEnum { get; set; }
        public List<BookDTO> Books { get; set; }
    }
}
