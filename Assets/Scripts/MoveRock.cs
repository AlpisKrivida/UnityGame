using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRock : MonoBehaviour
{
    private GameObject boat;
    public Animator m_Aniamtor;
    //public string animationName;
    public int damage;
    public bool isPiercing;
    private BoatStats bs;
    // Start is called before the first frame update
    void Start()
    {
        //boat = GameObject.FindGameObjectWithTag("MainBoat");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainBoat")
        {
            //m_Aniamtor = gameObject.GetComponent<Animator>();
            bs = other.GetComponent<BoatStats>();
            bs.UpdateHitPoints(damage,isPiercing);
            m_Aniamtor.enabled = true;
            //m_/*Aniamtor.Play(animationName);*/

        }
    }
}
