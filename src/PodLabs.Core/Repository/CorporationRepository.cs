using Microsoft.EntityFrameworkCore;
using PodLabs.Core.Classes.Swagger;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PodLabs.Core.Repository
{
    public class CorporationRepository : BaseRepository
    {

        public CorporationRepository(PodLabsContext context) : base(context) { }

        public bool Add(Corporation entity)
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

        public bool AddOrUpdate(Corporation entity)
        {
            if (entity == null) return false;
            
            try
            {
                var result = _DbContext.Corporations.Where(x => x.CorporationId == entity.CorporationId).FirstOrDefault();
                if (result == null)
                {
                    _DbContext.Add(entity);
                } 
                else
                {
                    result.AllianceId = entity.AllianceId;
                    result.CeoId = entity.CeoId;
                    result.CreatorId = entity.CreatorId;
                    result.Description = entity.Description;
                    result.FactionId = entity.FactionId;
                    result.HomeStationId = entity.HomeStationId;
                    result.MemberCount = entity.MemberCount;
                    result.Shares = entity.Shares;
                    result.TaxRate = entity.TaxRate;
                    result.Url = entity.Url;
                    result.WarEligible = entity.WarEligible;
                }
                _DbContext.SaveChanges();
            }catch (Exception)
            {
                return false;
            }
            
            return true;
        }

        public async Task<List<Corporation>> GetAllAsync()
        {
            return await _DbContext.Corporations.ToListAsync();
        }
    }
}