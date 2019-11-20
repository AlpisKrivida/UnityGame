using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatCollider : MonoBehaviour
{
    private BoatStats bs;
    public int hitPoints;
    public bool isPiercing;
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
        if (other.tag == "MainBoat")
        {
            //Debug.Log("Susidure");
            bs = GameObject.FindObjectOfType<BoatStats>();
            bs.UpdateHitPoints(hitPoints, isPiercing);
        }
        //Debug.Log("Susidure");
        //SceneManager.LoadScene("SampleScene");

    }
}
