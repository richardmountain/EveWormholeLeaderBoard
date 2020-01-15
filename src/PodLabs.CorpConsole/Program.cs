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
using System.Threading.Tasks;

namespace PodLabs.CorpConsole
{
    class Program
    {
        static PodLabsContext context;
        static List<Corporation> corps = new List<Corporation>();
        static NLog.Logger logger = Log.InitLogger();


        static void Main(string[] args)
        {
            try
            {
                string connectionString = args.FirstOrDefault() ?? Settings.ReadSettings().ConnectionString;
                logger.Debug("Starting Db update process...");

                UpdateDatabaseAsync(connectionString);

                logger.Debug("Db update process complete...");

                logger.Debug("Reading settings file...");
                ReadSettings(connectionString);
                logger.Debug("Settings file has been read and understood!");
            }
            catch (Exception e)
            {
                var st = new StackTrace(e, true);
                var frame = st.GetFrame(0);
                logger.Error(e.Message);
                return;
            }

            try
            {
                var trackerRepo = new TrackerRepository(context);

                logger.Debug("Getting list of Alliance Ids...");

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

                logger.Debug("Getting list of Corporation Ids...");

                var tCorporations = trackerRepo.GetAllAsync().Result.Where(x => x.IsAlliance == false).ToList();
                var corporationRepo = new CorporationRepository(context);

                foreach(var tracker in tCorporations)
                {
                    var corporation = new Corporation() { CorporationId = tracker.TrackerId };
                    corps.Add(corporation);
                }

                logger.Debug("Updating Corporation table with new data...");

                foreach (var corporation in corps)
                {
                    corporation.PopulateFromEsi();
                    corporationRepo.AddOrUpdate(corporation);
                }

            } catch (Exception e)
            {
                logger.Error(e.Message);
                if (e.InnerException != null)
                {
                    if (e.InnerException.Message != "")
                        logger.Error(e.InnerException.Message);
                }
            }
        }

        private static void ReadSettings(string connectionString)
        {
            context = new PodLabsContext(new DbContextOptionsBuilder<PodLabsContext>().UseMySql(connectionString).Options);
        }

        private static void UpdateDatabaseAsync(string connectionString)
        {
            try
            {
                var upgrader =
                    DeployChanges.To
                        .MySqlDatabase(connectionString)
                        .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                        .LogToConsole()
                        .Build();

                var result = upgrader.PerformUpgrade();

                if (!result.Successful)
                {
                    logger.Error(result.Error);
                    return;
                }

            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                if (e.InnerException != null)
                {
                    if (e.InnerException.Message != "")
                        logger.Error(e.InnerException.Message);
                }
            }

            logger.Debug("Success!");
        }
    }
}
