using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject Panel;

    private GameObject Player;
    private GameObject wall;
    private GameObject Trigger;

    private bool isPaused = false;

    void Start()
    {
        Player = GameObject.Find("Player");
        wall = GameObject.Find("wall");
        Trigger = GameObject.Find("Trigger");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        Debug.Log("Game Paused");

        PausePanel.SetActive(false);
        Panel.SetActive(true);

        if (Player != null) Player.SetActive(false);
        if (wall != null) wall.SetActive(false);
        if (Trigger != null) Trigger.SetActive(false);

        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Game Resumed");

        PausePanel.SetActive(true);
        Panel.SetActive(false);

        if (Player != null) Player.SetActive(true);
        if (wall != null) wall.SetActive(true);
        if (Trigger != null) Trigger.SetActive(true);

        Time.timeScale = 1f;
        isPaused = false;
    }
}
