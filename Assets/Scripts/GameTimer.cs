using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float timeRemaining = 60f;
    public TMP_Text timerText;
    public bool isGameActive = false;
    public bool isPaused = false;
    private bool isFinished = false;

    public Transform player;
    private Vector3 startPosition;

    public GameObject finishPanel;
    public GameObject playerObj;
    public GameObject triggerObj;
    public GameObject wallObj;

    void Start()
    {
        if (player != null)
        {
            startPosition = player.position;
        }

        UpdateTimerUI();
        if (finishPanel != null)
        {
            finishPanel.SetActive(false); 
        }
    }

    void Update()
    {
        if (isGameActive && !isPaused && !isFinished)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerUI();
            }
            else
            {
                timeRemaining = 0;
                isGameActive = false;
                EndGame();
            }
        }
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StartTimer()
    {
        if (!isGameActive && !isFinished)
        {
            // Mulai game dari awal
            timeRemaining = 60f;
            isGameActive = true;
            isPaused = false;
            isFinished = false;
        }
        else if (isPaused && !isFinished)
        {
            // Lanjutkan game dari pause
            isPaused = false;
        }
    }

    public void TogglePause()
    {
        if (isGameActive && !isFinished)
        {
            isPaused = !isPaused;
        }
    }

    void EndGame()
    {
        if (player != null)
        {
            player.position = startPosition;
        }
    }

    public void FinishGame()
    {
        if (!isFinished)
        {
            isFinished = true;
            isGameActive = false;
            isPaused = false;
            UpdateTimerUI();

            if (finishPanel != null)
            {
                finishPanel.SetActive(true);
            }

            if (playerObj != null)
                playerObj.SetActive(false);

            if (triggerObj != null)
                triggerObj.SetActive(false);

            if (wallObj != null)
                wallObj.SetActive(false);
        }
    }
}
