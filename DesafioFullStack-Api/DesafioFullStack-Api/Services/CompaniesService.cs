using DesafioFullStack.backend.Context;
using DesafioFullStack.backend.Models.Entities;
using DesafioFullStack.backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesafioFullStack.backend.Services
{
    public class CompaniesService : ICompaniesService
    {

        private readonly DataContext _dataContext;

        public CompaniesService(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }

        public async Task<List<Companies>> AddCompanies(Companies companies)
        {
            _dataContext.Company.Add(companies);
            await _dataContext.SaveChangesAsync();
            return await _dataContext.Company.ToListAsync();        
        }

        public async Task<List<Companies>?> DeleteCompanies(Guid id)
        {
            var company = await _dataContext.Company.FindAsync(id);
            if (company is null)
                return null;

            _dataContext.Company.Remove(company);
            await _dataContext.SaveChangesAsync();

            return await _dataContext.Company.ToListAsync();
        }

        public async Task<List<Companies>> GetAllCompanies()
        {
            var companies = await _dataContext.Company.ToListAsync();
            return companies;
        }

        public async Task<Companies?> GetCompaniesById(Guid id)
        {
            var company = await _dataContext.Company.FirstOrDefaultAsync(x => x.CompaniesId == id);
            return company;
        }

        public async Task<List<Companies>?> UpdateCompanies(Guid id, Companies request)
        {
            var company = await _dataContext.Company.FirstOrDefaultAsync(s => s.CompaniesId == id);
            if (company is null)
                return null;

            company.Cnpj = request.Cnpj;
            company.Name = request.Name;
            company.Cep = request.Cep;


            await _dataContext.SaveChangesAsync();

            return await _dataContext.Company.ToListAsync();
        }
    }
}
