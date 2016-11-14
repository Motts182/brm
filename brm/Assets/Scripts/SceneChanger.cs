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

    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("posLogin"))
        {
            if(Time.deltaTime >= 5)
            {
                sphereScene();
            }
        }
    }

    public void sphereScene()
    {
        SceneManager.LoadScene("SphereScene");
    }
}
