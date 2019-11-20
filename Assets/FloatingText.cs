using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    private Vector3 offset = new Vector3(0, 5, 4);
    private Vector3 RandomPosition = new Vector3(1f, 1f, 1f);
    public float destroyTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, destroyTime);
        transform.localPosition += offset;
        transform.localPosition += new Vector3(Random.Range(-RandomPosition.x, RandomPosition.x),
            Random.Range(-RandomPosition.y, RandomPosition.y),
            Random.Range(-RandomPosition.z, RandomPosition.x));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
