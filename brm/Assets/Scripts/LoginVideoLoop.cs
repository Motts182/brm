using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginVideoLoop : MonoBehaviour {

    public MediaPlayerCtrl video;

	void Start () {
	}
	
	void Update () {
        if (video.GetSeekPosition() >= video.GetDuration()-1000)
        {
            video.SeekTo(3500);
        }
	}

    public void pauseVideo()
    {
        video.Pause();
    } 
}
