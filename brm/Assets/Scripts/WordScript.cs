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
        wordText = GetComponentInChildren<Text>();
        GetComponent<Button>().onClick.AddListener(() => { GameObject.Find("CanvasObject(Clone)").GetComponent<ButtonAction>().riverSceneRandom(wordText.text); });
    }

    void Update()
    {

        if (Vector3.Distance(this.transform.position, camRef) > 4f)
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
