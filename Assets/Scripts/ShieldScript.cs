using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    private GameObject boat;
    public int soundNumber = 2;
    SoundManager sm;
    // Start is called before the first frame update
    void Start()
    {
        boat = GameObject.FindGameObjectWithTag("MainBoat");
        sm = GameObject.FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == boat.tag)
        {
            sm.PlaySound(soundNumber);
            boat.GetComponent<BoatStats>().ActivateShield();
            Destroy(this.gameObject);
        }
    }
}
