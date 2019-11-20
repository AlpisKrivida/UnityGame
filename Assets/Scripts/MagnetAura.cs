using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetAura : MonoBehaviour
{
    private GameObject coin;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Coin")
        {
            //Debug.Log("yes");
        }
    }
}
