using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using LitJson;

public class CanvasSpawner : MonoBehaviour
{


    public GameObject centrePos;
    public GameObject CanvasPrefab;
    public bool spawned = true;
    public List<string> nombres;
    public List<string> puestos;
    public List<string> urls;
    public List<string> palabras;
    public JsonData data;
    public WWW xmlRequest;
    int f = 0;

    public IEnumerator spawnWords()
    {
        yield return xmlRequest;
        if (spawned)
        {
            var numPoints = 25;
            for (var pointNum = 0; pointNum < numPoints; pointNum++)
            {
                float radius = 4.5f;
                var i = (pointNum * 1.0) / numPoints;
                float angle = (float)(i * Mathf.PI * 2);
                var x = Mathf.Sin(angle) * radius;
                var z = Mathf.Cos(angle) * radius;
                var pos = new Vector3(x, 1, z);
                GameObject go = Instantiate(CanvasPrefab, pos, Quaternion.identity) as GameObject;
                go.transform.SetParent(GameObject.Find("WordSphere").transform);
                go.GetComponentInChildren<WordCanvasScript>().videoLink = urls[pointNum];
                go.transform.GetChild(0).GetComponentInChildren<VideoButtonScript>().wordText.text = nombres[pointNum];
                foreach (WordScript wt in go.transform.GetChild(0).GetComponentsInChildren<WordScript>())
                {
                    wt.wordText.text = palabras[f];
                    f++;
                }
                spawned = false;
                yield return null;
            }
        }
        else if (!spawned)
        {
            var numPoints = 24;
            for (var pointNum = 0; pointNum < numPoints; pointNum++)
            {
                float radius = 4.5f;
                var i = (pointNum * 1.0) / numPoints;
                float angle = (float)(i * Mathf.PI * 2);
                var x = Mathf.Sin(angle) * radius;
                var z = Mathf.Cos(angle) * radius;
                var pos = new Vector3(x, 1, z);
                GameObject go = Instantiate(CanvasPrefab, pos, Quaternion.identity) as GameObject;
                go.transform.SetParent(GameObject.Find("WordSphere").transform);
                go.GetComponentInChildren<WordCanvasScript>().videoLink = urls[pointNum + 24];
                go.transform.GetChild(0).GetComponentInChildren<VideoButtonScript>().wordText.text = nombres[pointNum + 24];
                foreach (WordScript wt in go.transform.GetChild(0).transform.GetComponentsInChildren<WordScript>())
                {
                    wt.wordText.text = palabras[f];
                    f++;
                }
                spawned = true;
                yield return null;
            }
            f = 0;
        }
    }

    void Start()
    {
        StartCoroutine(ParseXML());
        StartCoroutine(spawnWords());
    }

    void FixedUpdate()
    {
        if (Time.time % 45 == 0 && Time.time > 1)
        {
            respawnWords();
        }
    }
    public void respawnWords()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("WordCanvas"))
        {
            Destroy(go, 0.1f);
        }
        StartCoroutine(spawnWords());
    }
    public IEnumerator ParseXML()
    {
        xmlRequest = new WWW("http://www.brm.com.co/appbrm/personas.php");

        yield return xmlRequest;
        if (xmlRequest.isDone)
        {
            if (xmlRequest.error == null)
            {
                data = JsonMapper.ToObject(xmlRequest.text);
                for (int i = 0; i < data["data"]["nombreMenu"].Count; i++)
                {
                    palabras.Add(data["data"]["nombreMenu"][i]["hash"].ToString().ToUpper());
                }
                for (int i = 0; i < data["data"]["personas"].Count; i++)
                {
                    nombres.Add(data["data"]["personas"][i]["nombre"].ToString().ToUpper());
                    puestos.Add(data["data"]["personas"][i]["puesto"].ToString().ToUpper());
                    urls.Add(data["data"]["personas"][i]["url"].ToString());
                }

            }
            else
            {
                print("Error: " + xmlRequest.error);
            }
        }
    }
}