using UnityEngine;
using System.Collections;

public class ButtonAction : MonoBehaviour {

    public void returntoRiver()
    {
        GameObject.FindGameObjectWithTag("SceneChanger").GetComponent<SceneChanger>().riverScene();
    }

    public void returntoSphere()
    {
        GameObject.FindGameObjectWithTag("SceneChanger").GetComponent<SceneChanger>().sphereScene();
    }
}
