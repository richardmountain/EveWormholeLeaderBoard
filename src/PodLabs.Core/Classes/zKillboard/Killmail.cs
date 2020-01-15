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

        public Killmail(long id) : base(id) 
        {
            //Victim = new Victim();
        }

        #region Properties
        //[JsonProperty("attackers")]
        //public List<Attacker> Attackers { get; set; }

        [JsonProperty("killmail_id")]
        public long KillmailId { get; set; }

        [JsonProperty("killmail_time")]
        public DateTime KillmailTime { get; set; }

        [JsonProperty("solar_system_id")]
        public long SolarSystemId { get; set; }

        //[JsonProperty("victim")]
        //public Victim Victim { get; set; }

        //[JsonProperty("zkb")]
        //public Zkb Zkb { get; set; }
        #endregion


        #region Relationships

        #endregion

        #region Methods
        public override bool Validate()
        {
            //return (Attackers != null) &&
            //    (KillmailId > 0) &&
            //    (SolarSystemId > 0) &&
            //    (Victim != null) &&
            //    (Zkb != null);
            return true;
        }
        #endregion
    }
}
