using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoHandling : MonoBehaviour
{
    RawImage rawImage;
    VideoPlayer videoPlayer;

    private void Start()
    {
        rawImage = GetComponent<RawImage>();
        videoPlayer = GetComponent<VideoPlayer>();
    }

    public IEnumerator PlayVideo() {
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared) {
            yield return waitForSeconds;
            break;
        }
        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
    }

    public bool VideoOver() {
        return !videoPlayer.isPlaying || videoPlayer.frame >= (long)videoPlayer.frameCount;
    }


    public void setVideo(VideoClip videoClip) {
        videoPlayer.clip = videoClip;
    }
}
