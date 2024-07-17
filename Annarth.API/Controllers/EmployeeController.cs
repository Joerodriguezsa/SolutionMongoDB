using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Annarth.Application.Interface.IRepository;
using Annarth.Application.Interface.IService;
using Annarth.Application.Service;
using Annarth.Domain.DTO;
using Annarth.Domain.Entities;

namespace Annarth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _EmployeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService EmployeeService, IMapper mapper)
        {
            _EmployeeService = EmployeeService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeConsultarDTO>> Create(EmployeeCrearDTO EmployeeDTO)
        {
            var Employee = _mapper.Map<Employee>(EmployeeDTO);
            await _EmployeeService.CreateAsync(Employee);
            var EmployeeConsultarDTO = _mapper.Map<EmployeeConsultarDTO>(Employee);
            return CreatedAtAction(nameof(GetById), new { id = EmployeeConsultarDTO.Id }, EmployeeConsultarDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeConsultarDTO>> Update(int id, EmployeeActulizarDTO EmployeeDTO)
        {
            var Employee = _mapper.Map<Employee>(EmployeeDTO);
            Employee.Id = id;

            var updatedEmployee = await _EmployeeService.UpdateAsync(Employee);
            if (updatedEmployee != null)
            {
                var EmployeeConsultarDTO = _mapper.Map<EmployeeConsultarDTO>(updatedEmployee);
                return Ok(EmployeeConsultarDTO);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _EmployeeService.DeleteAsync(id))
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeConsultarDTO>> GetById(int id)
        {
            var Employee = await _EmployeeService.GetByIdAsync(id);
            if (Employee == null)
            {
                return NotFound();
            }
            var EmployeeConsultarDTO = _mapper.Map<EmployeeConsultarDTO>(Employee);
            return Ok(EmployeeConsultarDTO);
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeConsultarDTO>>> GetAll()
        {
            var Employeees = await _EmployeeService.GetAllAsync();
            var EmployeeConsultarDTOs = _mapper.Map<List<EmployeeConsultarDTO>>(Employeees);
            return Ok(EmployeeConsultarDTOs);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<List<EmployeeConsultarDTO>>> GetFiltered([FromQuery] EmployeeFiltrarDTO filtro)
        {
            var Employees = await _EmployeeService.GetFilteredAsync(filtro);
            var EmployeeConsultarDTOs = _mapper.Map<List<EmployeeConsultarDTO>>(Employees);
            return Ok(EmployeeConsultarDTOs);
        }
    }
}
