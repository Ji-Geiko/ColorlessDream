using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int life=20;

    private void Update()
    {
       
    }

    void damage()
    {
        life--;
        GetComponent<SpriteRenderer>().color = Color.green;
        if (life == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
