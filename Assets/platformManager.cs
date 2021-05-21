using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformManager : MonoBehaviour
{
    public Camera mainCam;
    public GameObject platformPrefab;

    public GameObject rightPoint;
    public GameObject leftPoint;
    public GameObject upPoint;
    public GameObject downPoint;

    public float timer = 1;


    public List<GameObject> platforms = null;


    void Start()
    {
        transform.position = mainCam.gameObject.transform.position;

        GameObject gameObject = Instantiate(platformPrefab, rightPoint.transform.position, Quaternion.identity);
        platforms.Add(gameObject);
    }

    private void Update()
    {
        if (platforms != null && timer <= 0)
        {
            foreach (GameObject platformOfList in platforms)
            {
                timer = 1;

                if (goodDistance(leftPoint) == true)
                {
                    Vector3 position = new Vector3(/*x*/ leftPoint.transform.position.x + Random.Range(-5, 5),/*y*/ leftPoint.transform.position.y + Random.Range(-5, 5));
                    GameObject platform = Instantiate(platformPrefab, position, Quaternion.Euler(new Vector3(0, 0, Random.Range(-90, 90))));
                    platforms.Add(platform);
                }

                if (goodDistance(rightPoint) == true)
                {
                    Vector3 position = new Vector3(/*x*/ rightPoint.transform.position.x + Random.Range(-5, 5),/*y*/ rightPoint.transform.position.y + Random.Range(-5, 5));
                    GameObject platform = Instantiate(platformPrefab, position, Quaternion.Euler(new Vector3(0, 0, Random.Range(-90, 90))));
                    platforms.Add(platform);
                }

                if (goodDistance(upPoint) == true)
                {
                    Vector3 position = new Vector3(/*x*/ upPoint.transform.position.x + Random.Range(-5, 5),/*y*/ upPoint.transform.position.y + Random.Range(-5, 5));
                    GameObject platform = Instantiate(platformPrefab, position, Quaternion.Euler(new Vector3(0, 0, Random.Range(-90, 90))));
                    platforms.Add(platform);
                }

                if (goodDistance(downPoint) == true)
                {
                    Vector3 position = new Vector3(/*x*/ downPoint.transform.position.x + Random.Range(-5, 5),/*y*/ downPoint.transform.position.y + Random.Range(-5, 5));
                    GameObject platform = Instantiate(platformPrefab, position, Quaternion.Euler(new Vector3(0,0,Random.Range(-90,90))));
                    platforms.Add(platform);
                }
            }
        }
        timer -= Time.deltaTime;
    }

    bool goodDistance(GameObject objectToCheck)
    {
        foreach (GameObject GObject in GameObject.FindGameObjectsWithTag("wall"))
        {
            if (Vector3.Distance(GObject.transform.position, objectToCheck.transform.position) <= 5)
            {
                return false;
            }
        }
        return true;
    }
}
