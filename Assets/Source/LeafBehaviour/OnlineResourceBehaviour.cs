using UnityEngine;
using UnityEngine.UI;

namespace Source.LeafBehaviour
{
    public class OnlineResourceBehaviour : ILeafBehaviour
    {
        private readonly Button extraResourceButton;
        private float timer;
        private readonly string url;

        public OnlineResourceBehaviour(string url, Button extraResourceButton, float timer)
        {
            this.url = url;
            this.extraResourceButton = extraResourceButton;
            this.timer = timer;
        }

        public void CleanUp()
        {
            extraResourceButton.transform.position = new Vector2(10000000.0f, 10000000.0f);
        }

        public void Start()
        {
            extraResourceButton.transform.position = new Vector2(950, 70.0f);
        }

        public bool Update()
        {
            timer -= Time.fixedDeltaTime;

            return timer > 0.0f;
        }

        public void DoOnClick()
        {
            Application.OpenURL(url);
        }
    }
}