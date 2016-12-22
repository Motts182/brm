using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageMovement : MonoBehaviour
{
    public string ImgPath;
    Image image;
    float aux;
    public float decAlpha = 0.005f;
    bool alphaOn;

    void Awake()
    {
        aux = 1f;
        image = GetComponentInChildren<Image>();
    }

     void Update()
    {
        transform.LookAt(2 * transform.position - GameObject.FindGameObjectWithTag("MainCamera").transform.position);
    }
    void Start()
    {
        iTween.FadeTo(gameObject, iTween.Hash(
                                                "alpha", 1f,
                                                "time", 1f,
                                                "delay", 9f,
                                                "onstart", "formatAlpha"
                                                //"oncomplete", "alphaOnMetod1"
                                                ));
        iTween.ScaleTo(gameObject, iTween.Hash(
                                                "scale", new Vector3(2f, 2f, 1f),
                                                "time", 10f,
                                                "loopType", "loop",
                                                "easetype", iTween.EaseType.easeInOutSine
                                                ));
        iTween.MoveTo(gameObject, iTween.Hash(
                                                "path", iTweenPath.GetPath(ImgPath),
                                                "time", 10f,
                                                "loopType", "loop",
                                                "easetype", iTween.EaseType.easeInOutSine
                                                ));
    }


    void formatAlpha() {
        aux = 1;
    }

    void alphaOnMetod(bool val) {
        print(val);
        alphaOn = val;
    }

    void alphaOnMetod1()
    {
        print(true);
        alphaOn = true;
    }



    private void FixedUpdate()
    {
        if (alphaOn) {
            aux -= decAlpha;
            image.material.SetColor("_Color", new Color(1, 1, 1, aux));
            if (aux <= 0) {
                print("aux " + aux);

                formatAlpha();
                alphaOnMetod(false);
            }
        }
    }
}
