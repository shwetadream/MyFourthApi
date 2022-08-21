using MyFourthApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFourthApi.Repository
{
    public interface IJobRepository
    {
        Task<List<JobModel>> GetAllJobsAsync();
        Task<JobModel> GetJobByIdAsync(int Id);
        Task<int> AddJobAsync(JobModel jobModel);
        Task<string> UpdateJobAsync(int Id, JobModel jobModel);



    }
}
