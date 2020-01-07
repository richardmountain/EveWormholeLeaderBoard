using DbUp;
using Microsoft.EntityFrameworkCore;
using PodLabs.Core;
using PodLabs.Core.Classes.Local;
using PodLabs.Core.Classes.Swagger;
using PodLabs.Core.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

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
                UpdateDatabase();

                ReadSettings();
            }
            catch (Exception e)
            {
                var st = new StackTrace(e, true);
                var frame = st.GetFrame(0);
                Console.WriteLine(e.Message);
                Console.WriteLine("Line: " + frame.GetFileLineNumber());
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
            context = new PodLabsContext(new DbContextOptionsBuilder<PodLabsContext>().UseMySql(Settings.ReadSettings().ConnectionString).Options);
        }

        private static void UpdateDatabase()
        {
            var connectionString = Settings.ReadSettings().ConnectionString;

            var upgrader =
                DeployChanges.To
                    .MySqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
        }
    }
}
