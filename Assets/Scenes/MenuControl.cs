using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    public GameObject Main_menu;
    public GameObject Sound;
    public GameObject About;
    public GameObject HighScores;
    public GameObject KeyCustomization;

    public Text MoveLeft;
    public Text MoveRight;
    public Text Pause;
    public Text Jump;

    public float delayTime;
    private float tempTime;
    private bool pressed = false;
    private int menuNumber;

    Event keyEvent;
    KeyCode newKey;
    Text buttonText;
    bool waitingForKey;
    private InputManager inputManager;
    private SoundManager sm;
    public int soundNumberForButton;



    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void Update()
    {
        if (pressed)
        {

            switch (menuNumber)
            {
                case 0:
                    delayTime -= Time.deltaTime;
                    Main_menu.SetActive(false);
                    if (delayTime < 0)
                    {
                        Sound.SetActive(true);
                        delayTime = tempTime;
                        pressed = false;
                    }
                    break;
                case 1:                  
                    Sound.SetActive(false);
                    About.SetActive(false);
                    HighScores.SetActive(false);
                    KeyCustomization.SetActive(false);

                    delayTime -= Time.deltaTime;
                    if (delayTime < 0)
                    {
                        Main_menu.SetActive(true);
                        delayTime = tempTime;
                        pressed = false;
                    }

                    break;
                case 2:
                    delayTime -= Time.deltaTime;
                    Main_menu.SetActive(false);
                    if (delayTime < 0)
                    {
                        About.SetActive(true);
                        delayTime = tempTime;
                        pressed = false;
                    }
                    break;
                case 3:
                    delayTime -= Time.deltaTime;
                    Main_menu.SetActive(false);
                    if (delayTime < 0)
                    {
                        HighScores.SetActive(true);
                        delayTime = tempTime;
                        pressed = false;
                    }
                    break;
                case 4:
                    KeyCustomization.SetActive(false);
                    Sound.SetActive(true);
                    pressed = false;
                    break;
                case 5:
                    KeyCustomization.SetActive(true);
                    Sound.SetActive(false);
                    pressed = false;
                    break;

            }
        }
    }

    public void SwitchMenus(int MenuNumber)
    {
        sm.PlaySound(soundNumberForButton);
        menuNumber = MenuNumber;
        pressed = true;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(delayTime);
    }

    private void Start()
    {
        inputManager = InputManager.instance;
        sm = GameObject.FindObjectOfType<SoundManager>();
        tempTime = delayTime;
        MoveLeft.text = inputManager.GetKey("MoveLeft").ToString();
        MoveRight.text = inputManager.GetKey("MoveRight").ToString();
        Pause.text = inputManager.GetKey("Pause").ToString();
        Jump.text = inputManager.GetKey("Jump").ToString();
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }

    private void OnGUI()
    {
        keyEvent = Event.current;

        if(keyEvent.isKey && waitingForKey)
        {
            newKey = keyEvent.keyCode;
            waitingForKey = false;
        }
    }

    public void StartAssignemnt(string keyName)
    {
        sm.PlaySound(soundNumberForButton);
        if (!waitingForKey)
            StartCoroutine(AssignKey(keyName));

    }

    public void SendText(Text text)
    {
        buttonText = text;
    }
    IEnumerator waitForKey()
    {
        while (!keyEvent.isKey)
            yield return null;
    }

    public IEnumerator AssignKey(string keyName)
    {
        waitingForKey = true;

        yield return waitForKey();

        switch (keyName)
        {
            case "MoveLeft":
                buttonText.text = newKey.ToString();
                inputManager.SetKey("MoveLeft", newKey.ToString());
                break;
            case "MoveRight":
                buttonText.text = newKey.ToString();
                inputManager.SetKey("MoveRight", newKey.ToString());
                break;
            case "Pause":
                buttonText.text = newKey.ToString();
                inputManager.SetKey("Pause", newKey.ToString());
                break;
            case "Jump":
                buttonText.text = newKey.ToString();
                inputManager.SetKey("Jump", newKey.ToString());
                break;
        }
    }
}
