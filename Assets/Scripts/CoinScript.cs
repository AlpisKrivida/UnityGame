using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private GameObject boat;
    private GameObject aura;
    public GameObject Text;
    public int soundNumber = 0;
    public int points = 100;
    private bool move = false;
    public float moveSpeed = 20;

    SoundManager sm;
    BoatStats bs;
    // Start is called before the first frame update
    void Start()
    {
        boat = GameObject.FindGameObjectWithTag("MainBoat");
        aura = GameObject.FindGameObjectWithTag("MagnetAura");
        sm = GameObject.FindObjectOfType<SoundManager>();
        bs = GameObject.FindObjectOfType<BoatStats>();
        //ShowText();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == boat.tag)
        {
            sm.PlaySound(soundNumber);
            bs.UpdatePoints(points);
            //ShowText();
            Destroy(this.gameObject);
        }
        else if(other.tag == aura.tag)
        {
            move = true;
        }

    }

    private void ShowText()
    {
        Instantiate(Text, transform.position, Quaternion.identity, transform);
    }



    private void Update()
    {
        transform.Rotate(0,5,0,Space.World);
        if (move)
        {
            transform.LookAt(aura.transform);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }
}
