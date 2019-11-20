using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    private GameObject boat;
    public int soundNumber = 8;
    public int points=20;
    public bool isPiercing;
    SoundManager sm;
    BoatStats bs;

    // Start is called before the first frame update
    void Start()
    {
        boat = GameObject.FindGameObjectWithTag("MainBoat");
        bs = GameObject.FindObjectOfType<BoatStats>();
        sm = GameObject.FindObjectOfType<SoundManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == boat.tag)
        {
            sm.PlaySound(soundNumber);
            bs.UpdateHitPoints(points, isPiercing);
            //ShowText();
            Destroy(this.gameObject);
        }

    }
}
