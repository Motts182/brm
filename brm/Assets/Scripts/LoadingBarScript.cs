using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingBarScript : MonoBehaviour
{
    public GameObject loadingbar;
    public float timer;
    public MeshRenderer gvrReticleMeshRendererRef;
    public IEnumerator loading()
    {
        yield return new WaitForSeconds(5f);
        gvrReticleMeshRendererRef.enabled = true;
        loadingbar.SetActive(false);
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("ImgPrefab") != null && GameObject.Find("VideoManager") == null)
        {
            gvrReticleMeshRendererRef.enabled = true;
            loadingbar.SetActive(false);
        }
        else if (GameObject.FindGameObjectWithTag("WordCanvas") != null)
        {
            gvrReticleMeshRendererRef.enabled = true;
            loadingbar.SetActive(false);
        }
        else if (GameObject.Find("VideoManager") != null)
        {
            StartCoroutine(loading());
        }
    }

    private void Start()
    {
        if (GameObject.Find("GvrReticle") != null)
        {
            gvrReticleMeshRendererRef = GameObject.Find("GvrReticle").GetComponent<MeshRenderer>();
        }
        gvrReticleMeshRendererRef.enabled = false;
    }
}
