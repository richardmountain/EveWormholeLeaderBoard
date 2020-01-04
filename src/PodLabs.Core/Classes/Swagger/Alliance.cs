using Newtonsoft.Json;
using PodLabs.Core.Classes.Local;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http;
using System.Threading.Tasks;

namespace PodLabs.Core.Classes.Swagger
{
    public class Alliance : EntityBase
    {

        public Alliance() : this(0) { }

        public Alliance(long id) : base(id) { }

        [Column("AllianceId")]
        public long AllianceId { get; set; }

        [Column("CreatorCorporationId")]
        [JsonProperty("creator_corporation_id")]
        public long CreatorCorporationId { get; set; }

        [Column("CreatorId")]
        [JsonProperty("creator_id")]
        public long CreatorId { get; set; }

        [Column("DateFounded")]
        [JsonProperty("date_founded")]
        public DateTime DateFounded { get; set; }

        [Column("ExecutorCorporationId")]
        [JsonProperty("executor_corporation_id")]
        public long? ExecutorCorporationId { get; set; }

        [Column("FactionId")]
        [JsonProperty("faction_id")]
        public long? FactionId { get; set; }

        [Column("Name")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Column("Ticker")]
        [JsonProperty("ticker")]
        public string Ticker { get; set; }

        //public virtual List<Corporation> Corporations { get; set; }

        public override bool Validate()
        {
            return (CreatorCorporationId > 0) &&
                (CreatorId > 0) &&
                (!string.IsNullOrEmpty(Name)) &&
                (!string.IsNullOrEmpty(Ticker));
        }

        public void PopulateFromEsi()
        {
            var client = new HttpClient();
            Task.Run(async () =>
            {
                var results = await client.GetAsync(string.Format("https://esi.evetech.net/latest/alliances/{0}/?datasource=tranquility", this.AllianceId));
                var alliance = JsonConvert.DeserializeObject<Alliance>(await results.Content.ReadAsStringAsync());

                this.CreatorId = alliance.CreatorId;
                this.DateFounded = alliance.DateFounded;
                this.FactionId = alliance.FactionId;
                this.Name = alliance.Name;
                this.Ticker = alliance.Ticker;
                this.CreatorCorporationId = alliance.CreatorCorporationId;
                this.ExecutorCorporationId = alliance.ExecutorCorporationId;
                //this.Corporations = GetCorporations();

                results = null;
                alliance = null;

            }).Wait();
        }

        public List<Corporation> GetCorporations()
        {
            if (this.AllianceId == 0)
                throw new Exception("Alliance Id has not been set!");

            List<Corporation> corporations = new List<Corporation>();

            var client = new HttpClient();
            Task.Run(async () =>
            {
                var results = await client.GetAsync(string.Format("https://esi.evetech.net/latest/alliances/{0}/corporations/?datasource=tranquility", this.AllianceId));
                var corporationIds = JsonConvert.DeserializeObject<List<long>>(await results.Content.ReadAsStringAsync());

                foreach (long id in corporationIds)
                {
                    corporations.Add(new Corporation() { AllianceId = this.AllianceId, CorporationId = id });
                }

                corporationIds = null;
                results = null;

            }).Wait();

            return corporations;
        }
    }
}
