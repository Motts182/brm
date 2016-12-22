using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageMovement2 : MonoBehaviour
{
    public bool rotate = false;
    void Start()
    {
        float f = Random.Range(1f, 2f);
        iTween.ScaleTo(gameObject, iTween.Hash(
                                                "scale", new Vector3(f, f, 1f),
                                                "delay", 1f,
                                                "time", 3f,
                                                "loopType", "pingPong",
                                                "easetype", iTween.EaseType.easeInOutSine,
                                                "oncomplete", "rotationTrue",
                                                "onstart", "rotationFalse"
                                                ));
        Destroy(this.gameObject, 10f);
    }

    void rotationFalse()
    {
        rotate = false;
    }

    void rotationTrue()
    {
        rotate = true;
    }

    private void Update()
    {
        if (rotate)
        {
            transform.Rotate(0, Time.time * Random.Range(0f, 0.5f), 0);
        }
        else
        {
            transform.LookAt(2 * transform.position - GameObject.FindGameObjectWithTag("MainCamera").transform.position);
        }
    }
}
