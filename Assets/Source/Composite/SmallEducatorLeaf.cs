using System;
using System.Collections.Generic;
using Source.LeafBehaviour;

namespace Source.Composite
{
    public class SmallEducatorLeaf : Component
    {
        private readonly ILeafBehaviour behaviour;
        private readonly SmallEducator program;
        private bool started;

        /**
         * Abstract class with no clear indicated for its uses. Standard HVA quality, intentional or not.
         * 
         */
        public SmallEducatorLeaf(int id, string name, float minute, float second, SmallEducator program,
            ILeafBehaviour behaviour) :
            base(id, name, minute * 60 + second)
        {
            this.behaviour = behaviour;
            this.program = program;
            started = false;
        }

        public override void Start()
        {
            behaviour.Start();
            started = true;
        }

        public override void DoAction()
        {
            if (started && !behaviour.Update())
            {
                behaviour.CleanUp();
                program.RemoveComponent(this);
            }
        }

        public override void AddComponent(Component component)
        {
            throw new NotImplementedException();
        }

        public override Component GetComponent(int index)
        {
            throw new NotImplementedException();
        }

        public override void RemoveComponent(Component component)
        {
            throw new NotImplementedException();
        }

        public override void SwapComponent(int indexOldPosition, int indexNewPosition)
        {
            throw new NotImplementedException();
        }

        public override IEnumerator<Component> GetIterator()
        {
            throw new NotImplementedException();
        }
    }
}