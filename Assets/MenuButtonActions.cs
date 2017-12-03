using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonActions : MonoBehaviour
{
    public GameObject gameOver, start, pause;
    public PlayerConrtoller pc;
    private void Start()
    {
        AudioListener.volume = 0;
        Time.timeScale = 0;
        start.SetActive(true);

        pc.enabled = false;
    }

    public void Begin()
    {
        Time.timeScale = 1;
        start.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pc.enabled = true;
        AudioListener.volume = muted ? 0 : 1;
    }
    bool muted = false;
    public Text muteButtonText;
    public void ToggleMute()
    {
        muted = !muted;
        muteButtonText.text = muted ? "UnMute" : "Mute";
        AudioListener.volume = muted ? 0 : 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quit()
    {
        Application.Quit();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        AudioListener.volume = 0;
        gameOver.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    bool paused = false;
    public void TogglePause()
    {
        
        paused = !paused;
        Time.timeScale = paused ? 0 : 1;
        pause.SetActive(paused);

        Cursor.lockState = paused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = paused;
        pc.enabled = !paused;
        AudioListener.volume = paused ? 0 : 1;
    }
    public GameObject instructions;
    bool instructionsOpen = false;
    public void ToggleInstructions()
    {
        instructionsOpen = !instructionsOpen;
        start.SetActive(!instructionsOpen);
        instructions.SetActive(instructionsOpen);
    }
    public GameObject win;
    public void Win()
    {
        Time.timeScale = 0;
        AudioListener.volume = 0;
        win.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pc.enabled = false;
    }
}
