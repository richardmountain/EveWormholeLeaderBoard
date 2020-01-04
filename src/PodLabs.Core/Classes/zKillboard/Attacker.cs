using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace PodLabs.Core.Classes.zKillboard
{
    public class Attacker : FightingEntity
    {
        public Attacker() : this(0) { }

        public Attacker(long id) : base(id) { }

        #region Properties
        [Column("DamageDone")]
        [JsonProperty("damage_done")]
        public long DamageDone { get; set; }

        [Column("FactionId")]
        [JsonProperty("faction_id")]
        public long FactionId { get; set; }

        [Column("FinalBlow", TypeName = "bit")]
        [JsonProperty("final_blow")]
        public bool FinalBlow { get; set; }

        [Column("SecurityStatus")]
        [JsonProperty("security_status")]
        public float SecurityStatus { get; set; }

        [Column("WeaponTypeID")]
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
