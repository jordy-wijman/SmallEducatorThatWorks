using System.Collections.Generic;
using Source.GUI;
using UnityEngine;

namespace Source.LeafBehaviour
{
    public class TextBehaviour : ILeafBehaviour
    {
        private readonly List<string> linesOfText;
        private readonly Vector2 position;
        private readonly TextTyper textTyper;

        public TextBehaviour(TextTyper textTyper, List<string> linesOfText,
            Vector2 position)
        {
            this.textTyper = textTyper;
            this.position = position;
            this.linesOfText = linesOfText;
        }

        public void CleanUp()
        {
            textTyper.TextField.text = "";
            textTyper.TextField.transform.position = new Vector2(10000000.0f, 10000000.0f);
        }

        public void Start()
        {
            textTyper.TextSetting[0].Text = linesOfText;
            textTyper.TextField.rectTransform.localPosition = position;
            textTyper.TextSettingIndex = 0;
            textTyper.ShowNextText();
        }

        public bool Update()
        {
            return textTyper.State != TextTyper.TextTyperState.FadeoutDoneIntroductionText;
        }
    }
}