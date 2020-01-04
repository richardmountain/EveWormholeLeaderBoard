using Microsoft.EntityFrameworkCore;
using PodLabs.Core;
using PodLabs.Core.Classes.Local;
using PodLabs.Core.Classes.Swagger;
using PodLabs.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PodLabs.CorpConsole
{
    class Program
    {
        static PodLabsContext context;
        static List<Corporation> corps = new List<Corporation>();


        static void Main(string[] args)
        {
            try
            {
                ReadSettings();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            try
            {
                var trackerRepo = new TrackerRepository(context);
            
                var tAlliances = trackerRepo.GetAllAsync().Result.Where(x => x.IsAlliance == true).ToList();
                var allianceRepo = new AllianceRepository(context);

                foreach(var tracker in tAlliances)
                {
                    var alliance = new Alliance() { AllianceId = tracker.TrackerId };
                    alliance.PopulateFromEsi();
                    allianceRepo.AddOrUpdate(alliance);
                
                    var corporations = alliance.GetCorporations();

                    corps.AddRange(corporations.Except(corps));
                }

                var tCorporations = trackerRepo.GetAllAsync().Result.Where(x => x.IsAlliance == false).ToList();
                var corporationRepo = new CorporationRepository(context);

                foreach(var tracker in tCorporations)
                {
                    var corporation = new Corporation() { CorporationId = tracker.TrackerId };
                    corps.Add(corporation);
                }

                foreach (var corporation in corps)
                {
                    corporation.PopulateFromEsi();
                    corporationRepo.AddOrUpdate(corporation);
                }

            } catch (Exception e)
            {
                Console.WriteLine("=======================");
                Console.WriteLine(e.Message);
                if (e.InnerException.Message != "")
                {
                    Console.WriteLine(e.InnerException.Message);
                }
                Console.WriteLine("=======================");
            }
        }

        private static void ReadSettings()
        {
            context = new PodLabsContext(new DbContextOptionsBuilder<PodLabsContext>().UseMySQL(Settings.ReadSettings().ConnectionString).Options);
        }
    }
}
