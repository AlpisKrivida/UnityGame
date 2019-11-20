using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRunner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] platformPrefabs;
    [SerializeField]
    private int zedOffset;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i< 4; i++)
        {
            Instantiate(platformPrefabs[Random.Range(0, platformPrefabs.Length)], new Vector3(0, 0, i * 500), Quaternion.Euler(0, 0, 0));
            zedOffset += 500;
        }
        
    }

    public void RecyclePlatform()
    {
        Instantiate(platformPrefabs[Random.Range(0, platformPrefabs.Length)], new Vector3(0, 0, zedOffset), Quaternion.Euler(0, 0, 0));
        zedOffset += 500;
    }
}
