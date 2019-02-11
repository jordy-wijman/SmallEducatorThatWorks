using System;
using System.Collections.Generic;

namespace Source.Composite
{
    public class SmallEducatorComposite : Component
    {
        private readonly List<Component> componentList = new List<Component>();

        public SmallEducatorComposite(int id, string name, float timeStap) : base(id, name, timeStap)
        {
        }

        public override void AddComponent(Component component)
        {
            componentList.Add(component);
        }

        public override Component GetComponent(int index)
        {
            return componentList[index];
        }

        public override void RemoveComponent(Component component)
        {
            componentList.Remove(component);
        }

        public override void SwapComponent(int indexOldPosition, int indexNewPosition)
        {
            var temp = componentList[indexNewPosition];
            componentList[indexNewPosition] = componentList[indexOldPosition];
            componentList[indexNewPosition] = temp;
        }

        public override IEnumerator<Component> GetIterator()
        {
            return new SmallEducatorCompositeIterator(componentList);
        }

        public override void DoAction()
        {
            throw new NotImplementedException();
        }

        public override void Start()
        {
            throw new NotImplementedException();
        }
    }
}