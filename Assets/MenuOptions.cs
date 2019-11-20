using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    public BoatStats bs;
    public Text score;
    public GameObject pauseMenu;
    public GameObject settings;
    public GameObject sounds;
    private SoundManager sm;
    public int soundNumberForButton;
    // Start is called before the first frame update
    void Start()
    {
        score.text = bs.totalPoints.ToString();
        sm = GameObject.FindObjectOfType<SoundManager>();
    }

    public void LoadLevel(int sceneNumber)
    {
        sm.PlaySound(soundNumberForButton);
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneNumber);
    }

    public void OpenSettings()
    {
        sm.PlaySound(soundNumberForButton);
        pauseMenu.SetActive(false);
        settings.SetActive(true);
    }

    public void OpenPause()
    {
        sm.PlaySound(soundNumberForButton);
        pauseMenu.SetActive(true);
        settings.SetActive(false);
        sounds.SetActive(false);
    }

    public void PauseUnpause()
    {
        sm.PlaySound(soundNumberForButton);
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }

    
}
