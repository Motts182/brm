using UnityEngine;
using System.Collections;

public class ButtonAction : MonoBehaviour {

    public void returntoRiver()
    {
        GameObject.FindGameObjectWithTag("SceneChanger").GetComponent<SceneChanger>().riverScene(Random.Range(0, 2).ToString());
    }

    public void returntoSphere()
    {
        GameObject.FindGameObjectWithTag("SceneChanger").GetComponent<SceneChanger>().sphereScene();
    }

    public void exit()
    {
        Application.Quit();
    }
}
