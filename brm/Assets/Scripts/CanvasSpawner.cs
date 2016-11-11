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
            float radius = 2.5f;
            // "i" now represents the progress around the circle from 0-1
            // we multiply by 1.0 to ensure we get a fraction as a result.
            var i = (pointNum * 1.0) / numPoints;
            // get the angle for this step (in radians, not degrees)
            float angle = (float)(i * Mathf.PI * 2);
            // the X &amp; Y position for this angle are calculated using Sin &amp; Cos
            var x = Mathf.Sin(angle) * radius;
            var z = Mathf.Cos(angle) * radius;
            var pos = new Vector3(x, 1, z);
            // no need to assign the instance to a variable unless you're using it afterwards:
            Instantiate(wordPrefab, pos, Quaternion.identity);
        }
    }

    void Start()
    {
        spawnWords();
    }
}