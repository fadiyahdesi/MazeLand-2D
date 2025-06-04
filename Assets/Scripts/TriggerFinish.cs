using UnityEngine;

public class TriggerFinish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trigger masuk!");
            GameTimer timer = FindObjectOfType<GameTimer>();
            if (timer != null)
            {
                timer.FinishGame();
            }
        }
    }
}
