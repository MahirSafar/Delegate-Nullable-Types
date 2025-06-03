using Delegate_Nullable_Types.Interfaces;

namespace Delegate_Nullable_Types.Entities
{
    public class Entity : IEntity
    {
        private static int _counter = 0;
        private readonly int _id;
        public int Id => _id;
        public Entity()
        {
            _id= ++_counter;
        }
    }
}
