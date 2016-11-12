using UnityEngine;
using System.Collections;

public class ImageSpawner : MonoBehaviour {

<<<<<<< HEAD
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
=======
	public int cantImg;
	public GameObject[] imgRef;


	void Start (){
	
		for (int i = 0; i < cantImg; i++) {

			GameObject img = Instantiate (imgRef[Random.Range(0,2)], this.transform.position, Quaternion.identity) as GameObject;

			img.GetComponent<ImageMovement> ().ImgPath = "ImagePath" + i;

		}
	}
>>>>>>> nahueBranch
}
