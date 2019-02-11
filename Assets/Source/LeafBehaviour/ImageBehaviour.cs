using System.Collections;
using UnityEngine;

namespace Source.LeafBehaviour
{
    public class ImageBehaviour : ILeafBehaviour
    {
        protected Vector2 position;
        protected GameObject quad;
        private readonly SmallEducator smallEducator;

        private float timer;
        protected string url = "https://www.uml-diagrams.org/class-diagrams/class-diagram-domain-overview.png";

        public ImageBehaviour(SmallEducator smallEducator, string url, GameObject quad,
            Vector2 position, Texture2D tex, float timer)
        {
            this.smallEducator = smallEducator;
            this.url = url;
            this.quad = quad;
            this.position = position;
            Tex = tex;
            this.timer = timer;
        }

        public Texture2D Tex { get; set; }

        public void CleanUp()
        {
            quad.transform.localScale = new Vector2(1.0f, 1.0f);
            quad.transform.position = new Vector2(1000.0f, 0.0f);
        }

        public virtual void Start()
        {
            smallEducator.StartCoroutine(StartLoading(Tex));
        }

        public bool Update()
        {
            timer -= Time.fixedDeltaTime;
            return timer > 0.0f;
        }

        private IEnumerator StartLoading(Texture2D text)
        {
            using (var www = new WWW(url))
            {
                yield return www;
                www.LoadImageIntoTexture(Tex);
                quad.GetComponent<Renderer>().material.mainTexture = Tex;
                quad.transform.position = position;
                quad.transform.localScale = new Vector2(9.0f, 9.0f);
            }
        }
    }
}