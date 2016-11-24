using UnityEngine;

public class ButtonAction : MonoBehaviour
{

    public void riverSceneRandom()
    {
        if (GameObject.FindGameObjectWithTag("SceneChanger") != null)
        {
            GameObject.FindGameObjectWithTag("SceneChanger").GetComponent<SceneChanger>().riverScene(Random.Range(0, 2).ToString());
        }
        else
        {
            print("No hay SceneChanger");
        }
    }

    public void sphereScene()
    {
        if (GameObject.FindGameObjectWithTag("SceneChanger") != null)
        {
            GameObject.FindGameObjectWithTag("SceneChanger").GetComponent<SceneChanger>().sphereScene();
        }
        else
        {
            print("No hay SceneChanger");
        }
    }

    public void exit()
    {
        Application.Quit();
    }


    public void videoScene()
    {
        if (GameObject.FindGameObjectWithTag("SceneChanger") != null)
        {
            GameObject.FindGameObjectWithTag("SceneChanger").GetComponent<SceneChanger>().videoScene();
        }
        else
        {
            print("No hay SceneChanger");
        }
    }

    public void replayVideo()
    {

    }
}
