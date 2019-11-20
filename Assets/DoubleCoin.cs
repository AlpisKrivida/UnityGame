using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleCoin : MonoBehaviour
{
    private GameObject boat;
    public GameObject Text;
    public int soundNumber = 0;
    public int points = 100;
    public float moveSpeed = 20;

    SoundManager sm;
    BoatStats bs;
    // Start is called before the first frame update
    void Start()
    {
        boat = GameObject.FindGameObjectWithTag("MainBoat");
        sm = GameObject.FindObjectOfType<SoundManager>();
        bs = GameObject.FindObjectOfType<BoatStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == boat.tag)
        {
            sm.PlaySound(soundNumber);
            bs.ActiavteDoubleCoin();
            Destroy(this.gameObject);
        }
    }
}
