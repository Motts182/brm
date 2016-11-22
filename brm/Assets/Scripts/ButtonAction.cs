using UnityEngine;

public class ButtonAction : MonoBehaviour
{

    public void riverSceneRandom()
    {
        GameObject.FindGameObjectWithTag("SceneChanger").GetComponent<SceneChanger>().riverScene(Random.Range(0, 2).ToString());
    }

    public void sphereScene()
    {
        GameObject.FindGameObjectWithTag("SceneChanger").GetComponent<SceneChanger>().sphereScene();
    }

    public void exit()
    {
        Application.Quit();
    }
    

    public void videoScene()
    {
        GameObject.FindGameObjectWithTag("SceneChanger").GetComponent<SceneChanger>().videoScene();
    }
}
