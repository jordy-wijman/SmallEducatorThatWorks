using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Models
{
    class Presentation
    {
        private int currentSlide;
        private List<Slide> Slides { get; set; }

        public Presentation(List<Slide> slides)
        {
            this.Slides = slides;
            currentSlide = 0;
        }

        public Slide NextSlide()
        {
            return Slides[currentSlide++];
        }

        public Slide ReturnCurrentSlide()
        {
            return Slides[currentSlide];
        }
        public Slide PreviousSlide()
        {
            return Slides[currentSlide--];
        }
    }
}
