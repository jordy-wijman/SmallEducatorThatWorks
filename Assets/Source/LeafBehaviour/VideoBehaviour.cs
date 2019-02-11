using UnityEngine;
using UnityEngine.Video;

namespace Source.LeafBehaviour
{
    public class VideoBehaviour : ILeafBehaviour
    {
        private readonly int height;
        private bool isOnlineVideo;
        private readonly Vector2 position;
        private readonly GameObject quad;
        private float timer;
        private readonly string videoFile;
        private readonly VideoPlayer videoPlayer;
        private readonly int width;

        public VideoBehaviour(VideoPlayer videoPlayer, string videoFile, bool isOnlineVideo, Vector2 position,
            int width, int height, GameObject quad)
        {
            this.videoPlayer = videoPlayer;
            this.videoFile = videoFile;
            this.isOnlineVideo = isOnlineVideo;
            this.position = position;
            this.height = height;
            this.width = width;
            this.quad = quad;
            timer = 0.5f;
        }

        public void Start()
        {
            var rend = quad.GetComponent<Renderer>();
            if (rend != null)
            {
                var texture = new RenderTexture(width, height, 0, RenderTextureFormat.ARGB32);

                rend.material.mainTexture = texture;
                videoPlayer.targetTexture = texture;
            }

            quad.transform.position = new Vector3(position.x, position.y, 0.0f);

            videoPlayer.url = videoFile;
            videoPlayer.Play();
        }

        public void CleanUp()
        {
            quad.transform.position = new Vector3(1000.0f, 0.0f, 0.0f);
        }

        public bool Update()
        {
            var videoPlaying = !(timer > 5.0f) || videoPlayer.isPlaying;
            timer += Time.fixedDeltaTime;
            return videoPlaying;
        }
    }
}