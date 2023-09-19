using FGV.ServicoOrneacaoDeLivros.InfraStructure.Entities;
using FGV.ServicoOrneacaoDeLivros.InfraStructure.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FGV.ServicoOrneacaoDeLivros.InfraStructure.Map
{
    public class OrderTypeMap : IEntityTypeConfiguration<OrderType>
    {
        public void Configure(EntityTypeBuilder<OrderType> builder)
        {
            builder.HasData(
              new OrderType()
              {
                  Id = (int)OrderTypeEnum.TitleAsc,
                  Name = OrderTypeEnum.TitleAsc.ToString()
              },
              new OrderType()
              {
                  Id = (int)OrderTypeEnum.AuthorAscTitleDesc,
                  Name = OrderTypeEnum.AuthorAscTitleDesc.ToString()
              },
              new OrderType()
              {
                  Id = (int)OrderTypeEnum.EditionDescAuthorDescTituloAsc,
                  Name = OrderTypeEnum.EditionDescAuthorDescTituloAsc.ToString()
              });
        }
    }
}
