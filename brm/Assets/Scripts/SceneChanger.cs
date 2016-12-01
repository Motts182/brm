using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class SceneChanger : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void gifScene()
    {
        SceneManager.LoadScene("posLogin");
    }

    public void videoScene()
    {
        SceneManager.LoadScene("videoScene");
    }

    internal void riverScene(string scene)
    {
        switch (scene)
        {
            case "1":
                SceneManager.LoadScene("VRImageFlowDemoScene");
                break;
            case "2":
                SceneManager.LoadScene("ImageRiver");
                break;
            case "3":
                SceneManager.LoadScene("ImageRiver2");
                break;
            case "4":
                SceneManager.LoadScene("ImageRiver3");
                break;
            case "5":
                SceneManager.LoadScene("ImageRiver4");
                break;
            default:
                Debug.Log("ERROR LOADING RIVER");
                break;
        }
    }

    public void sphereScene()
    {
        SceneManager.LoadScene("SphereScene");
    }

    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name.Equals("login"))
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
        else
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
    }
}
