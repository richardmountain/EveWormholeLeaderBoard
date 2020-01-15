using Newtonsoft.Json;
using PodLabs.Core.Classes.Local;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PodLabs.Core.Classes.Swagger
{
    public class Corporation : EntityBase
    {

        public Corporation() : this(0) { }

        public Corporation(long id) : base(id) { }

        public Corporation(long id, long corporationId) : base(id)
        {
            if (corporationId == 0)
            {
                throw new Exception("Corporation Id cannot be zero!");
            }

            this.CorporationId = corporationId;
        }
         
        public long CorporationId { get; set; }

        [JsonProperty("alliance_id")]
        public long? AllianceId { get; set; }

        [JsonProperty("ceo_id")]
        public long CeoId { get; set; }

        [JsonProperty("creator_id")]
        public long CreatorId { get; set; }

        [JsonProperty("date_founded")]
        public DateTime? DateFounded { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("faction_id")]
        public long? FactionId { get; set; }

        [JsonProperty("home_station_id")]
        public long? HomeStationId { get; set; }

        [JsonProperty("member_count")]
        public long MemberCount { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("shares")]
        public long? Shares { get; set; }

        [JsonProperty("tax_rate")]
        public double TaxRate { get; set; }

        [JsonProperty("ticker")]
        public string Ticker { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("war_eligible")]
        public bool? WarEligible { get; set; }

        public virtual Alliance Alliance { get; set; }

        public override bool Validate()
        {
            return (CeoId > 0) &&
                (CreatorId > 0) &&
                (MemberCount >= 0) &&
                (Name != "") &&
                (TaxRate >= 0) &&
                (Ticker != "");
        }

        public void PopulateFromEsi()
        {
            var client = new HttpClient();
            Task.Run(async () =>
            {
                var results = await client.GetAsync(string.Format("https://esi.evetech.net/latest/corporations/{0}/?datasource=tranquility", this.CorporationId));
                var corporation = JsonConvert.DeserializeObject<Corporation>(await results.Content.ReadAsStringAsync());

                this.AllianceId = corporation.AllianceId;
                this.CeoId = corporation.CeoId;
                this.CreatorId = corporation.CreatorId;
                this.DateFounded = corporation.DateFounded;
                this.Description = corporation.Description;
                this.FactionId = corporation.FactionId;
                this.HomeStationId = corporation.HomeStationId;
                this.MemberCount = corporation.MemberCount;
                this.Name = corporation.Name;
                this.Shares = corporation.Shares;
                this.TaxRate = corporation.TaxRate;
                this.Ticker = corporation.Ticker;
                this.Url = corporation.Url;
                this.WarEligible = corporation.WarEligible;

                results = null;
                corporation = null;

            }).Wait();
        }
    }
}
