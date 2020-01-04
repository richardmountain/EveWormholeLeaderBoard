using Newtonsoft.Json;
using PodLabs.Core.Classes.Local;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http;
using System.Threading.Tasks;

namespace PodLabs.Core.Classes.Swagger
{
    public class Corporation : EntityBase
    {

        public Corporation() : this(0) { }

        public Corporation(long id) : base(id) { }

        [Column("CorporationId")]
        public long CorporationId { get; set; }

        [Column("AllianceId")]
        [JsonProperty("alliance_id")]
        public long? AllianceId { get; set; }

        [Column("CeoId")]
        [JsonProperty("ceo_id")]
        public long CeoId { get; set; }

        [Column("CreatorId")]
        [JsonProperty("creator_id")]
        public long CreatorId { get; set; }

        [Column("DateFounded")]
        [JsonProperty("date_founded")]
        public DateTime? DateFounded { get; set; }

        [Column("Description")]
        [JsonProperty("description")]
        public string Description { get; set; }

        [Column("FactionId")]
        [JsonProperty("faction_id")]
        public long? FactionId { get; set; }

        [Column("HomeStationId")]
        [JsonProperty("home_station_id")]
        public long? HomeStationId { get; set; }

        [Column("MemberCount")]
        [JsonProperty("member_count")]
        public long MemberCount { get; set; }

        [Column("Name")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Column("Shares")]
        [JsonProperty("shares")]
        public long? Shares { get; set; }

        [Column("TaxRate")]
        [JsonProperty("tax_rate")]
        public double TaxRate { get; set; }

        [Column("Ticker")]
        [JsonProperty("ticker")]
        public string Ticker { get; set; }

        [Column("Url")]
        [JsonProperty("url")]
        public string Url { get; set; }

        [Column("WarEligible", TypeName = "bit")]
        [JsonProperty("war_eligible")]
        public bool? WarEligible { get; set; }

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
