using UnityEngine;
using System.Collections;

public class YoutubeEasyMovieTexture : MonoBehaviour
{

    public string youtubeVideoIdOrUrl;

	void Start () {
        youtubeVideoIdOrUrl = GameObject.Find("GameController").GetComponent<GameControllerScript>().videoLink;
        LoadYoutubeInTexture();
    }

    public void LoadYoutubeInTexture()
    {
        gameObject.GetComponent<MediaPlayerCtrl>().m_strFileName = YoutubeVideo.Instance.RequestVideo(youtubeVideoIdOrUrl,360);
        
    }
}
