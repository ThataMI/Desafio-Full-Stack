using DesafioFullStack_Api.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace DesafioFullStack.backend.Models.Entities
{
    public class Suppliers 
    {
        public Guid SuppliersId { get; set; }

        public string CnpjCpf { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Cep { get; set; }

        public string? Rg {  get; set; }

        public string Uf { get; set; }

        public DateTime? Birthday { get; set; }

        public IEnumerable<CompanySupplier>? CompaniesSuppliers { get; set; }

    }
}
