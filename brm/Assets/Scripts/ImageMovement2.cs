using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageMovement2 : MonoBehaviour
{
    public bool rotate = false;
    void Start()
    {
        iTween.ScaleTo(gameObject, iTween.Hash(
                                                "scale", new Vector3(1.3f, 1.3f, 1f),
                                                "delay", 1f,
                                                "time", 3f,
                                                "loopType", "pingPong",
                                                "easetype", iTween.EaseType.easeInOutSine,
                                                "oncomplete", "rotationTrue",
                                                "onstart", "rotationFalse"
                                                ));
        Destroy(gameObject, 5f);
    }

    void rotationFalse()
    {
        rotate = false;
    }

    void rotationTrue()
    {
        rotate = true;
    }

    private void FixedUpdate()
    {
        if(rotate)
        transform.Rotate(0, Time.time*0.5f, 0);
    }
    
}
