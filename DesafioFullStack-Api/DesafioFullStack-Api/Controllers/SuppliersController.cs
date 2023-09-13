using DesafioFullStack.backend.Models.Entities;
using DesafioFullStack.backend.Services;
using DesafioFullStack.backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioFullStack_Api.Controllers
{
    [Route("api/suppliers")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
       
        private readonly ISuppliersService _suppliersService;

        public SuppliersController(ISuppliersService suppliersService)
        {
          _suppliersService = suppliersService; 
        }

        [HttpGet("Getall")]
        public async Task<ActionResult<List<Suppliers>>> GetAllSuppliers()
        {
            return await _suppliersService.GetAllSuppliers();
        }

        [HttpGet("Name")]
        public async Task<ActionResult<Suppliers>> GetSupplierName(string name)
        {
            var result = await _suppliersService.GetSupplierByName(name);
            if (result is null)
                return NotFound("Fornecedor não encontrado.");

            return Ok(result);
        }

        [HttpGet("Cnpj")]
        public async Task<ActionResult<Suppliers>> GetSupplierCnpjCpf(string cnpjcpf)
        {
            var result = await _suppliersService.GetSupplierByCnpjCpf(cnpjcpf);
            if (result is null)
                return NotFound("Fornecedor não encontrado.");

            return Ok(result);
        }

        [HttpPost("Post")]
        public async Task<ActionResult<List<Suppliers>>> AddSupplier(Suppliers suppliers)
        {
            var result = await _suppliersService.AddSupplier(suppliers);
            return Ok(result);
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult<List<Suppliers>>> UpdateCompany(Guid id, Suppliers request)
        {
            var result = await _suppliersService.UpdateSupplier(id, request);
            if (result is null)
                return NotFound("Fornecedor não encontrado.");

            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<List<Suppliers>>> DeleteSupplier(Guid id)
        {
            var result = await _suppliersService.DeleteSupplier(id);
            if (result is null)
                return NotFound("Fornecedor não encontrado.");

            return Ok(result);
        }
    }
}
