using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Models.question
{
    public class SingleChoiceQuestion : Question
    {
        public SingleChoiceQuestion(String question, List<Answer> answers)
        {
            this.QuestionText = question;
            this.Answers = answers;
        }
    }
}
