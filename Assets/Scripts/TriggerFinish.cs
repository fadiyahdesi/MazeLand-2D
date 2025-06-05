using UnityEngine;

public class TriggerFinish : MonoBehaviour
{
    private bool hasFinished = false; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasFinished)
        {
            GameTimer timer = FindObjectOfType<GameTimer>();
            if (timer != null)
            {
                timer.FinishGame();
                Debug.Log("Selamat! Anda berhasil menyelesaikan level easy ini!");
                hasFinished = true;
            }
        }
    }
}
