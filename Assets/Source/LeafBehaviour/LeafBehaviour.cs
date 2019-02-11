using System.Collections.Generic;

namespace Source.LeafBehaviour
{
    public abstract class LeafBehaviour : ILeafBehaviour
    {
        protected const int FadeIn = 0;
        protected const int FadeOut = 1;
        protected const int FlyIn = 2;
        protected const int FlyOut = 3;

        protected List<LeafManipulator.LeafManipulator> leafManipulators;
        protected bool manipulatorsDone = false;

        public abstract void CleanUp();

        public abstract void Start();

        public abstract bool Update();
    }
}