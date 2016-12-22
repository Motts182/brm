using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class InteractiveItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image progressImage; // add an image as child to your button object and set its image type to Filled. Assign it to this field in inspector.
    public bool isEntered = false;
    RectTransform rt;
    float timeElapsed;
    Image cursor;
    // Use this for initialization
    void Awake()
    {

        rt = GetComponent<RectTransform>();

    }

    float GazeActivationTime = 3;

    void Update()
    {
        if (isEntered)
        {
            timeElapsed += Time.deltaTime;
            progressImage.fillAmount = Mathf.Clamp(timeElapsed / GazeActivationTime, 0, 1);
            //Debug.Log(progressImage.fillAmount);
            if (timeElapsed >= GazeActivationTime)
            {
                timeElapsed = 0;
                Debug.Log("Action Selected");
                // aca va la real mecanica española, hay que tener en cuenta que van a haber acciones distintas que se van a accionar de la misma forma y aca no esta contemplado.
                progressImage.fillAmount = 0;
                isEntered = false;
            }
        }
        else
        {
            timeElapsed = 0;
        }
    }

    #region IPointerEnterHandler implementation

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("hola");
        isEntered = true;
    }

    #endregion

    #region IPointerExitHandler implementation

    public void OnPointerExit(PointerEventData eventData)
    {
       // Debug.Log("chau");
        isEntered = false;
        progressImage.fillAmount = 0;
    }
    #endregion
}


