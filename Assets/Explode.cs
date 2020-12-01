using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameObject explode;

    private void OnCollisionEnter(Collision collision)
    {
        expo(collision.contacts[0].point);
    }

    void expo(Vector3 pos/*, Vector3 direction*/)
    {
        GameObject explo = Instantiate(explode, pos, Quaternion.identity);
        explo.name = "fire";
        
    }
}
