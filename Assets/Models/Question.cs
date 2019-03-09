using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Models
{
    public abstract class Question
    {
        protected String question { get; set; }
        protected List<Answer> answers;


    }
}
