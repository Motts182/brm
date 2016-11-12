using UnityEngine;
using System.Collections;

public class CanvasSpawner : MonoBehaviour
{


    public GameObject centrePos;
    public GameObject wordPrefab;
    public void spawnWords()
    {
        var numPoints = 52;
        for (var pointNum = 0; pointNum < numPoints; pointNum++)
        {
            float radius = 1.9f;
            var i = (pointNum * 1.0) / numPoints;
            float angle = (float)(i * Mathf.PI * 2);
            var x = Mathf.Sin(angle) * radius;
            var z = Mathf.Cos(angle) * radius;
            var pos = new Vector3(x, 1, z);
            Instantiate(wordPrefab, pos, Quaternion.identity);
        }
    }

    void Start()
    {
        spawnWords();
    }
}