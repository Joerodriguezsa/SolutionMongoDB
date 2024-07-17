using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Annarth.Application.Interface.IService;
using Annarth.Domain.DTO;
using Annarth.Domain.Entities;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;
using Annarth.Application.Interface.IService;

namespace Annarth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<CompanyConsultarDTO>> Create(CompanyCrearDTO companyDTO)
        {
            var company = _mapper.Map<Company>(companyDTO);
            await _companyService.CreateAsync(company);
            var companyConsultarDTO = _mapper.Map<CompanyConsultarDTO>(company);
            return CreatedAtAction(nameof(GetById), new { id = companyConsultarDTO.Id }, companyConsultarDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CompanyConsultarDTO>> Update([FromRoute] string id, [FromBody] CompanyActualizarDTO companyDTO)
        {
            if (!ObjectId.TryParse(id, out ObjectId objectId))
            {
                return BadRequest("Invalid ObjectId format");
            }

            var company = await _companyService.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            // Aplicar las actualizaciones al objeto existente
            _mapper.Map(companyDTO, company);

            var updatedCompany = await _companyService.UpdateAsync(id,company);

            var companyConsultarDTO = _mapper.Map<CompanyConsultarDTO>(updatedCompany);
            return Ok(companyConsultarDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId objectId))
            {
                return BadRequest("Invalid ObjectId format");
            }

            if (await _companyService.DeleteAsync(id))
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyConsultarDTO>> GetById(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId objectId))
            {
                return BadRequest("Invalid ObjectId format");
            }

            var company = await _companyService.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            var companyConsultarDTO = _mapper.Map<CompanyConsultarDTO>(company);
            return Ok(companyConsultarDTO);
        }

        [HttpGet]
        public async Task<ActionResult<List<CompanyConsultarDTO>>> GetAll()
        {
            var companies = await _companyService.GetAllAsync();
            var companyConsultarDTOs = _mapper.Map<List<CompanyConsultarDTO>>(companies);
            return Ok(companyConsultarDTOs);
        }

    }
}
