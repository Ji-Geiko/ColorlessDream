using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject flechette;
    public float velocity=4000;
    public bool canDamage;
    public float damageTimer=1;
    public float damageTimerRef = 0.5f;
    public bool canDash=true;
    public bool canDoubleDash = true;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(canDash == true || canDoubleDash == true)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(flechette.transform.position.x - this.transform.position.x, flechette.transform.position.y - this.transform.position.y) * velocity * Time.deltaTime, ForceMode2D.Impulse);
                canDamage = true;
                damageTimer = damageTimerRef;
                if (canDash == true)
                {
                    canDash = false;
                }
                else
                {
                    canDoubleDash = false;
                }
            }
        }

        if (canDamage == true)
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }

        damageTimer -= Time.deltaTime;

        if (damageTimer <= 0)
        {
            canDamage = false;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    void sideCollide(GameObject side)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GetComponent<Rigidbody2D>().gravityScale = 0.01f;

        canDash = true;
        canDoubleDash = true;
    }

    void sideUnCollide(GameObject side)
    {
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "boss"&&canDamage==true)
        {
            collision.gameObject.SendMessage("damage");
            canDamage = false;
        }
    }
}
