using System;
using System.Collections.Generic;
using UnityEngine;

namespace Source.GUI
{
    [CreateAssetMenu(fileName = "Data", menuName = "GameLib/TextInit", order = 2)]
    [Serializable]
    public class TextInit : ScriptableObject
    {
        protected int currectText;

        protected List<string> endOfSceneText;
        protected float letterPause;

        protected float minHeight = 90;

        protected float minWidth = 390;

        protected List<string> text;

        public float LetterPause
        {
            get { return letterPause; }
            set { letterPause = value; }
        }

        public int CurrectText
        {
            get { return currectText; }
            set { currectText = value; }
        }

        public List<string> Text
        {
            get { return text; }
            set { text = value; }
        }

        public List<string> EndOfSceneText
        {
            get { return endOfSceneText; }
            set { endOfSceneText = value; }
        }

        public float MinWidth
        {
            get { return minWidth; }
            set { minWidth = value; }
        }

        public float MinHeight
        {
            get { return minHeight; }
            set { minHeight = value; }
        }
    }
}