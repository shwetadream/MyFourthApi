using MyFourthApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFourthApi.Repository
{
    public interface IDepartmentRepository
    {
        Task<List<DepartmentModel>> GetAllDepartmentsAsync();
        Task<DepartmentModel> GetDepartmentByIdAsync(int Id);
        Task<int> AddDepartmentAsync(DepartmentModel departmentModel);
        Task<string> UpdateDepartmentAsync(int Id, DepartmentModel departmentModel);
    }
}
