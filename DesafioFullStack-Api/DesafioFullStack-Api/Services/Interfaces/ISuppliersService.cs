using DesafioFullStack.backend.Models.Entities;

namespace DesafioFullStack.backend.Services.Interfaces
{
    public interface ISuppliersService
    {

        Task<List<Suppliers>> GetAllSuppliers();

        Task<Suppliers?> GetSupplierByName(string name);
        Task<Suppliers?> GetSupplierByCnpjCpf(string cnpjcpf);

        Task<List<Suppliers>> AddSupplier(Suppliers suppliers);

        Task<List<Suppliers>?> UpdateSupplier(Guid id, Suppliers request);

        Task<List<Suppliers>?> DeleteSupplier(Guid id);

    }
}
