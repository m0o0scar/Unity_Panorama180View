using UnityEngine;
using UnityEngine.Video;

namespace Panorama180View
{
    public class Panorama180View : MonoBehaviour
    {
        public enum MediaType {
            Image,
            Video
        }

        public enum PanoramaType {
            Equirectangular360TopAndBottom,
            Equirectangular180SideBySide,
            FishEye180SideBySide
        }

        [SerializeField] MediaType fileType = MediaType.Image;
        [SerializeField] Texture2D image = null;
        [SerializeField] VideoClip video = null;

        [SerializeField] PanoramaType projectonType = PanoramaType.Equirectangular180SideBySide;

        private GameObject sphere = null;
        private Material sphereMaterial = null;
        private GameObject videoGameObject = null;
        private VideoPlayer videoPlayer = null;
        private GameObject audioSource = null;
        private RenderTexture renderTexture = null;

        void Start () {
            initSphere();
            //initVideoPlayer();
            initTexture();
        }

        void OnDestroy () {
            if (renderTexture != null) {
                Destroy(renderTexture);
                renderTexture = null;
            }
            if (videoGameObject != null) {
                GameObject.Destroy(videoGameObject);
                videoGameObject = null;
            }
            if (audioSource != null) {
                GameObject.Destroy(audioSource);
                audioSource = null;
            }
            if (sphereMaterial != null) {
                Destroy(sphereMaterial);
            }
            if (sphere != null) {
                GameObject.Destroy(sphere);
            }
        }

        private void initSphere ()
        {
            sphere = transform.Find("Sphere").gameObject;
            sphereMaterial = sphere.GetComponent<MeshRenderer>().material;
        }

        //private void initVideoPlayer () {
        //    // Audioソース用のGameObjectを作成.
        //    // Audioは、指定のGameObjectを中心に音が鳴る.
        //    if (m_audioSource == null) {
        //        m_audioSource = new GameObject("AudioSource");
        //        m_audioSource.transform.position = this.transform.position;
        //    }
        //    AudioSource audioSource = m_audioSource.AddComponent<AudioSource>();

        //    // Video再生用のGameObjectを作成.
        //    if (m_videoG == null) {
        //        m_videoG = new GameObject("VideoPlayer");
        //        //m_videoG.transform.parent = m_rootG.transform;
        //        if (m_videoG.GetComponent<VideoPlayer>() == null) {
        //            m_videoG.AddComponent<VideoPlayer>();
        //        }
        //        m_videoPlayer = m_videoG.GetComponent<VideoPlayer>();
        //        m_videoPlayer.renderMode = VideoRenderMode.RenderTexture;
        //        m_videoPlayer.isLooping = true;

        //        m_videoPlayer.playOnAwake       = true;
        //        m_videoPlayer.waitForFirstFrame = true;     // ソースVideoの最初のフレームが表示される状態になるまで待機する.
        //    }
        //}

        private void initTexture () {
            if (fileType == MediaType.Image) {
                sphere.SetActive(image != null);
                //videoGameObject.SetActive(false);
                //audioSource.SetActive(false);

                sphereMaterial.SetTexture("_MainTex", image);
                sphereMaterial.SetInt("_Mode", (int)projectonType);
            } else {
                //// VideoClipのパラメータを渡す.
                //sphere.SetActive(video != null);
                //videoGameObject.SetActive(video != null);
                //audioSource.SetActive(video != null);

                //if (videoPlayer == null) return;
                //if (renderTexture != null) {
                //    if (video == null || (renderTexture.width != video.width || renderTexture.height != video.height)) {
                //        if (renderTexture != null) {
                //            Destroy(renderTexture);
                //            renderTexture = null;
                //        }
                //    }
                //}
                //videoPlayer.clip = video;

                //if (video != null) {
                //    int width  = (int)video.width;
                //    int height = (int)video.height;
                //    if (renderTexture == null) {
                //        renderTexture = new RenderTexture(width, height, 0, RenderTextureFormat.ARGB32);
                //        videoPlayer.targetTexture = renderTexture;

                //        {
                //            AudioSource audioSource = audioSource.GetComponent<AudioSource>();
                //            if (audioSource != null) {
                //                videoPlayer.EnableAudioTrack(0, true);
                //                videoPlayer.SetTargetAudioSource(0, audioSource);
                //            }
                //        }
                //    }

                //    if (renderTexture != null) {
                //        sphereMaterial.SetTexture("_MainTex", renderTexture);
                //        sphereMaterial.SetFloat("_Intensity", intensity);
                //        sphereMaterial.SetInt("_Mode", (int)projectonType);
                //        sphereMaterial.SetInt("_TransitionType", 0);
                //    }
                //}
            }
        }
    }
}

