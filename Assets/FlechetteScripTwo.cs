using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechetteScripTwo : MonoBehaviour
{
    public GameObject playerParent;

    void Update()
    {
        /*if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePos = Input.mousePosition;
            {
                Debug.Log(mousePos.x+ "¦¦" + mousePos.y);
            }
        }*/
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        //Vector3 direction = new Vector3(mousePosition.x - gameObject.transform.position.x, mousePosition.y, transform.position.y);
        Vector3 direction = new Vector3(mousePosition.x - gameObject.transform.position.x, mousePosition.y-transform.position.y, 0);
        gameObject.transform.up = direction;
        //gameObject.transform.up = mousePosition;
        transform.rotation =new Quaternion(0,0,transform.rotation.z,transform.rotation.w);
    }
}
