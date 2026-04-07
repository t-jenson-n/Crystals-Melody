using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class WebGLVideoLoader : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string fileName = "intro.mp4";

    void Start()
    {
        string url = System.IO.Path.Combine(Application.streamingAssetsPath, fileName);
        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = url;

        videoPlayer.Prepare();
        videoPlayer.prepareCompleted += OnPrepared;
    }

    void OnPrepared(VideoPlayer vp)
    {
        vp.Play();
    }
}