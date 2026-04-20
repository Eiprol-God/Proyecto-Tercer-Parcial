using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
public class LogoEndCheck : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public string sceneName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        // Subscribe to the event
        videoPlayer.loopPointReached += OnVideoEnd;

    }
    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(sceneName);
    }

    void OnDestroy()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= OnVideoEnd;
        }
    }

}
