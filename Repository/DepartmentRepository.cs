using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFourthApi.Data;
using MyFourthApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace MyFourthApi.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly JobDbContext _jobDbContext;

        public DepartmentRepository(JobDbContext jobDbContext)
        {
            _jobDbContext = jobDbContext;
        }

        public async Task<List<DepartmentModel>> GetAllDepartmentsAsync()
        {


            var records = await _jobDbContext.Departments.Select(x => new DepartmentModel()
            {
                DepartmentId = x.DepartmentId,
                DepartmentTitle = x.DepartmentTitle,

            }).ToListAsync();
            return records;

        }

        public async Task<DepartmentModel> GetDepartmentByIdAsync(int Id)
        {
            

            var record = await _jobDbContext.Departments.Where(x=>x.DepartmentId == Id).Select(x => new DepartmentModel()
            {
                DepartmentId = x.DepartmentId,
                DepartmentTitle = x.DepartmentTitle,

            }).FirstOrDefaultAsync();
            return record;
        }

        public async Task<int> AddDepartmentAsync(DepartmentModel  departmentModel)
        {
            var add = new Department()
            {
                DepartmentTitle = departmentModel.DepartmentTitle,

            };

            _jobDbContext.Departments.Add(add);
            await _jobDbContext.SaveChangesAsync();

            return add.DepartmentId;
        }

        public async Task<string> UpdateDepartmentAsync(int Id, DepartmentModel departmentModel)
        {

            var update = await _jobDbContext.Departments.Where(x => x.DepartmentId == Id).FirstOrDefaultAsync();
            if (update != null)
            {
                update.DepartmentTitle = departmentModel.DepartmentTitle;
               
                _jobDbContext.Update(update);
                await _jobDbContext.SaveChangesAsync();
                return "success";
            }
            else
                return "failed";
        }

       
    }
}
