using System.Collections.Generic;
using Source.GUI;
using Source.LeafManipulator;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.LeafBehaviour
{
    public class StaticTextBehaviour : LeafBehaviour
    {
        private readonly ExtraTextSettings extraTextSettings;
        private readonly List<string> linesOfText;

        private readonly Vector2 position;

        private readonly TextMeshProUGUI textField;

        private readonly Image textfieldBackGround;

        private float timer;

        public StaticTextBehaviour(IEnumerable<string> linesOfText, TextInit textSetting, TextMeshProUGUI textField,
            Image textfieldBackGround, float timer, Vector2 position) : this(linesOfText,
            textField, textfieldBackGround, new ExtraTextSettings(),
            timer, position)
        {
        }

        public StaticTextBehaviour(IEnumerable<string> linesOfText,
            TextMeshProUGUI textField, Image textfieldBackGround, ExtraTextSettings extraTextSettings,
            float timer, Vector2 position)
        {
            this.linesOfText = new List<string>(linesOfText);
            this.textField = textField;
            this.textfieldBackGround = textfieldBackGround;
            this.position = position;
            this.timer = timer;
            this.extraTextSettings = extraTextSettings;

            leafManipulators = new List<LeafManipulator.LeafManipulator>();
            leafManipulators.Add(new FadeIn());
            leafManipulators.Add(new FadeOut());
            leafManipulators.Add(new FlyIn(
                //new Vector2(position.x - 1000.0f, position.y),
                position,
                1.0f));
            leafManipulators.Add(new FlyOut(
                position,
                //new Vector2(position.x - 1000.0f, position.y),
                1.0f));
            foreach (var manipulator in leafManipulators) manipulator.Init();
            manipulatorsDone = false;
        }

        public override void Start()
        {
            textField.text = "";
            textField.fontSize = extraTextSettings.FontSize;
            textField.rectTransform.localPosition = position;
            foreach (var t in linesOfText)
            {
                textField.text += t;
                textField.text += "\n";
            }

            if (extraTextSettings.HasBackGround)
            {
                textfieldBackGround.transform.localPosition = textField.transform.localPosition;
                textfieldBackGround.rectTransform.sizeDelta =
                    new Vector2(textField.preferredWidth + 6, textField.preferredHeight + 6);
            }

            var color = textField.color;
            color.a = 1.0f;
            textField.color = color;

            color = textfieldBackGround.color;
            color.a = 1.0f;
            textfieldBackGround.color = color;
        }

        public override bool Update()
        {
            timer -= Time.fixedDeltaTime;
            if (!manipulatorsDone && timer > 1.0f)
            {
                //fade in = 0
                //fly in - 2
                manipulatorsDone = leafManipulators[FadeIn].Update();

                leafManipulators[FadeIn].Manipulate(textField);
                leafManipulators[FadeIn].Manipulate(textfieldBackGround);
                /*
            leafManipulators[FLY_IN].manipulate(textField);
            leafManipulators[FLY_IN].manipulate(textfieldBackGround);
            */
            }

            if (!manipulatorsDone && timer <= 0.31f)
            {
                //fade out
                manipulatorsDone = leafManipulators[FadeOut].Update();
                leafManipulators[FadeOut].Manipulate(textField);
                leafManipulators[FadeOut].Manipulate(textfieldBackGround);

                /*/fly out
            manipulatorsDone = leafManipulators[FLY_OUT].update();
            leafManipulators[FLY_OUT].manipulate(textField);
            leafManipulators[FLY_OUT].manipulate(textfieldBackGround);
            */
            }

            if (timer > 0.31f && timer < 0.33f) manipulatorsDone = false;
            return timer > 0.0f;
        }

        public override void CleanUp()
        {
            textField.text = "";
            textField.transform.position = new Vector2(10000000.0f, 10000000.0f);
            textfieldBackGround.transform.position = new Vector2(10000000.0f, 10000000.0f);
        }
    }
}