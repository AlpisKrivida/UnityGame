using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpadateMusic : MonoBehaviour
{
    public Slider musicSlider;
    public Slider SFXSlider;
    //public AudioSource bm;
    private InputManager inputManager;

    private void Start()
    {
        inputManager = InputManager.instance;
        PlayerData data = SaveSystem.LoadPlayer();

        musicSlider.value = data.MusicValue;
        Debug.Log(data.MusicValue);
        SFXSlider.value = data.SFXValue;
        //StartCoroutine(WaitFor());

    }

    //IEnumerator WaitFor() { 
    //    yield return new WaitForSeconds(1f);
    //    bm.enabled = true;
    //}

}
