using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Annarth.Application.Interface.IRepository;
using Annarth.Application.Interface.IService;
using Annarth.Application.Service;
using Annarth.Domain.DTO;
using Annarth.Domain.Entities;
using MongoDB.Bson;

namespace Annarth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeConsultarDTO>> Create(EmployeeCrearDTO employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            await _employeeService.CreateAsync(employee);
            var employeeConsultarDTO = _mapper.Map<EmployeeConsultarDTO>(employee);
            return CreatedAtAction(nameof(GetById), new { id = employeeConsultarDTO.Id }, employeeConsultarDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeConsultarDTO>> Update([FromRoute] string id, [FromBody] EmployeeActulizarDTO employeeDTO)
        {
            if (!ObjectId.TryParse(id, out ObjectId objectId))
            {
                return BadRequest("Invalid ObjectId format");
            }

            var employee = await _employeeService.GetByIdAsync(objectId);
            if (employee == null)
            {
                return NotFound();
            }

            // Aplicar las actualizaciones al objeto existente
            _mapper.Map(employeeDTO, employee);

            var updatedEmployee = await _employeeService.UpdateAsync(employee);

            var employeeConsultarDTO = _mapper.Map<EmployeeConsultarDTO>(updatedEmployee);
            return Ok(employeeConsultarDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId objectId))
            {
                return BadRequest("Invalid ObjectId format");
            }

            if (await _employeeService.DeleteAsync(objectId))
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeConsultarDTO>> GetById(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId objectId))
            {
                return BadRequest("Invalid ObjectId format");
            }

            var employee = await _employeeService.GetByIdAsync(objectId);
            if (employee == null)
            {
                return NotFound();
            }

            var employeeConsultarDTO = _mapper.Map<EmployeeConsultarDTO>(employee);
            return Ok(employeeConsultarDTO);
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeConsultarDTO>>> GetAll()
        {
            var employees = await _employeeService.GetAllAsync();
            var employeeConsultarDTOs = _mapper.Map<List<EmployeeConsultarDTO>>(employees);
            return Ok(employeeConsultarDTOs);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<List<EmployeeConsultarDTO>>> GetFiltered([FromQuery] EmployeeFiltrarDTO filtro)
        {
            var employees = await _employeeService.GetFilteredAsync(filtro);
            var employeeConsultarDTOs = _mapper.Map<List<EmployeeConsultarDTO>>(employees);
            return Ok(employeeConsultarDTOs);
        }
    }
}


