using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechetteScript : MonoBehaviour
{
    public GameObject playerParent;

    public GameObject pointRight;
    public GameObject pointLeft;
    public GameObject pointUp;

    public bool pointRightBool;
    public bool pointLeftBool;
    public bool pointUpBool;

    public float speed = 1;

    public bool returnUp;

    void Update()
    {
        pointUpBool = pointUp.GetComponent<flechettePoint>().getCollide();
        pointRightBool = pointRight.GetComponent<flechettePoint>().getCollide();
        pointLeftBool = pointLeft.GetComponent<flechettePoint>().getCollide();

        if (returnUp == false)
        {
            if (pointRightBool == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, pointRight.transform.position, speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, pointLeft.transform.position, speed * Time.deltaTime);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, pointUp.transform.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "pointUp")
        {
            print("pointUP");
            returnUp = false;
        }
        else if(collision.tag!="Player")
        {
            print("other");

            returnUp = true;
        }
    }
}