using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {


    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void gifScene()
    {
        SceneManager.LoadScene("preLogin");
    }
}
