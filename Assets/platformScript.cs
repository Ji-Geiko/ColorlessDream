using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformScript : MonoBehaviour
{
    public bool startTimer;
    public float destroyTimer = 3;

    private void Start()
    {
        //transform.rotation = new Quaternion(0, 0, Random.Range(-90, 90),0);
    }

    void Update()
    {

        if (gameObject.GetComponent<SpriteRenderer>().isVisible == false)
        {
            startTimer = true;
            if (destroyTimer <= 0)
            {
                Destroy(gameObject);
                print("awd");
            }
        }
        else
        {
            startTimer = false;
        }

        if (startTimer == true)
        {
            destroyTimer -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "wall"|| collision.tag=="boss")
        {
            Destroy(gameObject);
        }    
    }
}