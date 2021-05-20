using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformScript : MonoBehaviour
{
    private void Start()
    {
        transform.rotation = new Quaternion(0, 0, Random.Range(-90, 90),0);
    }
}