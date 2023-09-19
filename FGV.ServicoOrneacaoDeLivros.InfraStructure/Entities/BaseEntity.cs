using FGV.ServicoOrneacaoDeLivros.InfraStructure.Extentions;

namespace FGV.ServicoOrneacaoDeLivros.InfraStructure.Entities
{
    public class BaseEntity
    {
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }

        public BaseEntity()
        {
            CreatedAt = DateTime.Now.BrazilTimeZone();
        }

        internal bool IsDeleted()
        {
            return DeletedAt.HasValue;
        }

        internal void MarkAsDeleted()
        {
            DeletedAt = DateTime.Now.BrazilTimeZone();
        }

        internal void MarkAsNotDeleted()
        {
            DeletedAt = null;
        }

        internal void MarkAsUpdated()
        {
            UpdatedAt = DateTime.Now.BrazilTimeZone();
        }

        protected void ChangeCreatedAt(DateTime createdAt)
        {
            CreatedAt = createdAt;
        }

        protected void ChangeUpdatedAt(DateTime? updatedAt)
        {
            UpdatedAt = updatedAt;
        }
    }
}
