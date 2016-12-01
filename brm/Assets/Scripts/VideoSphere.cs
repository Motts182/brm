using UnityEngine;
using System.Collections;

public class VideoSphere : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(changeScene());
    }

    public IEnumerator changeScene()
    {
        yield return new WaitForSeconds(30f);
        GameObject.Find("SceneManager").GetComponent<SceneChanger>().sphereScene();
    }
}
