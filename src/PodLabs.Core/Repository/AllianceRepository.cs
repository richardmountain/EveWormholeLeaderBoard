using Microsoft.EntityFrameworkCore;
using PodLabs.Core.Classes.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PodLabs.Core.Repository
{
    public class AllianceRepository : BaseRepository
    {

        public AllianceRepository(PodLabsContext context) : base(context) { }

        public bool Add(Alliance entity)
        {
            if (entity == null) return false;

            try
            {
                _DbContext.Add(entity);
                _DbContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool AddOrUpdate(Alliance entity)
        {
            //if (entity == null) return false;

            //try
            //{
            //    var result = _DbContext.Alliances.Where(x => x.AllianceId == entity.AllianceId).FirstOrDefault();
            //    if (result == null)
            //    {
            //        _DbContext.Add(entity);
            //    }
            //    else
            //    {
            //        result.ExecutorCorporationId = entity.ExecutorCorporationId;
            //        result.FactionId = entity.FactionId;
            //    }
            //    _DbContext.SaveChanges();
            //}
            //catch (Exception)
            //{
            //    return false;
            //}

            return true;
        }

        public async Task<List<Alliance>> GetAllAsync()
        {
            //return await _DbContext.Alliances.ToListAsync();
            return null;
        }
    }
}