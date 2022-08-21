using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFourthApi.Data;
using MyFourthApi.Models;
using MyFourthApi.Repository;
using System.Threading.Tasks;

namespace MyFourthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly JobDbContext _jobDbContext;
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(JobDbContext jobDbContext,IDepartmentRepository departmentRepository)
        {
            _jobDbContext = jobDbContext;
            _departmentRepository = departmentRepository;
        }

        [HttpGet("action")]
        public async Task<IActionResult> GetAllDepartment()
        {
            var departments = await _departmentRepository.GetAllDepartmentsAsync();
            return Ok(departments);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetDepartmentById([FromRoute] int id)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddNewDepartment([FromBody] DepartmentModel departmentModel)
        {
            var id = await _departmentRepository.AddDepartmentAsync(departmentModel);

            return CreatedAtAction(nameof(GetDepartmentById), new { id = id, Controller = "Department" }, id);

        }

        [HttpPut("[action]/{id}")]

        public async Task<IActionResult> UpdateDepartment([FromRoute] int id, [FromBody] DepartmentModel departmentModel)
        {

            var result = await _departmentRepository.UpdateDepartmentAsync(id, departmentModel);
            if (result == "success")
            {
                return Ok();
            }
            return NotFound();

        }
    }
}
