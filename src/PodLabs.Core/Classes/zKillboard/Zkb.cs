using Newtonsoft.Json;
using PodLabs.Core.Classes.Local;
using System.ComponentModel.DataAnnotations.Schema;

namespace PodLabs.Core.Classes.zKillboard
{
    public class Zkb : EntityBase
    {
        public Zkb() : this(0) { }

        public Zkb(long id) : base(id) { }

        #region Properties
        [JsonProperty("locationID")]
        public long LocationId { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("fittedValue")]
        public double FittedValue { get; set; }

        [JsonProperty("totalValue")]
        public double TotalValue { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }

        [JsonProperty("npc")]
        public bool NPC { get; set; }

        [JsonProperty("solo")]
        public bool Solo { get; set; }

        [JsonProperty("awox")]
        public bool Awox { get; set; }

        [JsonProperty("esi")]
        public string Esi { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
        #endregion

        #region Relationships

        #endregion

        #region Methods
        public override bool Validate()
        {
            return (!string.IsNullOrEmpty(Hash)) &&
                (FittedValue >= 0) &&
                (TotalValue >= 0) &&
                (Points >= 0) &&
                (!string.IsNullOrEmpty(Esi)) &&
                (!string.IsNullOrEmpty(Url));
        }
        #endregion
    }
}
