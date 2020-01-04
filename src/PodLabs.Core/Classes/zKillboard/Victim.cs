using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PodLabs.Core.Classes.zKillboard
{
    public class Victim : FightingEntity
    {
        public Victim() : this(0) { }

        public Victim(long id) : base(id) { }

        #region Properties
        [Column("DamageTaken")]
        [JsonProperty("damage_taken")]
        public long DamageTaken { get; set; }

        [Column("Items")]
        [JsonProperty("items")]
        public List<Item> Items { get; set; }

        [Column("Position")]
        [JsonProperty("position")]
        public Position Position { get; set; }
        #endregion

        #region Methods
        public override bool Validate()
        {
            return (ShipTypeId > 0) &&
                (DamageTaken > 0);
        }
        #endregion

    }
}
