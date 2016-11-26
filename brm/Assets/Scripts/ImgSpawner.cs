using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ImgSpawner : MonoBehaviour {

    public int cantImg;
    public GameObject imgRef;
    public List<Sprite> spriteList = new List<Sprite>();
    public List<string> imgLinkList = new List<string>();

    public IEnumerator Spawn()
    {
        for (int i = 0; i < cantImg; i++)
        {
            GameObject img = Instantiate(imgRef, this.transform.position, Quaternion.identity) as GameObject;
            img.GetComponentInChildren<Image>().sprite = spriteList[Random.Range(0, spriteList.Count)];
            img.GetComponent<ImageMovement>().ImgPath = "ImagePath" + i;
            img.transform.SetParent(this.transform);
            yield return new WaitForSeconds(5f);
        }
    }
}
