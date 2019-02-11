using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.LeafManipulator
{
    public abstract class LeafManipulator
    {
        protected Color color;

        public abstract void Init();
        public abstract bool Update();
        public abstract void Reset();

        public virtual void Manipulate(Image image)
        {
            color.r = image.color.r;
            color.g = image.color.g;
            color.b = image.color.b;
            image.color = color;
        }

        public virtual void Manipulate(TextMeshProUGUI textField)
        {
            color.r = textField.color.r;
            color.g = textField.color.g;
            color.b = textField.color.b;
            textField.color = color;
        }
    }
}