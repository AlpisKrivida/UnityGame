using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="Keybindings", menuName = "Keybindings")]
public class KeyBindings : ScriptableObject
{
    public KeyCode moveLeft, moveRight, pause, jump;

    private void Awake()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if (data.MoveLeft != null)
        {
            moveLeft = (KeyCode)System.Enum.Parse(typeof(KeyCode), data.MoveLeft);
        }
        if (data.MoveRight != null)
        {
            moveRight = (KeyCode)System.Enum.Parse(typeof(KeyCode), data.MoveRight);
        }
        if (data.Pause != null)
        {
            pause = (KeyCode)System.Enum.Parse(typeof(KeyCode), data.Pause);
        }
        if (data.Jump != null)
        {
            jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), data.Jump);
        }
    }

    public KeyCode CheckKey(string key)
    {
        switch (key)
        {
            case "MoveLeft":
                return moveLeft;
            case "MoveRight":
                return moveRight;
            case "Pause":
                return pause;
            case "Jump":
                return jump;
            default:
                return KeyCode.None;
            
        }
    }

    public void SetKey(string key, string value)
    {
        
        switch (key)
        {
            case "MoveLeft":
                moveLeft = (KeyCode)System.Enum.Parse(typeof(KeyCode), value);
                break;
            case "MoveRight":
                moveRight = (KeyCode)System.Enum.Parse(typeof(KeyCode), value);
                break;
            case "Pause":
                pause = (KeyCode)System.Enum.Parse(typeof(KeyCode), value);
                break;
            case "Jump":
                jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), value);
                break;
        }
    }
}
