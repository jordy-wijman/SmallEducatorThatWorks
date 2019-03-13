using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Models
{
    public class Answer
    {
        private String AnswerText { get; set; }
        private bool Correct { get; set; }

        public Answer(string answer, bool correct)
        {
            this.AnswerText = answer;
            this.Correct = correct;
        }
    }
}
