using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WordScript : MonoBehaviour
{

    int minDist = 5;
    int speed = 1000;
    [SerializeField]
    float distance;
    Vector3 camRef;
    public Text wordText;

    void Awake()
    {
        camRef = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
    }

    void Start()
    {
        wordText = GetComponentInChildren<Text>();
        if (wordText != null)
        {
            wordText.fontSize = 25;
            wordText.text = "|" + Random.Range(1234567890, 2000000000).ToString() + "|";
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
    public void setHashtag()
    {
        GetComponentInParent<ButtonAction>().riverSceneRandom(wordText.text);
    }
}
