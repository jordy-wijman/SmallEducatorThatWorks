using UnityEngine;

//http://answers.unity3d.com/questions/654836/unity2d-sprite-fade-in-and-out.html

namespace LeafManupulator.Effect
{
    public class AlphaFade
    {
        public const int FadeNone = 0;
        public const int FadeIn = 1;
        public const int FadeOut = 2;

        private float fadeSpeed;

        private float fadeTime = 0.30f;

        public AlphaFade()
        {
            FadeState = FadeNone;
        }

        public float Fade { get; set; }

        public float FadeSpeed
        {
            get { return fadeSpeed; }
            set { fadeSpeed = value; }
        }

        public float FadeTime
        {
            get { return fadeTime; }
            set { fadeTime = value; }
        }

        public int FadeState { get; set; }

        public Color RepeatFading(Color old)
        {
            var currentColor = GetFaded(old);

            FadeState = currentColor.a <= 0.001f ? FadeState = FadeIn :
                currentColor.a >= 0.980f ? FadeState = FadeOut : FadeNone;

            return currentColor;
        }

        public Color GetFaded(Color old)
        {
            var color = old;

            color.a = FadeState == FadeIn ? Mathf.SmoothDamp(color.a, 1.0f, ref fadeSpeed, fadeTime) :
                FadeState == FadeOut ? color.a = Mathf.SmoothDamp(color.a, 0.0f, ref fadeSpeed, fadeTime) : color.a;

            return color;
        }
    }
}