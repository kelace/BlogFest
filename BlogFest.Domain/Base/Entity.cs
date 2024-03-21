namespace BlogFest.Domain.Base
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }

        // Constructor for the new entities
        public Entity()
        {
            //Id = Guid.NewGuid();
        }
        public Entity(Guid id)
        {
            Id = id;
        }
    }
}
