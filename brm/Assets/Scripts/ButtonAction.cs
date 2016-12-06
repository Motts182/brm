using UnityEngine;

public class ButtonAction : MonoBehaviour
{

    public void riverSceneRandom()
    {
        if (GameObject.FindGameObjectWithTag("SceneChanger") != null)
        {
            GameObject.FindGameObjectWithTag("SceneChanger").GetComponent<SceneChanger>().riverScene(Random.Range(0, 5).ToString());
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

    public void cinemaScene()
    {
        if (GameObject.FindGameObjectWithTag("SceneChanger") != null)
        {
            GameObject.FindGameObjectWithTag("SceneChanger").GetComponent<SceneChanger>().cinemaScene();
        }
        else
        {
            print("No hay SceneChanger");
        }
    }
}
