using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource adSource;
    public AudioClip[] adClips;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlaySound(int number)
    {
        adSource.clip = adClips[number];
        adSource.Play();

    }
}
