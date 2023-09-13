using DesafioFullStack.backend.Models.Entities;

namespace DesafioFullStack_Api.Models.Entities
{
    public class CompanySupplier
    {
        public Guid CompanyId { get; set; }

        public Companies Companies { get; set; }

        public Guid SupplierId { get; set; }

        public Suppliers Suppliers { get; set; }
    }
}
