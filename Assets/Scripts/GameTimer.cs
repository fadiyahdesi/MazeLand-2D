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

    void Start()
    {
        if (player != null)
        {
            startPosition = player.position;
        }

        UpdateTimerUI();
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
        if (!isGameActive)
        {
            // Mulai game dari awal
            timeRemaining = 60f;
            isGameActive = true;
            isPaused = false;
            isFinished = false;
        }
        else if (isPaused)
        {
            // Lanjutkan game dari pause
            isPaused = false;
        }
    }

    public void TogglePause()
    {
        if (isGameActive)
        {
            isPaused = !isPaused;
        }
    }

    void EndGame()
    {
        Debug.Log("Waktu habis! Player kembali ke posisi awal.");

        if (player != null)
        {
            player.position = startPosition;
        }

        // Game dihentikan, tunggu input user
    }

    public void FinishGame()
    {
        isFinished = true;
        isGameActive = false;
        isPaused = false;
        UpdateTimerUI();
    }
}
