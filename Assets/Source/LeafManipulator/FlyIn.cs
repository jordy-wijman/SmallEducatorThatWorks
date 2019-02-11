using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.LeafManipulator
{
    public class FlyIn : LeafManipulator
    {
        private Vector3 currentPosition;
        private float delta;
        private readonly float duration;
        private readonly Vector3 endPosition;
        private readonly Vector3 startPosition;

        public FlyIn(Vector3 startPosition, Vector3 endPosition, float durationInSeconds)
        {
            currentPosition = startPosition;
            this.startPosition = startPosition;
            this.endPosition = endPosition;
            duration = durationInSeconds;
            delta = Vector3.Distance(startPosition, endPosition) / duration;
        }

        public FlyIn(Vector3 endPosition, float durationInSeconds) :
            this(Random.value > 0.5
                    ? new Vector3(endPosition.x - 1000.0f, endPosition.y + Random.Range(-1.0f, 1.0f) * 1000.0f)
                    : new Vector3(endPosition.x + 1000.0f, endPosition.y + Random.Range(-1.0f, 1.0f) * 1000.0f)
                , endPosition,
                durationInSeconds)
        {
        }

        public override void Init()
        {
            delta = Vector3.Distance(startPosition, endPosition) / duration;
            currentPosition = startPosition;
        }

        public override void Reset()
        {
            currentPosition = startPosition;
        }

        public override bool Update()
        {
            currentPosition = Vector3.MoveTowards(currentPosition, endPosition, delta * Time.fixedDeltaTime);
            return Vector3.Distance(currentPosition, endPosition) < 0.05f;
        }

        public override void Manipulate(Image image)
        {
            image.transform.localPosition = currentPosition;
        }

        public override void Manipulate(TextMeshProUGUI textField)
        {
            textField.transform.localPosition = currentPosition;
        }
    }
}