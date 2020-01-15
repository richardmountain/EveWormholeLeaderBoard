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

        public long Id { get; private set; }

        public abstract bool Validate();

    }
}
