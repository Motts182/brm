using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginVideoLoop : MonoBehaviour
{

    public MediaPlayerCtrl scrMedia;

    void Start()
    {
    }

    void Update()
    {
        if (scrMedia.m_strFileName.Equals("LoginVideo.mp4") && scrMedia.GetSeekPosition() >= scrMedia.GetDuration() - 1000)
        {
            scrMedia.SeekTo(3500);
        }

        if (scrMedia.m_strFileName.Equals("ContinueVideo.mp4") && scrMedia.GetSeekPosition() >= scrMedia.GetDuration() - 1000)
        {
            scrMedia.SeekTo(1200);
        }

        if (scrMedia.m_strFileName.Equals("cardboard.mp4") && scrMedia.GetSeekPosition() >= scrMedia.GetDuration() - 500)
        {
            scrMedia.SeekTo(1500);
        }
    }

    public void pauseVideo()
    {
        scrMedia.Pause();
    }

    public void continueVideo()
    {
        scrMedia.Stop();
        scrMedia.Load("ContinueVideo.mp4");
        scrMedia.Play();
    }
}
