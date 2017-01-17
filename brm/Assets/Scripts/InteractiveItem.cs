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
        progressImage = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<Image>();
    }

    float GazeActivationTime = 5;

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
                progressImage.fillAmount = 0;
                isEntered = false;
                Debug.Log(gameObject.tag);
                // aca va la real mecanica española, hay que tener en cuenta que van a haber acciones distintas que se van a accionar de la misma forma y aca no esta contemplado.
                if (gameObject.tag == "ImgPrefab")
                {
                    Debug.Log("He seleccionado una imagen");
                }
                else if (gameObject.tag == "ReturnCanvas")
                {

                    gameObject.GetComponent<ButtonAction>().sphereScene();
                    Debug.Log("He seleccionado el boton de regreso");
                }
                else if (gameObject.tag == "ExitCanvas")
                {
                    gameObject.GetComponent<ButtonAction>().exit();
                    Debug.Log("He seleccionado el boton de Exit");
                }
                else if (gameObject.tag == "VideoPanel")
                {
                    Debug.Log(gameObject.tag);
                    transform.transform.parent.parent.GetComponent<ButtonAction>().cinemaScene();
                }
                else if (gameObject.tag == "Word") {
                    print(gameObject.tag);
                    gameObject.transform.parent.parent.GetComponent<ButtonAction>().riverSceneRandom(gameObject.GetComponentInChildren<WordScript>().wordText.text);
                }

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

        isEntered = true;
    }

    #endregion

    #region IPointerExitHandler implementation

    public void OnPointerExit(PointerEventData eventData)
    {

        isEntered = false;
        progressImage.fillAmount = 0;
    }
    #endregion
}


