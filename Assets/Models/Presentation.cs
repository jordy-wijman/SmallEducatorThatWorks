using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Models
{
    class Presentation
    {
        private int currentSlide;
        private List<Slide> slides { get; set; }

        public Presentation(List<Slide> slides)
        {
            this.slides = slides;
            currentSlide = 0;
        }

        public Slide nextSlide()
        {
            return slides[currentSlide++];
        }

        public Slide returnCurrentSlide()
        {
            return slides[currentSlide];
        }
        public Slide previousSlide()
        {
            return slides[currentSlide--];
        }
    }
}
