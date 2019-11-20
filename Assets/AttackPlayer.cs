using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{

    BoatStats bs;
    public int damageOverTime;
    public float timeBeetweenAttacks;
    private float timer = 0;
    private bool attack = true;
    public bool isPiercing;

    private void Start()
    {
        bs = GameObject.FindGameObjectWithTag("MainBoat").GetComponent<BoatStats>();
    }

    private void Update()
    {
        if (!attack)
        {
            timer += Time.deltaTime;
            if (timer > timeBeetweenAttacks)
            {
                timer = 0;
                attack = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MainBoat")
        {
            if (attack == true)
            {
                bs.UpdateHitPoints(-damageOverTime, isPiercing);
                attack = false;
            }
        }
    }
}
