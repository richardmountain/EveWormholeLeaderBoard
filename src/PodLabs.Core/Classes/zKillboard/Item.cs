using Newtonsoft.Json;
using PodLabs.Core.Classes.Local;
using System.ComponentModel.DataAnnotations.Schema;

namespace PodLabs.Core.Classes.zKillboard
{
    public class Item : EntityBase
    {
        public Item() : this(0) { }

        public Item(long id) : base(id) { }

        #region Properties
        [Column("Flag")]
        [JsonProperty("flag")]
        public int Flag { get; set; }

        [Column("ItemTypeId")]
        [JsonProperty("item_type_id")]
        public int ItemTypeId { get; set; }

        [Column("QuantityDropped")]
        [JsonProperty("quantity_dropped")]
        public long? QuantityDropped { get; set; }

        [Column("QuantityDestroyed")]
        [JsonProperty("quantity_destroyed")]
        public long? QuantityDestroyed { get; set; }

        [Column("Singleton")]
        [JsonProperty("singleton")]
        public int Singleton { get; set; }
        #endregion

        #region Methods
        public override bool Validate()
        {
            return (ItemTypeId > 0) &&
                (QuantityDestroyed >= 0) &&
                (QuantityDropped >= 0);
        }
        #endregion
    }
}
