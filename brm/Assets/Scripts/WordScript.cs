using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WordScript : MonoBehaviour
{

    int minDist = 5;
    int speed = 1000;
    [SerializeField]
    float distance;

    void Awake()
    {
    }

    void Start()
    {
        var font = GetComponentInChildren<Text>();
        if (font != null)
        {
            font.fontSize = 15;
            font.text = "|" + Random.Range(1000000, 2000000).ToString() + "|";
        }
    }

    void Update()
    {
        var camRef = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
        if (Vector3.Distance(this.transform.position, camRef) > 3f)
        {
            transform.position = Vector3.MoveTowards(transform.position, camRef, 0.05f);
        }
    }
}
