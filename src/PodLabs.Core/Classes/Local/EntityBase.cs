using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PodLabs.Core.Classes.Local
{
    public abstract class EntityBase
    {

        public EntityBase() : this(0)
        { }

        public EntityBase(long id)
        {
            Id = id;
        }

        [Column("Id")]
        public long Id { get; private set; }

        public abstract bool Validate();

    }
}
