using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Source.GUI
{
    public class TextTyper : MonoBehaviour
    {
        public enum TextTyperState
        {
            IntroductionText,
            FadeoutIntroductionText,
            FadeoutDoneIntroductionText,
            EndSceneText
        }

        public List<TextInit> TextSetting { get; set; }

        public int TextSettingIndex { get; set; }

        public TextInit CurrentTextSetting { get; set; }

        public TextMeshProUGUI TextField { get; set; }

        public TextTyperState State { get; set; }

        // Use this for initialization
        private void Start()
        {
            Init();
        }

        private void Init()
        {
            ResetTextField();
            ///////showNextText();
        }

        private void ResetTextField()
        {
            var color = TextField.color;
            color.a = 1.0f;
            TextField.color = color;
            TextField.text = "";
        }

        public void ShowGameOver()
        {
            ResetTextField();
            TextSettingIndex = TextSetting.Count - 1;
            State = TextTyperState.IntroductionText;
            CurrentTextSetting = TextSetting[TextSettingIndex];
            CurrentTextSetting.CurrectText = 0;
            TextField.text = "";
            TextSettingIndex++;
            StartCoroutine(TypeText(CurrentTextSetting.Text[CurrentTextSetting.CurrectText]));
        }

        public void ShowNextText()
        {
            ResetTextField();

            State = TextTyperState.IntroductionText;
            CurrentTextSetting = TextSetting[TextSettingIndex];
            CurrentTextSetting.CurrectText = 0;
            TextField.text = "";
            TextSettingIndex++;
            StartCoroutine(TypeText(CurrentTextSetting.Text[CurrentTextSetting.CurrectText]));
        }

        public void FadeOutText()
        {
            State = TextTyperState.FadeoutIntroductionText;

            StartCoroutine(FadeText());
        }

        private IEnumerator FadeText()
        {
            yield return new WaitForSeconds(1.0f);

            var color = TextField.color;

            for (color.a = 1.0f; color.a > 0.0f; color.a -= 0.04f)
            {
                TextField.color = color;
                yield return 0;
                yield return new WaitForSeconds(CurrentTextSetting.LetterPause / 50.0f);
            }

            State = TextTyperState.FadeoutDoneIntroductionText;
        }

        private IEnumerator TypeText(string message)
        {
            if (State == TextTyperState.IntroductionText)
            {
                foreach (var letter in message)
                {
                    TextField.text += letter;

                    if (State != TextTyperState.IntroductionText) break;
                    yield return 0;
                    yield return new WaitForSeconds(CurrentTextSetting.LetterPause);
                }

                if (CurrentTextSetting.CurrectText < 2 &&
                    CurrentTextSetting.CurrectText < CurrentTextSetting.Text.Count - 1)
                {
                    TextField.text += "\n";
                    CurrentTextSetting.CurrectText++;
                    StartCoroutine(TypeText(CurrentTextSetting.Text[CurrentTextSetting.CurrectText]));
                }
                else
                {
                    yield return new WaitForSeconds(10.0f);
                    FadeOutText();
                }
            }
        }

        public void ShowEndText(int textId)
        {
            TextField.text = "";
            var color = TextField.color;
            color.a = 1.0f;
            TextField.color = color;
            CurrentTextSetting.CurrectText = textId;
            StartCoroutine(TypeTextTwo(CurrentTextSetting.EndOfSceneText[CurrentTextSetting.CurrectText]));
        }

        private IEnumerator TypeTextTwo(string message)
        {
            foreach (var letter in message)
            {
                TextField.text += letter;

                yield return 0;
                yield return new WaitForSeconds(CurrentTextSetting.LetterPause);
            }
        }
    }
}