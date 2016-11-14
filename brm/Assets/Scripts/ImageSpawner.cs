using UnityEngine;
using System.Collections;

public class ImageSpawner : MonoBehaviour {


    public GameObject[] imgPrefabs = new GameObject[3];
    public GameObject[] spawnPoints = new GameObject[3];

	void Start()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject img = Instantiate(imgPrefabs[i], spawnPoints[i].transform.position, Quaternion.identity) as GameObject;
            img.GetComponent<ImgFlow>().pathName = "ImgPath" + (i+1);
        }
        


    }

}
