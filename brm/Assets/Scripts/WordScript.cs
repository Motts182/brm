using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WordScript : MonoBehaviour {
    [SerializeField]
    public GameObject cameraPos;
    
	void Update () {
        transform.LookAt(cameraPos.transform);        
	}

    void Awake()
    {
        
    }
}
