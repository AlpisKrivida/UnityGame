using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField]
    private GameObject[] startObstalcePrefabs;
    [SerializeField]
    private GameObject[] MediumObstalcePrefabs;
    [SerializeField]
    private int zedOffset;
    private int zNumber = 500;
    // Start is called before the first frame update
    void Start()
    {
        zedOffset = 350;
        Instantiate(startObstalcePrefabs[Random.Range(0, startObstalcePrefabs.Length)], new Vector3(0, 2, 0), Quaternion.Euler(0, 0, 0));
        //Debug.Log("before " + zedOffset);
        zedOffset += zNumber;
        //Debug.Log("after " + zedOffset);

        for (int i = 1; i < 5; i++)
        {
            Instantiate(MediumObstalcePrefabs[Random.Range(0, MediumObstalcePrefabs.Length)], new Vector3(295, 15,  i * zNumber + 350), Quaternion.Euler(0, 0, 0));
            zedOffset += zNumber;
            //Debug.Log("init " + zedOffset+" znumber "+zNumber);
        } 

    }

    public void RecycleObstacles()
    {
        //Debug.Log("RecycleObstakces " + zedOffset);
        Instantiate(MediumObstalcePrefabs[Random.Range(0, MediumObstalcePrefabs.Length)], new Vector3(295, 15, zedOffset), Quaternion.Euler(0, 0, 0));
        zedOffset += zNumber;
    }
}
