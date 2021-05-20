using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    public GameObject playerParent;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "wall" || collision.tag == "boss")
        {
            playerParent.SendMessage("sideCollide", this.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "wall"|| collision.tag == "boss")
        {
            playerParent.SendMessage("sideUnCollide", this.gameObject);
        }
    }
}
