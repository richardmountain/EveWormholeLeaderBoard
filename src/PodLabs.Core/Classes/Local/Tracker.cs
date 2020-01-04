using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PodLabs.Core.Classes.Local
{
    public class Tracker : EntityBase
    {

        public Tracker() : this(0) { }

        public Tracker(long defaultId) : base(defaultId) { }

        [Column("TrackerId")]
        public long TrackerId { get; set; }

        [Column("IsAlliance", TypeName = "bit")]
        public bool IsAlliance { get; set; }

        public override bool Validate()
        {
            return (TrackerId > 0);
        }
    }
}