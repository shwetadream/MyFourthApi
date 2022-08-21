using Microsoft.EntityFrameworkCore;
using MyFourthApi.Data;
using MyFourthApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFourthApi.Repository
{
    public class JobRepository:IJobRepository
    {
        private readonly JobDbContext _jobDbContext;

        public JobRepository(JobDbContext jobDbContext)
        {
            _jobDbContext = jobDbContext;
        }

        public async Task<List<JobModel>> GetAllJobsAsync()
        {


            var records = await _jobDbContext.Jobs.Select(x => new JobModel()
            {
                JobId = x.JobId,
                JobTitle = x.JobTitle,
                JobDescription = x.JobDescription,
                DepartmentId = x.DepartmentId,
                LocationId = x.LocationId,
                PostedDate = x.PostedDate,
                ClosingDate=x.ClosingDate,
            }).ToListAsync();
            return records;

        }

        public async Task<JobModel> GetJobByIdAsync(int Id)
        {


            var record = await _jobDbContext.Jobs.Where(x => x.JobId == Id).Select(x => new JobModel()
            {
                JobId = x.JobId,
                JobTitle = x.JobTitle,
                JobDescription = x.JobDescription,
                DepartmentId = x.DepartmentId,
                LocationId = x.LocationId,
                PostedDate = x.PostedDate,
                ClosingDate = x.ClosingDate
            }).FirstOrDefaultAsync();
            return record;
        }

        public async Task<int> AddJobAsync(JobModel jobModel)
        {
            var add = new Job()
            { 
                JobId = jobModel.JobId,
                JobTitle = jobModel.JobTitle,
                JobDescription = jobModel.JobDescription,
                DepartmentId = jobModel.DepartmentId,
                LocationId = jobModel.LocationId,
                PostedDate = jobModel.PostedDate,
                ClosingDate = jobModel.ClosingDate
            };

            _jobDbContext.Jobs.Add(add);
            await _jobDbContext.SaveChangesAsync();

            return add.JobId;
        }

        public async Task<string> UpdateJobAsync(int Id, JobModel jobModel)
        {

            var update = await _jobDbContext.Jobs.Where(x => x.JobId == Id).FirstOrDefaultAsync();
            if (update != null)
            {
                update.JobTitle = jobModel.JobTitle;
                update.JobDescription = jobModel.JobDescription;
                update.DepartmentId = jobModel.DepartmentId;
                update.LocationId = jobModel.LocationId;
                update.PostedDate = jobModel.PostedDate;
                update.PostedDate = jobModel.PostedDate;

                _jobDbContext.Update(update);
                await _jobDbContext.SaveChangesAsync();
                return "success";
            }
            else
                return "failed";
        }
    }
}
