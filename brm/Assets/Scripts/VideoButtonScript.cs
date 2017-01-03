using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoButtonScript : MonoBehaviour {

    public Text wordText;

    void Awake()
    {
        wordText = GetComponentInChildren<Text>();
        if (wordText != null)
        {
            wordText.fontSize = 25;
        }
    }
}
