using DesafioFullStack.backend.Models.Entities;
using DesafioFullStack_Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioFullStack.backend.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) 
        {
        }

        public DbSet<Companies> Company { get; set; }
        public DbSet<Suppliers> Supplier { get; set; }
        public DbSet<CompanySupplier> CompaniesSuppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<CompanySupplier>()
             .HasKey(AD => new { AD.CompanyId, AD.SupplierId });

            builder.Entity<CompanySupplier>()
                .HasOne(AD => AD.Companies)
                .WithMany(AD => AD.CompaniesSuppliers)
                .HasForeignKey(AD => AD.CompanyId);

            builder.Entity<CompanySupplier>()
                .HasOne(AD => AD.Suppliers)
                .WithMany(AD => AD.CompaniesSuppliers)
                .HasForeignKey(AD => AD.SupplierId);

            builder.Entity<Companies>()
                .HasData(
                    new Companies{CompaniesId = Guid.Parse("a13c546e0c154a1fb52209dcb6e5529f"), Cnpj = "56269892000185",Name = "Empresa1",Cep = "83514320" },
                    new Companies{CompaniesId = Guid.Parse("744fe497d126411aa83a031f31bd73f7"),Cnpj = "54413724000196",Name = "Empresa2",Cep = "05439010" },
                    new Companies{CompaniesId = Guid.Parse("d461d4d46d47416c9fafbfc5786c1a22"), Cnpj = "75782208000109", Name = "Empresa3",Cep = "04089972" }
                );

            builder.Entity<Suppliers>()
                .HasData(
                    new Suppliers{SuppliersId = Guid.Parse("41886c1d402c4425979a4fa18f5f1696"), CnpjCpf = "34994179018",Name = "Fornecedor1", Email = "fornecedor1@gmail.com", Cep = "84910970", Birthday = DateTime.Now, Rg = "475169621", Uf = "PR" },
                    new Suppliers{SuppliersId = Guid.Parse("2eaf8ee97d3e4dfba9d4196421b2b29a"),CnpjCpf = "14090702046",Name = "Fornecedor2",Email = "fornecedor2@hmail.com", Cep = "04176000", Birthday = DateTime.Now, Rg = "348235963", Uf = "SP" },
                    new Suppliers{SuppliersId = Guid.Parse("7d7bfc4cf67e45918ffebcadda6d4e17"), CnpjCpf = "70357563000117", Name = "Fornecedor3",Email = "fornecedor3@gmail.com",Cep = "05545160", Uf = "SP"}
                );

            builder.Entity<CompanySupplier>()
                .HasData(
                    new CompanySupplier{CompanyId = Guid.Parse("a13c546e0c154a1fb52209dcb6e5529f"), SupplierId = Guid.Parse("2eaf8ee97d3e4dfba9d4196421b2b29a") },
                    new CompanySupplier{CompanyId = Guid.Parse("a13c546e0c154a1fb52209dcb6e5529f"), SupplierId = Guid.Parse("7d7bfc4cf67e45918ffebcadda6d4e17") },
                    new CompanySupplier{CompanyId = Guid.Parse("d461d4d46d47416c9fafbfc5786c1a22"), SupplierId = Guid.Parse("41886c1d402c4425979a4fa18f5f1696") }
                );

        }

    }
}
