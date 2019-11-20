using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] time;
    public float[] score;

    public string MoveLeft;
    public string MoveRight;
    public string Pause;
    public string Jump;

    public float MusicValue;
    public float SFXValue;

    public PlayerData(Player player)
    {
        time = player.time;
        score = player.score;

        MoveLeft = player.MoveLeft;
        MoveRight = player.MoveRight;
        Pause = player.Pause;
        Jump = player.Jump;

        MusicValue = player.MusicValue;
        SFXValue = player.SFXValue;
    }
}
