using UnityEngine;
using System.Collections;

public class ChasePlayer : MonoBehaviour
{

    public float speed;
    GameObject target;
    public float chaseDist;
    public float smoothTime = 10.0f;
    public float stopDist;
    //Vector3 used to store the velocity of the enemy
    private Vector3 smoothVelocity = Vector3.zero;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("MainBoat");
    }

    void Update()
    {
        float dist = Vector3.Distance(target.transform.position, transform.position);
    
        transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
        if (dist < chaseDist)
        {
            //Debug.Log(dist);
            if (dist > stopDist)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }
    }
}
