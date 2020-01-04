using Newtonsoft.Json;
using PodLabs.Core.Classes.Local;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PodLabs.Core.Classes.zKillboard
{
    public class Killmail : EntityBase
    {
        public Killmail() : this(0) { }

        public Killmail(long id) : base(id) { }

        #region Properties
        [Column("Attackers")]
        [JsonProperty("attackers")]
        public List<Attacker> Attackers { get; set; }

        [Column("KillmailId")]
        [JsonProperty("killmail_id")]
        public long KillmailId { get; set; }

        [Column("KillmailTime")]
        [JsonProperty("killmail_time")]
        public DateTime KillmailTime { get; set; }

        [Column("SolarSystemId")]
        [JsonProperty("solar_system_id")]
        public long SolarSystemId { get; set; }

        [Column("Victim")]
        [JsonProperty("victim")]
        public Victim Victim { get; set; }

        [Column("Zkb")]
        [JsonProperty("zkb")]
        public Zkb Zkb { get; set; }
        #endregion


        #region Relationships

        #endregion

        #region Methods
        public override bool Validate()
        {
            return (Attackers != null) &&
                (KillmailId > 0) &&
                (SolarSystemId > 0) &&
                (Victim != null) &&
                (Zkb != null);
        }
        #endregion
    }
}
