using DesafioFullStack_Api.Models.Entities;
using System.Collections;

namespace DesafioFullStack.backend.Models.Entities
{
    public class Companies 
    {
        public Guid CompaniesId { get; set; }
        public string Cnpj { get; set; }

        public string Name { get; set; }

        public string Cep { get; set; }

        public IEnumerable<CompanySupplier>? CompaniesSuppliers { get; set; }




    }
}
