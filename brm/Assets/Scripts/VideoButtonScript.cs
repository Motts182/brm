using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoButtonScript : MonoBehaviour {

    public Text wordText;
    [SerializeField]
    float distance;
    Vector3 camRef;

    void Awake()
    {
        camRef = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
        wordText = GetComponentInChildren<Text>();
        if (wordText != null)
        {
            wordText.fontSize = 25;
        }
    }
    void Update()
    {

        if (Vector3.Distance(this.transform.position, camRef) > 3.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, camRef, 0.05f);
        }
        else
        {
            transform.LookAt(2 * transform.position - camRef);
            distance = Vector3.Distance(this.transform.position, camRef);
        }

    }
}
