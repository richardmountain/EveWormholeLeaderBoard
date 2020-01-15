using Newtonsoft.Json;
using PodLabs.Core.Classes.Local;

namespace PodLabs.Core.Classes.zKillboard
{
    public class Position : EntityBase
    {
        public Position() : this(0) { }

        public Position(long id) : base(id) { }

        #region Properties
        [JsonProperty("x")]
        public float X { get; set; }

        [JsonProperty("y")]
        public float Y { get; set; }

        [JsonProperty("z")]
        public float Z { get; set; }
        #endregion

        #region Relationships

        #endregion

        #region Methods
        public override bool Validate()
        {
            return true;
        }
        #endregion
    }
}
