using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float[] time = new float[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public float[] score = new float[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    public string MoveLeft;
    public string MoveRight;
    public string Pause;
    public string Jump;

    public float MusicValue;
    public float SFXValue;
    private InputManager inputManager;
    private SoundManager sm;
    public int soundNumberForSave;

    // Start is called before the first frame update
    void Start()
    {
        sm = GameObject.FindObjectOfType<SoundManager>();
        inputManager = InputManager.instance;
        PlayerData data = SaveSystem.LoadPlayer();
        //Debug.Log(data.score);
        if (data.score.Length != 0)
        {
            time = data.time;
            score = data.score;
        }
        MusicValue = data.MusicValue;
        SFXValue = data.SFXValue;

        MoveLeft = inputManager.GetKey("MoveLeft").ToString();
        MoveRight = inputManager.GetKey("MoveRight").ToString();
        Pause = inputManager.GetKey("Pause").ToString();

        Jump = inputManager.GetKey("Jump").ToString();
        //ClearData();
    }

    public float[] returnTime()
    {
        return time;
    }


    public void UpdateScore(float newTime, float newScore)
    {

        if(score.Length == 0)
        {
            score[0] = newScore;
            time[0] = newTime;
        }

        for (int x = 0; x < score.Length; x++)
        {
            if (newScore > score[x])
            {
                score[9] = newScore;
                time[9] = newTime;

                break;
            }
        }
         
        Array.Sort(score);
        Array.Reverse(score);
        Array.Sort(time);
        Array.Reverse(time);

        SavePlayer();
    }

    public void UpdateSound()
    {
        sm.PlaySound(soundNumberForSave);
        MusicValue = GameObject.FindGameObjectWithTag("MasterVolumeSlider").GetComponent<Slider>().value;
        SFXValue = GameObject.FindGameObjectWithTag("SFXVolumeSlider").GetComponent<Slider>().value;

        SavePlayer();
    }
    

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void ClearData()
    {
        SaveSystem.SavePlayer(null);
    }
    
}
