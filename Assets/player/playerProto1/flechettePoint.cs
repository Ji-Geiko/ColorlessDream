using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flechettePoint : MonoBehaviour
{
    public bool collide;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collide = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collide = false;
    }

    public bool getCollide()
    {
        return collide;
    }
}
