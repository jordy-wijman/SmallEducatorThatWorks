using System.Collections;
using System.Collections.Generic;

namespace Source.Composite
{
    public class SmallEducatorCompositeIterator : IEnumerator<Component>
    {
        private List<Component> componentList;
        private int currentIndex;

        public SmallEducatorCompositeIterator(List<Component> componentList)
        {
            this.componentList = componentList;
            currentIndex = 0;
            MoveNext();
        }

        public Component Current { get; private set; }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Dispose()
        {
            componentList = null;
            Current = null;
        }

        public bool MoveNext()
        {
            var movedToNext = false;
            if (currentIndex < componentList.Count)
            {
                movedToNext = true;
                Current = componentList[currentIndex];
                currentIndex++;
            }

            return movedToNext;
        }

        public void Reset()
        {
            currentIndex = 0;
            Current = componentList[currentIndex];
        }
    }
}