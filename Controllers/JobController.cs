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
    public class JobController : ControllerBase
    {
        private readonly IJobRepository _jobRepository;
        private readonly JobDbContext _jobDbContext;

        public JobController(IJobRepository jobRepository,JobDbContext jobDbContext)
        {
            _jobRepository = jobRepository;
            _jobDbContext = jobDbContext;
        }


        [HttpGet("action")]
        public async Task<IActionResult> GetAllJob()
        {
            var jobs = await _jobRepository.GetAllJobsAsync();
            return Ok(jobs);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetJobById([FromRoute] int id)
        {
            var job = await _jobRepository.GetJobByIdAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            return Ok(job);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddNewLocation([FromBody] JobModel jobModel)
        {
            var id = await _jobRepository.AddJobAsync(jobModel);

            return CreatedAtAction(nameof(GetJobById), new { id = id, Controller = "Job" }, id);

        }

        [HttpPut("[action]/{id}")]

        public async Task<IActionResult> UpdateJob([FromRoute] int id, [FromBody] JobModel jobModel)
        {

            var result = await _jobRepository.UpdateJobAsync(id, jobModel);
            if (result == "success")
            {
                return Ok();
            }
            return NotFound();

        }
    }
}
