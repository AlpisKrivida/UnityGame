using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    public KeyBindings keybindings;
    public Player player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    public bool KeyDown(string key)
    {
        if (Input.GetKey(keybindings.CheckKey(key)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool GetKeyDown(string key)
    {
        if (Input.GetKeyDown(keybindings.CheckKey(key)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetKey(string name, string value)
    {
        keybindings.SetKey(name, value);
        switch (name)
        {
            case "MoveLeft":
                player.MoveLeft = value;
                break;
            case "MoveRight":
                player.MoveRight = value;
                break;
            case "Pause":
                player.Pause = value;
                break;
            case "Jump":
                player.Jump = value;
                break;
        }
        player.SavePlayer();
    }

    public KeyCode GetKey(string key)
    {
        return keybindings.CheckKey(key);
    }
}
