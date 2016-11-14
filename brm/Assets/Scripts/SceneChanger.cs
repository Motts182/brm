using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class SceneChanger : MonoBehaviour {


    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void gifScene()
    {
        SceneManager.LoadScene("posLogin");
    }

    internal void riverScene()
    {
        SceneManager.LoadScene("ImageRiver2");
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
