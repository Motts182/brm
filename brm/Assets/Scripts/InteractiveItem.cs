using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class InteractiveItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Image progressImage; // add an image as child to your button object and set its image type to Filled. Assign it to this field in inspector.
    public bool isEntered = false;
    RectTransform rt;
    float timeElapsed;
    Image cursor;

    void Awake()
    {

        rt = GetComponent<RectTransform>();
        progressImage = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<Image>();
    }

    float GazeActivationTime = 3;

    void Update()
    {
        if (isEntered)
        {
            timeElapsed += Time.deltaTime;
            progressImage.fillAmount = Mathf.Clamp(timeElapsed / GazeActivationTime, 0, 1);
            if (GameObject.Find("LoadingBar") != null && GameObject.Find("LoadingBar").activeInHierarchy == true)
            {
                GameObject.Find("LoadingBar").GetComponentInChildren<SpriteRenderer>().enabled = false;
                GameObject.Find("LoadingBar").GetComponentInChildren<Text>().text = "";
            }

            if (timeElapsed >= GazeActivationTime)
            {
                timeElapsed = 0;
                progressImage.fillAmount = 0;
                isEntered = false;
                if (gameObject.tag == "ImgPrefab")
                {
                    Debug.Log("He seleccionado una imagen");
                }
                else if (gameObject.tag == "ReturnCanvas")
                {
                    gameObject.GetComponent<ButtonAction>().sphereScene();

                }
                else if (gameObject.tag == "ExitCanvas")
                {
                    gameObject.GetComponent<ButtonAction>().exit();
                    Debug.Log("He seleccionado el boton de Exit");
                }
                else if (gameObject.tag == "VideoPanel")
                {
                    transform.transform.parent.parent.GetComponent<ButtonAction>().cinemaScene();
                }
                else if (gameObject.tag == "Word")
                {
                    gameObject.transform.parent.parent.GetComponent<ButtonAction>().riverSceneRandom(gameObject.GetComponentInChildren<WordScript>().wordText.text);
                }
                else if(gameObject.tag == "VideoReturnCanvas")
                {
                    gameObject.GetComponent<ButtonAction>().videoScene();
                }

            }
        }
        else
        {
            timeElapsed = 0;
            if (GameObject.Find("LoadingBar") != null)
            {
                GameObject.Find("LoadingBar").GetComponentInChildren<SpriteRenderer>().enabled = true;
                GameObject.Find("LoadingBar").GetComponentInChildren<Text>().text = "Cargando";
            }
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


