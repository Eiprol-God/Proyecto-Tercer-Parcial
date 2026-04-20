

using UnityEngine;
using UnityEngine.Video; // Required for the VideoPlayer class

public class VideoEndChecker : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public GameObject videoPanel;
    public AudioSource audioSource;

    void Start()
    {
        Time.timeScale = 0;
        videoPlayer = GetComponent<VideoPlayer>();
        // Subscribe to the event
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    // This method will be called when the video finishes
    void OnVideoEnd(VideoPlayer vp)
    {
        videoPanel.SetActive(false);
        audioSource.Play();
        Time.timeScale = 1;
    }


    void OnDestroy()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= OnVideoEnd;
        }
    }
}
