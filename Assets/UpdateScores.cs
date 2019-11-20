using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class UpdateScores : MonoBehaviour
{
    public Text text;
    private string temp;
    private InputManager inputManager;
    

    // Start is called before the first frame update
    void Start()
    {
        inputManager = InputManager.instance;
        PlayerData data = SaveSystem.LoadPlayer();
        //Debug.Log(data.score);
        if (data.score.Length != 0)
        {
            //time = data.time;
            //score = data.score;
        }


        for (int x = 0; x < 10; x++)
        {
            temp += string.Format("{0,-50}{1,-20} \n",Mathf.Round(data.score[x]), Math.Round( data.time[x],2));
        }
        text.text = temp;
    }

}
