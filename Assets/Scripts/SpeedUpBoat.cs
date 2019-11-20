using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpBoat : MonoBehaviour
{
    private GameObject boat;
    private Rigidbody b;
    bool triggered = false;
    private double timer = 0;
    public float waitTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        boat = GameObject.FindGameObjectWithTag("MainBoat");
        b = boat.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            timer += Time.deltaTime;
            if(timer > waitTime)
            {
                b.velocity = Vector3.zero;
                b.angularVelocity = Vector3.zero;
                triggered = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == boat.tag)
        {
            //Debug.Log("boat");
            b.AddForce(transform.forward * 20);
            triggered = true;
        }
    }
}
