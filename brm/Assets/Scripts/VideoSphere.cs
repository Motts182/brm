using UnityEngine;
using System.Collections;

public class VideoSphere : MonoBehaviour
{
    public MovieTexture video;
    public AudioSource audios;
    void Start()
    {
        GetComponent<Renderer>().material.mainTexture = video;
        audios = GetComponent<AudioSource>();
        video.loop = true;
        video.Play();
        audios.Play();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && video.isPlaying)
        {
            video.Pause();
            audios.Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !video.isPlaying)
        {
            video.Play();
            audios.Play();
        }
    }
}
