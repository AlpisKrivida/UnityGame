using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private EndlessRunner platformManager;
    private Obstacles obstacleManager;
    public GameObject terrain;

    private void OnEnable()
    {
        platformManager = GameObject.FindObjectOfType<EndlessRunner>();
        obstacleManager = GameObject.FindObjectOfType<Obstacles>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="MainBoat") {
            platformManager.RecyclePlatform();
            obstacleManager.RecycleObstacles();

            Destroy(terrain, 2);
        }
    }
}
