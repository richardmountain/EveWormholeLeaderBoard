using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace PodLabs.Core.Classes.zKillboard
{
    [Table("Attacker")]
    public class Attacker : FightingEntity
    {
        public Attacker() : this(0) { }

        public Attacker(long id) : base(id) { }

        #region Properties
        [JsonProperty("damage_done")]
        public long DamageDone { get; set; }

        [JsonProperty("faction_id")]
        public long FactionId { get; set; }

        [JsonProperty("final_blow")]
        public bool FinalBlow { get; set; }

        [JsonProperty("security_status")]
        public float SecurityStatus { get; set; }

        [JsonProperty("weapon_type_id")]
        public long WeaponTypeId { get; set; }
        #endregion

        #region Relationships
        
        #endregion

        #region Methods
        public override bool Validate()
        {
            return (DamageDone >= 0) &&
                (ShipTypeId > 0) &&
                (WeaponTypeId > 0);
        }
        #endregion
    }
}
