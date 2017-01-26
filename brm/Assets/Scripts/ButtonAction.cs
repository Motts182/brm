using UnityEngine;
using UnityEngine.Events;

public class ButtonAction : MonoBehaviour
{

    public UnityAction riverSceneRandom(string hashtag)
    {
        GameObject.Find("GameController").GetComponent<GameControllerScript>().hashtag = hashtag;
        if (GameObject.FindGameObjectWithTag("SceneChanger") != null)
        {
            GameObject.FindGameObjectWithTag("SceneChanger").GetComponent<SceneChanger>().riverScene(Random.Range(1, 5).ToString());
        }
        else
        {
            print("No hay SceneChanger");
        }
        return null;
    }
    public void riverSceneRandom()
    {
        if (GameObject.FindGameObjectWithTag("SceneChanger") != null)
        {
            GameObject.FindGameObjectWithTag("SceneChanger").GetComponent<SceneChanger>().riverScene(Random.Range(1, 5).ToString());
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
            GameObject.Find("GameController").GetComponent<GameControllerScript>().videoLink = GetComponent<WordCanvasScript>().videoLink;
            GameObject.FindGameObjectWithTag("SceneChanger").GetComponent<SceneChanger>().cinemaScene();
        }
        else
        {
            print("No hay SceneChanger");
        }
    }
}
