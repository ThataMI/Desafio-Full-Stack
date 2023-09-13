using DesafioFullStack.backend.Models.Entities;

namespace DesafioFullStack.backend.Services.Interfaces
{
    public interface ICompaniesService
    {

        Task<List<Companies>> GetAllCompanies();

        Task <Companies?> GetCompaniesById(Guid id);

        Task<List<Companies>> AddCompanies(Companies companies);

        Task<List<Companies>?> UpdateCompanies(Guid id, Companies request);

        Task<List<Companies>?> DeleteCompanies(Guid id);

    }
}
