using Microsoft.EntityFrameworkCore;
using PodLabs.Core.Classes.Local;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PodLabs.Core.Repository
{
    public class TrackerRepository : BaseRepository
    {

        public TrackerRepository(PodLabsContext context) : base(context) { }

        public bool Add(Tracker entity)
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

        public async Task<List<Tracker>> GetAllAsync()
        {
            //return await _DbContext.Trackers.ToListAsync();
            return null;
        }
    }
}
