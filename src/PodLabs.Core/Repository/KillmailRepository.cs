using Microsoft.EntityFrameworkCore;
using PodLabs.Core.Classes.zKillboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PodLabs.Core.Repository
{
    public class KillmailRepository : BaseRepository
    {

        public KillmailRepository(PodLabsContext context) : base(context) { }
        
        public bool Add(Killmail entity)
        {
            if (entity == null) return false;

            try
            {
                _DbContext.Add(entity);
                _DbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return PrintError(e);
            }

            return true;
        }

        public async Task<List<Killmail>> GetAllAsync()
        {
            //return await _DbContext.Killmails.ToListAsync();
            return null;
        }
    }
}
