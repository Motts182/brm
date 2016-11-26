using UnityEngine;
using System.Collections;

public class ImageScript : MonoBehaviour
{
    void Start()
    {

    }

    public void imagePausePath()
    {
        iTween.Pause();
    }

    public void imageResumePath()
    {
        iTween.Resume();
    }
}
