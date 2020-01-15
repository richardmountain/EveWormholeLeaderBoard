using Newtonsoft.Json;
using PodLabs.Core.Classes.Local;
using PodLabs.Core.Classes.Swagger;
using System.ComponentModel.DataAnnotations.Schema;

namespace PodLabs.Core.Classes.zKillboard
{
    public class FightingEntity : EntityBase
    {
        public FightingEntity() : this(0) { }
        public FightingEntity(long id) : base(id) { }

        #region Properties
        [Column("CharacterId")]
        [JsonProperty("character_id")]
        public long CharacterId { get; set; }

        [Column("AllianceId")]
        [JsonProperty("alliance_id")]
        public long AllianceId { get; set; }

        [Column("CorporationId")]
        [JsonProperty("corporation_id")]
        public long CorporationId
        {
            get
            {
                if (_corporationId > 0)
                    this.Corporation = new Corporation() { CorporationId = _corporationId };

                return _corporationId;
            }
            set
            {
                _corporationId = value;
            }
        }
        private long _corporationId;

        [Column("ShipTypeId")]
        [JsonProperty("ship_type_id")]
        public long ShipTypeId { get; set; }
        #endregion

        #region Relationships
        public virtual Corporation Corporation { get; set; }
        #endregion

        #region Methods
        public override bool Validate()
        {
            return (CorporationId > 0) &&
                (CharacterId > 0) &&
                (ShipTypeId > 0);
        }
        #endregion
    }
}
