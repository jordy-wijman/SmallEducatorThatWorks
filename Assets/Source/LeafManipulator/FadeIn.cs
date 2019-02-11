using LeafManupulator.Effect;
using UnityEngine;

namespace Source.LeafManipulator
{
    public class FadeIn : LeafManipulator
    {
        protected float doneValue = 1.0f;
        protected AlphaFade fader;

        public override void Init()
        {
            color = Color.red;
            color.a = 0;
            fader = new AlphaFade();
            fader.FadeState = AlphaFade.FadeIn;
        }

        public override void Reset()
        {
            color = Color.red;
            color.a = 0;
        }

        public override bool Update()
        {
            color = fader.GetFaded(color);
            return color.a == doneValue;
        }
    }
}