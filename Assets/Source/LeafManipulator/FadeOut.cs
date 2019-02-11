using LeafManupulator.Effect;

namespace Source.LeafManipulator
{
    public class FadeOut : FadeIn
    {
        public override void Init()
        {
            base.Init();
            color.a = 1;
            fader.FadeState = AlphaFade.FadeOut;
            doneValue = 0.0f;
        }

        public override void Reset()
        {
            base.Reset();
            color.a = 1;
        }
    }
}