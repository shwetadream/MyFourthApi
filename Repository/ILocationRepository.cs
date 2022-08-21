using MyFourthApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFourthApi.Repository
{
    public interface ILocationRepository
    {
        Task<List<LocationModel>> GetAllLocationsAsync();
        Task<LocationModel> GetLocationByIdAsync(int Id);
        Task<int> AddLocationAsync(LocationModel locationModel);
        Task<string> UpdateLocationAsync(int Id, LocationModel locationModel);


    }
}
