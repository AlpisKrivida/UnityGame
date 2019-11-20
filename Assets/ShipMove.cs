using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMove : MonoBehaviour
{
    public float speed;
    GameObject target;
    public float chaseDist;
    //Vector3 used to store the velocity of the enemy
    private Vector3 smoothVelocity = Vector3.zero;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("MainBoat");
    }

    void Update()
    {
        float dist = Vector3.Distance(target.transform.position, transform.position);
        //Debug.Log(dist);

        if (dist < chaseDist)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
