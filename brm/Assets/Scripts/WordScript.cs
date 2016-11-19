using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WordScript : MonoBehaviour
{

    GameObject cameraPos;
    int minDist = 5;
    int speed = 1000;

    void Start()
    {
        cameraPos = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        transform.LookAt(2 * transform.position - cameraPos.transform.position);
        if (Vector3.Distance(transform.position, cameraPos.transform.position) >= minDist)
        {
            transform.position = Vector3.MoveTowards(transform.position, cameraPos.transform.position, speed);
        }

    }
}
