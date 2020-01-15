using Newtonsoft.Json;
using PodLabs.Core.Classes.Swagger;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PodLabs.Core.Classes.zKillboard
{
    [Table("Victim")]
    public class Victim : FightingEntity
    {
        public Victim() : this(0) { }

        public Victim(long id) : base(id) { }

        #region Properties
        [JsonProperty("damage_taken")]
        public long DamageTaken { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }

        [JsonProperty("position")]
        public Position Position { get; set; }
        #endregion

        #region Relationships

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
