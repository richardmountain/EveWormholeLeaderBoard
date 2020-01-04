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
        [Column("LocationId")]
        [JsonProperty("locationID")]
        public long LocationId { get; set; }

        [Column("Hash")]
        [JsonProperty("hash")]
        public string Hash { get; set; }

        [Column("FittedValue")]
        [JsonProperty("fittedValue")]
        public double FittedValue { get; set; }

        [Column("TotalValue")]
        [JsonProperty("totalValue")]
        public double TotalValue { get; set; }

        [Column("Points")]
        [JsonProperty("points")]
        public int Points { get; set; }

        [Column("NPC", TypeName = "bit")]
        [JsonProperty("npc")]
        public bool NPC { get; set; }

        [Column("Solo", TypeName = "bit")]
        [JsonProperty("solo")]
        public bool Solo { get; set; }

        [Column("Awox", TypeName = "bit")]
        [JsonProperty("awox")]
        public bool Awox { get; set; }

        [Column("Esi")]
        [JsonProperty("esi")]
        public string Esi { get; set; }

        [Column("Url")]
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
