using System.Collections.Generic;
using Source.GUI;
using UnityEngine;

namespace Source.LeafBehaviour
{
    public class MultipleChoiceBehaviour : ILeafBehaviour
    {
        private readonly List<string> answers;
        private readonly MultipleChoiceQuestionnaire multipleChoiceQuestionnaire;
        private readonly string question;
        private readonly bool singleAnswer;

        public MultipleChoiceBehaviour(MultipleChoiceQuestionnaire multipleChoiceQuestionnaire, List<string> answers,
            string question, bool singleAnswer)
        {
            this.multipleChoiceQuestionnaire = multipleChoiceQuestionnaire;
            this.answers = answers;
            this.question = question;
            this.singleAnswer = singleAnswer;
        }

        public void CleanUp()
        {
        }

        public void Start()
        {
            var extraTextSettings = new ExtraTextSettings();
            extraTextSettings.HasBackGround = true;
            multipleChoiceQuestionnaire.gameObject.transform.position = new Vector3(512.0f, 384.0f, 0.0f);
            multipleChoiceQuestionnaire.Start();
            multipleChoiceQuestionnaire.gameObject.SetActive(true);
            multipleChoiceQuestionnaire.Initialized(singleAnswer, question, answers, extraTextSettings);
        }

        public bool Update()
        {
            return false;
        }
    }
}