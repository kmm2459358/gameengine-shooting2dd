using UnityEngine;
using UnityEngine.Video;

public class VideoLooper : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        // VideoPlayer�R���|�[�l���g���擾
        videoPlayer = GetComponent<VideoPlayer>();

        
    }

    
}