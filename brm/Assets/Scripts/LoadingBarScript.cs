using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingBarScript : MonoBehaviour
{
        public GameObject loadingbar;
    public float timer;

    public IEnumerator loading()
    {
        yield return new WaitForSeconds(5f);
        loadingbar.SetActive(false);
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("ImgPrefab") != null && GameObject.Find("VideoManager") == null)
        {
            loadingbar.SetActive(false);
        }
        else if (GameObject.Find("VideoManager") != null)
        {
            StartCoroutine(loading());
        }
    }
}
