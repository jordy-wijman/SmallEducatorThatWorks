using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Models.question
{
    public class MultipleChoiceQuestion : Question
    {
        public MultipleChoiceQuestion(String question, List<Answer> answers)
        {
            this.question = question;
            this.answers = answers;
        }
    }
}
