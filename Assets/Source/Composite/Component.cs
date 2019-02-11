using System.Collections.Generic;

namespace Source.Composite
{
    /// <summary>
    ///     This class does something.
    /// </summary>
    public abstract class Component
    {
        protected Component(int id, string name, float timeStap)
        {
            Id = id;
            Name = name;
            TimeStamp = timeStap;
        }

        public int Id { get; set; }

        public float TimeStamp { get; set; }

        public string Name { get; set; }

        public abstract void AddComponent(Component component);
        public abstract void RemoveComponent(Component component);
        public abstract Component GetComponent(int index);
        public abstract void SwapComponent(int indexOldPosition, int indexNewPosition);
        public abstract IEnumerator<Component> GetIterator();

        public abstract void Start();
        public abstract void DoAction();
    }
}