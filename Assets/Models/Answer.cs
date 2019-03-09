using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Models
{
    public class Answer
    {
        private String answer { get; set; }
        private bool correct { get; set; }

        public Answer(string answer, bool correct)
        {
            this.answer = answer;
            this.correct = correct;
        }
    }
}
