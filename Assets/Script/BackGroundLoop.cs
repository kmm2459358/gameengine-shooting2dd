using UnityEngine;
using UnityEngine.Video;

public class VideoLooper : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        // VideoPlayerコンポーネントを取得
        videoPlayer = GetComponent<VideoPlayer>();

        
    }

    
}