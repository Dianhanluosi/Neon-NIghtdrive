using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSpawner : MonoBehaviour
{
    public GameObject thingToSpawn;

    public Vector3 shootDirection;
    public float shootForce;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(thingToSpawn, this.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Spawn(this.transform.position + new Vector3 (0,2f, 0));
            //Spawn(this.transform.position - new Vector3(0, 2f, 0));

            Fire(this.transform.position, shootDirection);

        }
    }

    void Spawn(Vector3 pos)
    {
        Instantiate(thingToSpawn, pos, Quaternion.identity, this.transform);
    }

    void Fire(Vector3 pos, Vector3 direction)
    {
        GameObject firedObj = Instantiate(thingToSpawn, pos, Quaternion.identity);
        firedObj.name = "fired object";
        firedObj.GetComponent<MeshRenderer>().material.color = new Color(Random.value, Random.value, Random.value);

        Rigidbody rb = firedObj.GetComponent<Rigidbody>();
        rb.AddForce(direction*shootForce );
    }

}
