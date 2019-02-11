using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.GUI
{
    public class MultipleChoiceQuestionnaire : MonoBehaviour
    {
        public Image backgroundMultipleChoiceQuestion;
        private float currentPosition;
        private ExtraTextSettings extraTextSettings;
        public float heightBackground;
        public float posYBackground;

        public float preferredWidthBackground;

        //public Text questionField;
        public TextMeshProUGUI questionField;
        public SmallEducator smallEducator;
        public Button submitButton;
        public ToggleGroup toggleGroup;

        private void SetItems(bool singleAnswer, string question, List<string> anwsers)
        {
            SetQuestion(question);
            SetAnwsers(singleAnswer, anwsers);
        }

        private void SetQuestion(string question)
        {
            questionField.text = question;
            heightBackground = questionField.preferredHeight;
            preferredWidthBackground = questionField.preferredWidth;
            posYBackground = 20.0f;
        }

        private void SetAnwsers(bool singleAnswer, List<string> anwsers)
        {
            AddToggles(singleAnswer, anwsers);
            SetTogglePositions();
        }

        private void SetTogglePositions()
        {
            var toggles = gameObject.GetComponentsInChildren<Toggle>();
            if (toggles.Length > 0)
            {
                posYBackground -= 20.0f;
                heightBackground += 20;
            }

            foreach (var toggle in toggles) currentPosition += SetToggleLocalPosition(toggle, currentPosition);

            SetButtonPosition(currentPosition);
        }

        private void SetButtonPosition(float currentPos)
        {
            submitButton.transform.localPosition = new Vector2(0.0f, currentPos - 15.0f);

            submitButton.onClick.AddListener(delegate { SubmitAnswer(); });
        }

        private float SetToggleLocalPosition(Component toggle, float currentPos)
        {
            toggle.transform.localPosition = new Vector2(0.0f, currentPos);
            var text = toggle.GetComponentInChildren<Text>();
            var preferredHeight = text.preferredHeight;
            
            heightBackground += preferredHeight; // - (text.preferredHeight % 15.0f);
            posYBackground -= preferredHeight; // - (text.preferredHeight % 15.0f);
            Debug.Log("text.preferredHeight " + preferredHeight);
            return -text.preferredHeight;
        }

        private void AddToggles(bool singleAnswer, IEnumerable<string> anwsers)
        {
            if (singleAnswer) toggleGroup.allowSwitchOff = true;

            foreach (var answer in anwsers) AddToggle(singleAnswer, answer);
        }

        private void AddToggle(bool singleAnswer, string answer)
        {
            var t = Instantiate(Resources.Load<Toggle>("Toggle"), gameObject.transform, true);

            if (singleAnswer)
            {
                toggleGroup.RegisterToggle(t);
                t.group = toggleGroup;
            }

            t.GetComponentInChildren<Text>().text = answer;
            t.interactable = true;
            t.isOn = false;
            preferredWidthBackground =
                preferredWidthBackground < 22.0f + t.GetComponentInChildren<Text>().preferredWidth
                    ? 22.0f + t.GetComponentInChildren<Text>().preferredWidth
                    : preferredWidthBackground;
        }

        private void RemoveAnswers()
        {
            var toggles = gameObject.GetComponentsInChildren<Toggle>();

            foreach (var toggle in toggles) RemoveAnswer(toggle);

            preferredWidthBackground = 0.0f;
            currentPosition = 0.0f;
            heightBackground = 0.0f;
            posYBackground = 0.0f;
        }

        private void RemoveAnswer(Toggle toggle)
        {
            toggleGroup.UnregisterToggle(toggle);
            toggle.group = null;
            toggle.transform.SetParent(null, false);
            Destroy(toggle.gameObject);
        }

        public void Initialized(bool singleAnswer, string question, List<string> anwsers,
            ExtraTextSettings textSettings)
        {
            RemoveAnswers();
            SetItems(singleAnswer, question, anwsers);
            extraTextSettings = textSettings;
            SetBackGround();
        }

        private void SetBackGround()
        {
            if (extraTextSettings.HasBackGround)
            {
                backgroundMultipleChoiceQuestion.rectTransform.sizeDelta = new Vector2(preferredWidthBackground + 6,
                    heightBackground);
                Debug.Log("heightBackground " + heightBackground);
                backgroundMultipleChoiceQuestion.transform.localPosition = new Vector2(
                    questionField.transform.localPosition.x, posYBackground);
            }
        }

        private void SubmitAnswer()
        {
            var toggles = gameObject.GetComponentsInChildren<Toggle>();
            foreach (var t in toggles)
                if (t.isOn)
                    Debug.Log(t.GetComponentInChildren<Text>().text);
            smallEducator.QuestionnaireFinished();
            gameObject.SetActive(false);
        }

        // Use this for initialization
        public void Start()
        {
            //   backgroundMultipleChoiceQuestion = GameObject.FindGameObjectWithTag("BackgroundMultipleChoiceQuestion").GetComponent<Image>();
            smallEducator.QuestionnaireStarted(this);
        }
    }
}