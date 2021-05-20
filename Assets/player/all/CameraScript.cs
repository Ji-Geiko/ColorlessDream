using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform objectToFollow;
    public bool GoX;
    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public string cameraSize;

    void Update()
    {
        //transform.position = new Vector3(objectToFollow.position.x, transform.position.y, transform.position.z);
        Vector3 point = Camera.main.WorldToViewportPoint(objectToFollow.position);
        Vector3 delta = objectToFollow.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
        Vector3 destination = transform.position + delta;
        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);

        if (cameraSize == "CameraSize1")
        {
            if(GetComponent<Camera>().orthographicSize < 5)
            {
                GetComponent<Camera>().orthographicSize += 1 * Time.deltaTime;
            }else if (GetComponent<Camera>().orthographicSize > 5)
            {
                GetComponent<Camera>().orthographicSize -= 1 * Time.deltaTime;
            }

            if (GetComponent<Camera>().orthographicSize == 5)
            {
                cameraSize = "null";
            }
        }
        else if (cameraSize == "CameraSize2")
        {
            if (GetComponent<Camera>().orthographicSize < 25)
            {
                GetComponent<Camera>().orthographicSize += 1 * Time.deltaTime;
            }
            else if (GetComponent<Camera>().orthographicSize > 25)
            {
                GetComponent<Camera>().orthographicSize -= 1 * Time.deltaTime;
            }

            if (GetComponent<Camera>().orthographicSize == 25)
            {
                cameraSize = "null";
            }
        }
        else if (cameraSize == "CameraSize3")
        {
            if (GetComponent<Camera>().orthographicSize < 50)
            {
                GetComponent<Camera>().orthographicSize += 1 * Time.deltaTime;
            }
            else if (GetComponent<Camera>().orthographicSize > 50)
            {
                GetComponent<Camera>().orthographicSize -= 1 * Time.deltaTime;
            }

            if (GetComponent<Camera>().orthographicSize == 50)
            {
                cameraSize = "null";
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CameraSize1")
        {
            cameraSize = collision.tag;
        }
        else if(collision.tag == "CameraSize2")
        {
            cameraSize = collision.tag;

        }
        else if(collision.tag == "CameraSize3")
        {
            cameraSize = collision.tag;
        }
    }
}
