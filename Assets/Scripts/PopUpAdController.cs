using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpAdController : MonoBehaviour
{
    public GameObject ad;

    public float minWaitTime = 0f;
    public float maxWaitTime = 0f;

    public Vector3 center;
    public Vector3 size;

    public bool playing;

    public Vector2 x1y1;
    public Vector2 x2y2;

    float x1 = 0f;
    float y2 = 0f;

    private void OnValidate()
    {
        if (x1y1.x > x2y2.x - 10) x1y1.x = x2y2.x - 10;
        if (x1y1.y >= x2y2.y - 10) x1y1.y = x2y2.y - 10;
    }

    // Start is called before the first frame update
    void Start()
    {
        playing = true;

        //SpawnAds();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnAds()
    {
        StartCoroutine(SpawnAdsRoutine());
    }

    IEnumerator SpawnAdsRoutine()
    {
        while (playing)
        {
            yield return new WaitForSeconds(Random.Range(0, 1));

            Vector3 newPos = Vector3.zero;

            GameObject tempAd = Instantiate(ad, newPos, Quaternion.identity) as GameObject;
        }
    }

    Vector2 GetNewAdPos()
    {
        return Vector2.zero;
    }

    private void OnDrawGizmos()
    {
        // top right
        Vector2 x2y1 = new Vector2(x2y2.x, x1y1.y);

        // bottom left
        Vector2 x1y2 = new Vector2(x1y1.x, x2y2.y);

        // center

        Vector2 x3y3 = new Vector2((x1y1.x + x2y2.x) / 2, (x1y1.y + x2y2.y) / 2);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(x1y1, x2y1);
        Gizmos.DrawLine(x2y1, x2y2);
        Gizmos.DrawLine(x2y2, x1y2);
        Gizmos.DrawLine(x1y2, x1y1);

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(x3y3, 2f);

        //Gizmos.color = Color.black;
        //Gizmos.DrawWireCube(center, size);
        //Gizmos.color = Color.cyan;
        //Gizmos.DrawCube(center, new Vector3(size.x / 2, size.y / 2, 0));
    }
}