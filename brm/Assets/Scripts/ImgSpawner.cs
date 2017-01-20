using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ImgSpawner : MonoBehaviour
{

    public int cantImg;
    public GameObject imgRef;
    public List<Sprite> spriteList = new List<Sprite>();
    public List<string> imgLinkList = new List<string>();
    public List<GameObject> spawnPoints = new List<GameObject>();
    GameControllerScript GCsc;
    public GameObject loadingBar;
    int h = 0;
    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("SpawnPoint") != null)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("SpawnPoint"))
            {
                spawnPoints.Add(go);
            }
        }
    }

    private void Start()
    {
        GCsc = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        GCsc.RequestByHashtag(GCsc.hashtag);
    }

    public IEnumerator Spawn()
    {

        for (int i = 0; i < spawnPoints.Count; i++)
        {

            //var l = Random.Range (0, spriteList.Count);

            GameObject img = Instantiate(imgRef, spawnPoints[i].transform.position, Quaternion.identity) as GameObject;
            img.GetComponentInChildren<Image>().sprite = spriteList[h];

            if (SceneManager.GetActiveScene().name != "ImageRiver3")
            {

                img.GetComponent<ImageMovement>().ImgPath = "ImagePath" + i;
            }
            img.GetComponent<ImageScript>().imglink = imgLinkList[h];
            img.transform.SetParent(this.transform);
            h++;
        }
        loadingBar.SetActive(false);
        if (h >= spriteList.Count)
        {
            h = 0;
        }
        yield return null;
        StartCoroutine(eliminarfotos());
    }

    public IEnumerator eliminarfotos()
    {
        yield return new WaitForSeconds(10f);
        if (GameObject.FindGameObjectsWithTag("ImgPrefab") != null)
        {
            foreach(GameObject go in GameObject.FindGameObjectsWithTag("ImgPrefab"))
            {
                Destroy(go, 0.1f);
            }
        }
        StartCoroutine(Spawn());
    }
}
