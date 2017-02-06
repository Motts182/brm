using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardboardPlacementSceneScript : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(nextScene());
    }

    public IEnumerator nextScene()
    {
        yield return new WaitForSeconds(10);
        GameObject.Find("SceneManager").GetComponent<SceneChanger>().videoScene();
    }
}
