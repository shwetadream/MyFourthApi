using Microsoft.EntityFrameworkCore;
using MyFourthApi.Data;
using MyFourthApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFourthApi.Repository
{
    public class LocationRepository:ILocationRepository
    {
        private readonly JobDbContext _jobDbContext;

        public LocationRepository(JobDbContext jobDbContext)
        {
            _jobDbContext = jobDbContext;
        }

        public async Task<List<LocationModel>> GetAllLocationsAsync()
        {


            var records = await _jobDbContext.Locations.Select(x => new LocationModel()
            {
                LocationId = x.LocationId,
                LocationTitle = x.LocationTitle,
                LocationCity=x.LocationCity,
                LocationState=x.LocationState,
                LocationCountry=x.LocationCountry,
                LocationZip=x.LocationZip

            }).ToListAsync();
            return records;

        }

        public async Task<LocationModel> GetLocationByIdAsync(int Id)
        {


            var record = await _jobDbContext.Locations.Where(x => x.LocationId == Id).Select(x => new LocationModel()
            {
                LocationId = x.LocationId,
                LocationTitle = x.LocationTitle,
                LocationCity=x.LocationCity,
                LocationState=x.LocationState,
                LocationCountry=x.LocationCountry,
                LocationZip=x.LocationZip
            }).FirstOrDefaultAsync();
            return record;
        }

        public async Task<int> AddLocationAsync(LocationModel locationModel)
        {
            var add = new Location()
            {
               LocationTitle = locationModel.LocationTitle,
               LocationCity=locationModel.LocationCity,
               LocationState=locationModel.LocationState,
               LocationCountry=locationModel.LocationCountry,
               LocationZip=locationModel.LocationZip

            };

            _jobDbContext.Locations.Add(add);
            await _jobDbContext.SaveChangesAsync();

            return add.LocationId;
        }

        public async Task<string> UpdateLocationAsync(int Id,LocationModel locationModel)
        {

            var update = await _jobDbContext.Locations.Where(x => x.LocationId == Id).FirstOrDefaultAsync();
            if (update != null)
            {
                update.LocationTitle = locationModel.LocationTitle;
                update.LocationCity = locationModel.LocationCity;
                update.LocationState = locationModel.LocationState;
                update.LocationCountry = locationModel.LocationCountry;
                update.LocationZip = locationModel.LocationZip;


                _jobDbContext.Update(update);
                await _jobDbContext.SaveChangesAsync();
                return "success";
            }
            else
                return "failed";
        }

    }


}
