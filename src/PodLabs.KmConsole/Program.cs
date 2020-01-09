using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PodLabs.Core;
using PodLabs.Core.Classes.Local;
using PodLabs.Core.Classes.zKillboard;
using PodLabs.Core.Extensions;
using PodLabs.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace PodLabs.KmConsole
{
    class Program
    {
        static PodLabsContext context;
        static MySocket mySocket = new MySocket();
        static NLog.Logger logger = Log.InitLogger();

        static void Main(string[] args)
        {
            logger.Debug("PodLabs Killmail Console has been started");

            try
            {
                ReadSettings();
            } catch(Exception e)
            {
                logger.Error(e.Message);
                return;
            }

            mySocket.Connect(new Uri("wss://zkillboard.com:2096"));

            while (mySocket.GetState() != WebSocketState.Open)
            {
                logger.Debug("Trying to connect to zKillboard...");
                Thread.Sleep(1000);
            }

            if (mySocket.GetState() == WebSocketState.Open)
            {
                logger.Debug("Connected to zKillboard...");
                if (mySocket.Subscribe("{\"action\":\"sub\",\"channel\":\"killstream\"}"))
                {
                    Run();
                }
            }
        }

        private static void ReadSettings()
        {
            context = new PodLabsContext(new DbContextOptionsBuilder<PodLabsContext>().UseMySql(Settings.ReadSettings().ConnectionString).Options);
        }

        static void Run()
        {

            if (mySocket.GetState() == WebSocketState.Aborted)
                return;

            try
            {
                while (!mySocket.IsEndOfMessage())
                {
                    mySocket.Receive();
                }

                var km = JsonConvert.DeserializeObject<Killmail>(mySocket.GetMessage());
                bool addKm = false;

                if (km != null)
                {
                    var trackerData = new TrackerRepository(context);
                    List<Tracker> whEntities = new List<Tracker>();

                    Task.Run(async () =>
                    {
                        whEntities = await trackerData.GetAllAsync();
                    }).Wait();

                    // Is Victim?
                    if (whEntities.FindAll(x => x.TrackerId == km.Victim.CorporationId
                    || x.TrackerId == km.Victim.AllianceId).Count > 0)
                    {
                        addKm = true;
                    }

                    if (whEntities.Where(x => km.Attackers.Any(y => y.CorporationId == x.TrackerId
                    || y.AllianceId == x.TrackerId)).ToList().Count > 0)
                    {
                        addKm = true;
                    }

                    if (addKm)
                    {
                        // Add km
                        var killmailRepo = new KillmailRepository(context);
                        killmailRepo.Add(km);
                        killmailRepo = null;
                        logger.Debug(km.Victim.CorporationId);
                    }

                    whEntities = null;
                    trackerData = null;
                    km = null;
                }
            } catch (Exception e)
            {
                logger.Error(e.Message);
                if (e.InnerException.Message != "")
                {
                    logger.Error(e.InnerException.Message);
                }
            }

            Run();
        }
    }
}
