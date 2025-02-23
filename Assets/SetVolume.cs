﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public string name;

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat(name, Mathf.Log10(sliderValue)*20);
    }
}
