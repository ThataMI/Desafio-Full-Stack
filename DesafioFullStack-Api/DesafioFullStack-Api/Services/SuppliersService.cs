using DesafioFullStack.backend.Context;
using DesafioFullStack.backend.Models.Entities;
using DesafioFullStack.backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesafioFullStack.backend.Services
{
    public class SuppliersService: ISuppliersService
    {
        private readonly DataContext _dataContext;

        public SuppliersService(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }

        public async Task<List<Suppliers>> AddSupplier(Suppliers suppliers)
        {
            _dataContext.Supplier.Add(suppliers);
            await _dataContext.SaveChangesAsync();
            return await _dataContext.Supplier.ToListAsync();
        }


        public async Task<List<Suppliers>?> DeleteSupplier(Guid id)
        {
            var supplier = await _dataContext.Supplier.FindAsync(id);
            if (supplier is null)
                return null;

            _dataContext.Supplier.Remove(supplier);
            await _dataContext.SaveChangesAsync();

            return await _dataContext.Supplier.ToListAsync();
        }

        public async Task<List<Suppliers>> GetAllSuppliers()
        {
            var suppliers = await _dataContext.Supplier.ToListAsync(); 
            return suppliers;
        }

        public async Task<Suppliers?> GetSupplierByName(string name)
        {
            var supplier = await _dataContext.Supplier.FirstOrDefaultAsync(x => x.Name == name);
            return supplier;
        }
        public async Task<Suppliers?> GetSupplierByCnpjCpf(string cnpjcpf)
        {
            var company = await _dataContext.Supplier.FirstOrDefaultAsync(x => x.CnpjCpf == cnpjcpf);
            return company;
        }

        public async Task<List<Suppliers>?> UpdateSupplier(Guid id, Suppliers request)
        {
            var supplier = await _dataContext.Supplier.FindAsync(id);
            if (supplier is null)
                return null;

            supplier.CnpjCpf = request.CnpjCpf;
            supplier.Name = request.Name;
            supplier.Email = request.Email;
            supplier.Cep = request.Cep;
            supplier.Birthday = request.Birthday;
            supplier.Rg = request.Rg;
            supplier.Uf = request.Uf;

            await _dataContext.SaveChangesAsync();

            return await _dataContext.Supplier.ToListAsync();
        }
    }
}
