using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordCanvasScript : MonoBehaviour
{

    void Start()
    {
        var cameraPos = GameObject.FindGameObjectWithTag("MainCamera");
        transform.LookAt(cameraPos.transform.position); /*2 * transform.position - */
    }

    void Update()
    {

    }
}
